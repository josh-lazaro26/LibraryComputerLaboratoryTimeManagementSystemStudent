using LibraryComputerLaboratoryTimeManagementSystemStudent.Frontend.Models.StudentDao;
using LibraryComputerLaboratoryTimeManagementSystemStudent.Frontend.Services;
using LibraryComputerLaboratoryTimeManagementSystemStudent.Frontend.Services.StudentServices;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryComputerLaboratoryTimeManagementSystemStudent.Frontend.Forms
{
    public partial class TimeRemainingForm : Form
    {
        private System.Windows.Forms.Timer _countdownTimer;
        private int _remainingSeconds;
        private StudentServices _studentServices;

        private bool _notificationShown = false;

        private int _sessionId;

        private readonly SignalRService _signalRService;

        public TimeRemainingForm()
        {
            InitializeComponent();
            _studentServices = new StudentServices();
            this.Opacity = 0.9;
            this.StartPosition = FormStartPosition.Manual;
            var screen = Screen.PrimaryScreen.WorkingArea;
            this.Location = new Point(screen.Right - this.Width, screen.Top);
            InitializeCountdownTimer();
            this.Load += TimeRemainingForm_Load;
            _signalRService = new SignalRService(() => Task.FromResult(ApiConfig.Token));

            SignalRInitialize();

            _signalRService.DisconnectUser += () =>
            {
                Console.WriteLine("This user is disconnected.");
                //PcLocker.LockWorkStation();
            };

            _signalRService.UpdatedStudentSession += (TimeSpan updatedSession) =>
            {
                Console.WriteLine("aray mo: " + updatedSession);

                if (InvokeRequired)
                {
                    BeginInvoke(new Action(() =>
                    {
                        _remainingSeconds = (int)updatedSession.TotalSeconds;
                        UpdateTimeLabel();
                    }));
                }
                else
                {
                    _remainingSeconds = (int)updatedSession.TotalSeconds;
                    UpdateTimeLabel();
                }
            };
        }
        private void InitializeCountdownTimer()
        {
            _countdownTimer = new System.Windows.Forms.Timer();
            _countdownTimer.Interval = 1000; // 1 second
            _countdownTimer.Tick += CountdownTimer_Tick;
        }

        private void SignalRInitialize()
        {
            try
            {
                _ = _signalRService.InitializeAsync();
                Console.WriteLine("signalR initialized");
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.ToString());
            }
        }
        private async Task LoadStudentAsync()
        {
            try
            {
                var json = await _studentServices.GetCurrentStudentAsync();
                System.Diagnostics.Debug.WriteLine($"Student response: {json}");

                var obj = Newtonsoft.Json.Linq.JObject.Parse(json);

                if (!(bool)obj["isSuccess"])
                {
                    MessageBox.Show("Failed to load student info.");
                    return;
                }

                var student = obj["value"];

                string fullName = string.Join(" ",
                    new[]
                    {
                student["firstName"]?.ToString(),
                student["middleName"]?.ToString(),
                student["lastName"]?.ToString()
                    }
                    .Where(x => !string.IsNullOrWhiteSpace(x))
                );

                string durationStr = student["duration"]?.ToString();
                if (!string.IsNullOrWhiteSpace(durationStr) && TimeSpan.TryParse(durationStr, out TimeSpan duration))
                {
                    int seconds = (int)duration.TotalSeconds;
                    StartCountdown(seconds);
                    System.Diagnostics.Debug.WriteLine($"Parsed duration: {durationStr} = {seconds} seconds");
                }
                else
                {
                    MessageBox.Show("Invalid duration format.");
                    this.Close();
                }

                //New
                _sessionId = student["sessionId"]?.Value<int>() ?? 0;


                FullNameLabel.Text = fullName;
                CourseLabel.Text = student["course"]?.ToString();
                CurrentDateLabel.Text = DateTime.Now.ToString("MMMM dd, yyyy");

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading student: {ex.Message}");
                MessageBox.Show("Failed to load student info.");
            }
        }

        //New
        private async void CountdownTimer_Tick(object sender, EventArgs e)
        {
            if (_remainingSeconds > 0)
            {
                _remainingSeconds--;
                UpdateTimeLabel();
                // Show notification modal when 10 minutes and 30 seconds remaining
                if (_remainingSeconds == 630 && !_notificationShown)
                {
                    _notificationShown = true; // Prevent showing it multiple times
                    var notificationModal = new NoticationModalForm();
                    notificationModal.Show();
                }
            }
            else
            {
                _countdownTimer.Stop();
                await TerminateSession();
            }
        }

        private void StartCountdown(int seconds)
        {
            _remainingSeconds = seconds;
            UpdateTimeLabel();
            _countdownTimer.Start();
        }

        private async void TerminateSessionBtn_Click(object sender, EventArgs e)
        {
            await TerminateSession();
        }

        private void UpdateTimeLabel()
        {
            StudentTimeLabel.Text = TimeSpan.FromSeconds(_remainingSeconds).ToString(@"hh\:mm\:ss");
        }

        private async void TimeRemainingForm_Load(object sender, EventArgs e)
        {
            await LoadStudentAsync();
            await _signalRService.InitializeAsync();
        }

        private async Task TerminateSession()
        {
            try
            {
                Console.WriteLine("Connection triggered InvokeAsync LogoutUser");

                if (_signalRService.GetHubConnection().State == HubConnectionState.Connected)
                {
                    await _signalRService.GetHubConnection().InvokeAsync("LogoutUser");
                }

                var scanRfidForm = new ScanRfidForm();
                scanRfidForm.Show();
                this.Close();
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"May mali yati {ex.Message}");
            }
        }
    }
}
