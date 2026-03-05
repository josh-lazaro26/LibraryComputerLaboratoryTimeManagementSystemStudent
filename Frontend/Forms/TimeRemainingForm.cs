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

            _signalRService.LoggedOutSession += (Guid userId) =>
            {
                Console.WriteLine($"This user is disconnected. {userId}");
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

            _signalRService.Terminate += () =>
            {
                if (InvokeRequired)
                {
                    BeginInvoke(new Action(async () => await TerminateSession()));
                }
                else
                {
                    _ = TerminateSession();
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
        private void LoadStudent()
        {
            try
            {
                string durationStr = StudentDao.Duration;

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

                CurrentDateLabel.Text = DateTime.Now.ToString("MMMM dd, yyyy");
                SchoolIdLabel.Text = StudentDao.SchoolId ?? "N/A";
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
            using (var dialog = new DialogForm("Logout", "Are you sure you want to logout?"))
            {
                if (dialog.ShowDialog(this) == DialogResult.OK && dialog.IsConfirmed)
                {
                    await HandleLogout();
                }
            }
        }

        private void UpdateTimeLabel()
        {
            StudentTimeLabel.Text = TimeSpan.FromSeconds(_remainingSeconds).ToString(@"hh\:mm\:ss");
        }
        private void TimeRemainingForm_Load(object sender, EventArgs e)
        {
            LoadStudent();
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

                await HandleLogout();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"May mali yati {ex.Message}");
            }
        }
        private async Task HandleLogout()
        {
            bool hasAnswered = string.Equals(
                StudentDao.HasAnsweredToEvaluation,
                "True",
                StringComparison.OrdinalIgnoreCase);

            if (!hasAnswered)
            {
                var evaluationForm = new EvaluationAnswerForm();
                evaluationForm.ShowDialog(this); // Modal — blocks until closed
            }

            var studentService = new StudentServices();
            bool success = await studentService.Logout();

            if (success)
            {
                var rfidForm = new ScanRfidForm();
                rfidForm.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Logout failed. Please try again.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
