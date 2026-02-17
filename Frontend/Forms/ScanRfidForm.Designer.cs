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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScanRfidForm));
            this.AdminRFIDScan = new System.Windows.Forms.Label();
            this.l = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.RFIDTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // AdminRFIDScan
            // 
            this.AdminRFIDScan.AutoSize = true;
            this.AdminRFIDScan.Font = new System.Drawing.Font("Roboto SemiBold", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AdminRFIDScan.ForeColor = System.Drawing.Color.White;
            this.AdminRFIDScan.Location = new System.Drawing.Point(182, 417);
            this.AdminRFIDScan.Name = "AdminRFIDScan";
            this.AdminRFIDScan.Size = new System.Drawing.Size(652, 58);
            this.AdminRFIDScan.TabIndex = 6;
            this.AdminRFIDScan.Text = "Tap Student RFID to continue";
            // 
            // l
            // 
            this.l.AutoSize = true;
            this.l.Font = new System.Drawing.Font("Inter Light", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l.ForeColor = System.Drawing.Color.White;
            this.l.Location = new System.Drawing.Point(257, 123);
            this.l.Name = "l";
            this.l.Size = new System.Drawing.Size(564, 136);
            this.l.TabIndex = 5;
            this.l.Text = "Library Laboratory Time\r\n Management  System";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(65, 110);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(186, 179);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // RFIDTextBox
            // 
            this.RFIDTextBox.Location = new System.Drawing.Point(299, 372);
            this.RFIDTextBox.Name = "RFIDTextBox";
            this.RFIDTextBox.Size = new System.Drawing.Size(424, 20);
            this.RFIDTextBox.TabIndex = 7;
            this.RFIDTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RFIDTextBox_KeyDown);
            // 
            // ScanRfidForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(64)))), ((int)(((byte)(43)))));
            this.ClientSize = new System.Drawing.Size(930, 625);
            this.Controls.Add(this.AdminRFIDScan);
            this.Controls.Add(this.l);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.RFIDTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ScanRfidForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label AdminRFIDScan;
        private System.Windows.Forms.Label l;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox RFIDTextBox;
    }
}