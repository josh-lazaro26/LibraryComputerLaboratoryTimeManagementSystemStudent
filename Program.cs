using LibraryComputerLaboratoryTimeManagementSystemStudent.Frontend.Forms;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryComputerLaboratoryTimeManagementSystemStudent
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SetStartup();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ScanRfidForm());
        }

        private static void SetStartup()
        {
            string appPath = Application.ExecutablePath;
            string taskName = "LibraryComputerLaboratory";

            // Check if task already exists first
            var checkProcess = System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/c schtasks /query /tn \"{taskName}\"",
                WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                UseShellExecute = false
            });

            checkProcess.WaitForExit();

            // Exit code 0 means task exists, skip registration
            if (checkProcess.ExitCode == 0) return;

            // Task doesn't exist, register it
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/c schtasks /create /tn \"{taskName}\" /tr \"{appPath}\" /sc onlogon /rl highest /f",
                WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
                CreateNoWindow = true
            });
        }
    }
}
