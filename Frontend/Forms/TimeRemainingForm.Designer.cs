namespace LibraryComputerLaboratoryTimeManagementSystemStudent.Frontend.Forms
{
    partial class TimeRemainingForm
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
            this.FullNameLabel = new System.Windows.Forms.Label();
            this.CourseLabel = new System.Windows.Forms.Label();
            this.CurrentDateLabel = new System.Windows.Forms.Label();
            this.StudentTimeLabel = new System.Windows.Forms.Label();
            this.TerminateSessionBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FullNameLabel
            // 
            this.FullNameLabel.AutoSize = true;
            this.FullNameLabel.Font = new System.Drawing.Font("Roboto Medium", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FullNameLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FullNameLabel.Location = new System.Drawing.Point(13, 13);
            this.FullNameLabel.Name = "FullNameLabel";
            this.FullNameLabel.Size = new System.Drawing.Size(106, 25);
            this.FullNameLabel.TabIndex = 0;
            this.FullNameLabel.Text = "Full Name";
            // 
            // CourseLabel
            // 
            this.CourseLabel.AutoSize = true;
            this.CourseLabel.Font = new System.Drawing.Font("Roboto Medium", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CourseLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.CourseLabel.Location = new System.Drawing.Point(13, 50);
            this.CourseLabel.Name = "CourseLabel";
            this.CourseLabel.Size = new System.Drawing.Size(79, 25);
            this.CourseLabel.TabIndex = 1;
            this.CourseLabel.Text = "Course";
            // 
            // CurrentDateLabel
            // 
            this.CurrentDateLabel.AutoSize = true;
            this.CurrentDateLabel.Font = new System.Drawing.Font("Roboto Medium", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentDateLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.CurrentDateLabel.Location = new System.Drawing.Point(13, 86);
            this.CurrentDateLabel.Name = "CurrentDateLabel";
            this.CurrentDateLabel.Size = new System.Drawing.Size(130, 25);
            this.CurrentDateLabel.TabIndex = 2;
            this.CurrentDateLabel.Text = "Current Date";
            // 
            // StudentTimeLabel
            // 
            this.StudentTimeLabel.AutoSize = true;
            this.StudentTimeLabel.Font = new System.Drawing.Font("Roboto Medium", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StudentTimeLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.StudentTimeLabel.Location = new System.Drawing.Point(122, 129);
            this.StudentTimeLabel.Name = "StudentTimeLabel";
            this.StudentTimeLabel.Size = new System.Drawing.Size(141, 38);
            this.StudentTimeLabel.TabIndex = 3;
            this.StudentTimeLabel.Text = "00:00:00";
            // 
            // TerminateSessionBtn
            // 
            this.TerminateSessionBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.TerminateSessionBtn.FlatAppearance.BorderSize = 0;
            this.TerminateSessionBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TerminateSessionBtn.Font = new System.Drawing.Font("Inter Medium", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TerminateSessionBtn.ForeColor = System.Drawing.SystemColors.Menu;
            this.TerminateSessionBtn.Location = new System.Drawing.Point(88, 187);
            this.TerminateSessionBtn.Name = "TerminateSessionBtn";
            this.TerminateSessionBtn.Size = new System.Drawing.Size(208, 38);
            this.TerminateSessionBtn.TabIndex = 4;
            this.TerminateSessionBtn.Text = "Terminate";
            this.TerminateSessionBtn.UseVisualStyleBackColor = false;
            this.TerminateSessionBtn.Click += new System.EventHandler(this.TerminateSessionBtn_Click);
            // 
            // TimeRemainingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(64)))), ((int)(((byte)(43)))));
            this.ClientSize = new System.Drawing.Size(400, 250);
            this.Controls.Add(this.TerminateSessionBtn);
            this.Controls.Add(this.StudentTimeLabel);
            this.Controls.Add(this.CurrentDateLabel);
            this.Controls.Add(this.CourseLabel);
            this.Controls.Add(this.FullNameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TimeRemainingForm";
            this.Text = "TimeRemainingForm";
            this.Load += new System.EventHandler(this.TimeRemainingForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label FullNameLabel;
        private System.Windows.Forms.Label CourseLabel;
        private System.Windows.Forms.Label CurrentDateLabel;
        private System.Windows.Forms.Label StudentTimeLabel;
        private System.Windows.Forms.Button TerminateSessionBtn;
    }
}