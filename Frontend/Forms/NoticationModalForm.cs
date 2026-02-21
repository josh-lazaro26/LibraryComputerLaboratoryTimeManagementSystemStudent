using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryComputerLaboratoryTimeManagementSystemStudent.Frontend.Forms
{
    public partial class NoticationModalForm : Form
    {
        private Timer blinkTimer;
        private Timer closeTimer;
        private bool isVisible = true;
        private int elapsedSeconds = 0;

        public NoticationModalForm()
        {
            InitializeComponent();
            this.Opacity = 0.8;
            InitializeTimers();
        }

        private void InitializeTimers()
        {
            blinkTimer = new Timer();
            blinkTimer.Interval = 500;
            blinkTimer.Tick += BlinkTimer_Tick;

            closeTimer = new Timer();
            closeTimer.Interval = 1000;
            closeTimer.Tick += CloseTimer_Tick;
        }

        private void BlinkTimer_Tick(object sender, EventArgs e)
        {
            if (isVisible)
            {
                this.Opacity = 0.3;
                isVisible = false;
            }
            else
            {
                this.Opacity = 0.8;
                isVisible = true;
            }
        }

        private void CloseTimer_Tick(object sender, EventArgs e)
        {
            elapsedSeconds++;

            if (elapsedSeconds >= 10)
            {
                blinkTimer.Stop();
                closeTimer.Stop();
                this.Close();
            }
        }

        private void NoticationModalForm_Load(object sender, EventArgs e)
        {
            this.Opacity = 0.8;
            blinkTimer.Start();
            closeTimer.Start();
        }

        private void NoticationModalForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // ❌ REMOVED: base.OnFormClosed(e) — caused StackOverflowException
            blinkTimer?.Stop();
            blinkTimer?.Dispose();
            closeTimer?.Stop();
            closeTimer?.Dispose();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            blinkTimer?.Stop();
            blinkTimer?.Dispose();
            closeTimer?.Stop();
            closeTimer?.Dispose();
            this.Close();
        }
    }
}