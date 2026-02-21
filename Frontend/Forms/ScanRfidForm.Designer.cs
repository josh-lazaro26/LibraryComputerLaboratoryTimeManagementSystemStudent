namespace LibraryComputerLaboratoryTimeManagementSystemStudent.Frontend.Forms
{
    partial class ScanRfidForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScanRfidForm));
            this.AdminRFIDScanLabel = new System.Windows.Forms.Label();
            this.HeaderLabel = new System.Windows.Forms.Label();
            this.NDTCLibraryPb = new System.Windows.Forms.PictureBox();
            this.RFIDTextBox = new System.Windows.Forms.TextBox();
            this.ScanRfidFormElipse = new Bunifu.Framework.UI.BunifuElipse(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.NDTCLibraryPb)).BeginInit();
            this.SuspendLayout();
            // 
            // AdminRFIDScanLabel
            // 
            this.AdminRFIDScanLabel.AutoSize = true;
            this.AdminRFIDScanLabel.Font = new System.Drawing.Font("Roboto SemiBold", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AdminRFIDScanLabel.ForeColor = System.Drawing.Color.White;
            this.AdminRFIDScanLabel.Location = new System.Drawing.Point(182, 417);
            this.AdminRFIDScanLabel.Name = "AdminRFIDScanLabel";
            this.AdminRFIDScanLabel.Size = new System.Drawing.Size(652, 58);
            this.AdminRFIDScanLabel.TabIndex = 6;
            this.AdminRFIDScanLabel.Text = "Tap Student RFID to continue";
            // 
            // HeaderLabel
            // 
            this.HeaderLabel.AutoSize = true;
            this.HeaderLabel.Font = new System.Drawing.Font("Inter Light", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeaderLabel.ForeColor = System.Drawing.Color.White;
            this.HeaderLabel.Location = new System.Drawing.Point(257, 123);
            this.HeaderLabel.Name = "HeaderLabel";
            this.HeaderLabel.Size = new System.Drawing.Size(564, 136);
            this.HeaderLabel.TabIndex = 5;
            this.HeaderLabel.Text = "Library Laboratory Time\r\n Management  System";
            // 
            // NDTCLibraryPb
            // 
            this.NDTCLibraryPb.Image = ((System.Drawing.Image)(resources.GetObject("NDTCLibraryPb.Image")));
            this.NDTCLibraryPb.Location = new System.Drawing.Point(65, 110);
            this.NDTCLibraryPb.Name = "NDTCLibraryPb";
            this.NDTCLibraryPb.Size = new System.Drawing.Size(186, 179);
            this.NDTCLibraryPb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.NDTCLibraryPb.TabIndex = 4;
            this.NDTCLibraryPb.TabStop = false;
            // 
            // RFIDTextBox
            // 
            this.RFIDTextBox.Location = new System.Drawing.Point(299, 372);
            this.RFIDTextBox.Name = "RFIDTextBox";
            this.RFIDTextBox.Size = new System.Drawing.Size(424, 20);
            this.RFIDTextBox.TabIndex = 7;
            this.RFIDTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RFIDTextBox_KeyDown);
            // 
            // ScanRfidFormElipse
            // 
            this.ScanRfidFormElipse.ElipseRadius = 0;
            this.ScanRfidFormElipse.TargetControl = this;
            // 
            // ScanRfidForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(64)))), ((int)(((byte)(43)))));
            this.ClientSize = new System.Drawing.Size(930, 625);
            this.Controls.Add(this.AdminRFIDScanLabel);
            this.Controls.Add(this.HeaderLabel);
            this.Controls.Add(this.NDTCLibraryPb);
            this.Controls.Add(this.RFIDTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ScanRfidForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ScanRfidForm_FormClosing);
            this.Load += new System.EventHandler(this.ScanRfidForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NDTCLibraryPb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label AdminRFIDScanLabel;
        private System.Windows.Forms.Label HeaderLabel;
        private System.Windows.Forms.PictureBox NDTCLibraryPb;
        private System.Windows.Forms.TextBox RFIDTextBox;
        private Bunifu.Framework.UI.BunifuElipse ScanRfidFormElipse;
    }
}