using LibraryComputerLaboratoryTimeManagementSystemStudent.Frontend.Services;
using LibraryComputerLaboratoryTimeManagementSystemStudent.Frontend.Services.StudentServices;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryComputerLaboratoryTimeManagementSystemStudent.Frontend.Forms
{
    public partial class ScanRfidForm : Form
    {
        private StudentServices _studentServices;
        private bool _isProcessing = false;

        public ScanRfidForm()
        {
            InitializeComponent();

            _studentServices = new StudentServices();

            this.Shown += (s, e) => RFIDTextBox.Focus();
            RFIDTextBox.KeyDown += RFIDTextBox_KeyDown;
        }

        private async void RFIDTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;   // only on Enter
            if (_isProcessing) return;             // already handling a scan

            _isProcessing = true;
            RFIDTextBox.Enabled = false;

            e.Handled = true;
            e.SuppressKeyPress = true; // prevents ding sound

            var rfid = RFIDTextBox.Text?.Trim();
            if (string.IsNullOrWhiteSpace(rfid))
            {
                MessageBox.Show("No RFID read.");
                _isProcessing = false;
                RFIDTextBox.Enabled = true;
                return;
            }

            try
            {
                bool success = await _studentServices.AuthenticateByRfidAsync(rfid);
                if (success)
                {
                    // NEW: Get student info to check duration
                    var json = await _studentServices.GetCurrentStudentAsync();
                    var obj = Newtonsoft.Json.Linq.JObject.Parse(json);

                    if (!(bool)obj["isSuccess"])
                    {
                        MessageBox.Show("Failed to load student info.");
                        return;
                    }

                    var student = obj["value"];
                    string durationStr = student["duration"]?.ToString();

                    if (string.IsNullOrWhiteSpace(durationStr) ||
                        !TimeSpan.TryParse(durationStr, out TimeSpan duration) ||
                        duration.TotalSeconds <= 0)
                    {
                        MessageBox.Show("Your session time is already used up. Please request additional time from the librarian.");
                        RFIDTextBox.Clear();
                        return;
                    }

                    // If duration is valid (> 0), proceed
                    MessageBox.Show("RFID authenticated successfully.");
                    RFIDTextBox.Clear();

                    var TRForm = new TimeRemainingForm();

                    TRForm.FormClosed += (_, __) =>
                    {
                        this.Close();
                    };

                    this.Hide();
                    TRForm.Show();
                }
                else
                {
                    MessageBox.Show("RFID authentication failed.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during authentication: {ex.Message}");
            }
            finally
            {
                // Only re-enable if this form is still visible (no navigation yet)
                if (!this.IsDisposed && this.Visible)
                {
                    _isProcessing = false;
                    RFIDTextBox.Enabled = true;
                    RFIDTextBox.Focus();
                }
            }
        }


    }
}
