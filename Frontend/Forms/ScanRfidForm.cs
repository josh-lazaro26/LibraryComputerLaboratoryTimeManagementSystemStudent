using LibraryComputerLaboratoryTimeManagementSystemStudent.Frontend.Services;
using LibraryComputerLaboratoryTimeManagementSystemStudent.Frontend.Services.StudentServices;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryComputerLaboratoryTimeManagementSystemStudent.Frontend.Forms
{
    public partial class ScanRfidForm : Form
    {
        private StudentServices _studentServices;
        private bool _isProcessing = false;

        // Low-level keyboard hook
        private static IntPtr _hookId = IntPtr.Zero;
        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
        private static LowLevelKeyboardProc _proc;

        [DllImport("user32.dll")]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll")]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll")]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_SYSKEYDOWN = 0x0104;
        private const int VK_LWIN = 0x5B;
        private const int VK_RWIN = 0x5C;
        private const int VK_TAB = 0x09;
        private const int VK_F4 = 0x73;

        public ScanRfidForm()
        {
            InitializeComponent();
            _studentServices = new StudentServices();
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = true;
            this.FormClosing += ScanRfidForm_FormClosing;
            this.Shown += (s, e) => RFIDTextBox.Focus();
            RFIDTextBox.KeyDown += RFIDTextBox_KeyDown;

            // Start the keyboard hook
            _proc = HookCallback;
            _hookId = SetHook(_proc);
        }

        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (var curProcess = System.Diagnostics.Process.GetCurrentProcess())
            using (var curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && (wParam == (IntPtr)WM_KEYDOWN || wParam == (IntPtr)WM_SYSKEYDOWN))
            {
                int vkCode = Marshal.ReadInt32(lParam);

                // Block Windows key
                if (vkCode == VK_LWIN || vkCode == VK_RWIN) return (IntPtr)1;

                // Block Alt+Tab
                if (vkCode == VK_TAB && (Control.ModifierKeys & Keys.Alt) != 0) return (IntPtr)1;

                // Block Alt+F4
                if (vkCode == VK_F4 && (Control.ModifierKeys & Keys.Alt) != 0) return (IntPtr)1;
            }

            return CallNextHookEx(_hookId, nCode, wParam, lParam);
        }

        private async void RFIDTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;   // only on Enter
            if (_isProcessing) return;             // already handling a scan

            if (RFIDTextBox.Text?.Trim() == "253515")
            {
                RFIDTextBox.Clear();
                UnhookWindowsHookEx(_hookId);  // Release keyboard hook first
                _hookId = IntPtr.Zero;
                Application.Exit();            // Close the entire application
                return;
            }

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

        private void ScanRfidForm_Load(object sender, EventArgs e)
        {
            var screen = Screen.PrimaryScreen;
            ResponsiveLayout.Initialize(screen);

            ApplyResponsiveLayout(screen);
        }

        private void ApplyResponsiveLayout(Screen screen)
        {
            int screenWidth = screen.Bounds.Width;
            int screenHeight = screen.Bounds.Height;

            HeaderLabel.Font = ResponsiveLayout.ScaleFont("Roboto", 72f, FontStyle.Regular);
            HeaderLabel.Size = ResponsiveLayout.ScaleSize(600, 80);
            HeaderLabel.Location = new Point(
                ResponsiveLayout.CenterHorizontal(screenWidth, HeaderLabel.Width) + 80,
                ResponsiveLayout.ScaleLocation(0, 300).Y
            );

            AdminRFIDScanLabel.Font = ResponsiveLayout.ScaleFont("Roboto", 36f);
            AdminRFIDScanLabel.Size = ResponsiveLayout.ScaleSize(500, 50);
            AdminRFIDScanLabel.Location = new Point(
                ResponsiveLayout.CenterHorizontal(screenWidth, AdminRFIDScanLabel.Width) + 80,
                ResponsiveLayout.ScaleLocation(0, 600).Y
            );

            NDTCLibraryPb.Size = ResponsiveLayout.ScaleSize(300, 300);
            NDTCLibraryPb.Location = new Point(
                HeaderLabel.Left - NDTCLibraryPb.Width + 20, 
                HeaderLabel.Top + (HeaderLabel.Height / 2) - (NDTCLibraryPb.Height / 2) 
            );
            NDTCLibraryPb.SizeMode = PictureBoxSizeMode.Zoom;

            RFIDTextBox.Font = ResponsiveLayout.ScaleFont("Roboto", 14f);
            RFIDTextBox.Size = ResponsiveLayout.ScaleSize(400, 45);
            RFIDTextBox.Location = new Point(
                ResponsiveLayout.CenterHorizontal(screenWidth, RFIDTextBox.Width) + 60,
                ResponsiveLayout.ScaleLocation(0, 600).Y //420
            );
        }

        private void ScanRfidForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                return;
            }

            // Unhook when form actually closes
            if (_hookId != IntPtr.Zero)
            {
                UnhookWindowsHookEx(_hookId);
                _hookId = IntPtr.Zero;
            }
        }
    }
}
