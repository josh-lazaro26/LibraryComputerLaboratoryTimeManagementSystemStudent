namespace LibraryComputerLaboratoryTimeManagementSystemStudent.Frontend.Forms
{
    partial class EvaluationAnswerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EvaluationAnswerForm));
            this.QuestionLabel = new System.Windows.Forms.Label();
            this.LikedBtn = new System.Windows.Forms.Button();
            this.DislikeBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // QuestionLabel
            // 
            this.QuestionLabel.Font = new System.Drawing.Font("Roboto Condensed", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuestionLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.QuestionLabel.Location = new System.Drawing.Point(-1, 57);
            this.QuestionLabel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.QuestionLabel.Name = "QuestionLabel";
            this.QuestionLabel.Size = new System.Drawing.Size(652, 76);
            this.QuestionLabel.TabIndex = 0;
            this.QuestionLabel.Text = "Question";
            this.QuestionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LikedBtn
            // 
            this.LikedBtn.BackColor = System.Drawing.Color.Transparent;
            this.LikedBtn.FlatAppearance.BorderSize = 0;
            this.LikedBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LikedBtn.Image = ((System.Drawing.Image)(resources.GetObject("LikedBtn.Image")));
            this.LikedBtn.Location = new System.Drawing.Point(192, 232);
            this.LikedBtn.Name = "LikedBtn";
            this.LikedBtn.Size = new System.Drawing.Size(94, 91);
            this.LikedBtn.TabIndex = 1;
            this.LikedBtn.UseVisualStyleBackColor = false;
            // 
            // DislikeBtn
            // 
            this.DislikeBtn.BackColor = System.Drawing.Color.Transparent;
            this.DislikeBtn.FlatAppearance.BorderSize = 0;
            this.DislikeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DislikeBtn.Image = ((System.Drawing.Image)(resources.GetObject("DislikeBtn.Image")));
            this.DislikeBtn.Location = new System.Drawing.Point(359, 232);
            this.DislikeBtn.Name = "DislikeBtn";
            this.DislikeBtn.Size = new System.Drawing.Size(94, 91);
            this.DislikeBtn.TabIndex = 2;
            this.DislikeBtn.UseVisualStyleBackColor = false;
            // 
            // EvaluationAnswerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(64)))), ((int)(((byte)(43)))));
            this.ClientSize = new System.Drawing.Size(650, 360);
            this.Controls.Add(this.DislikeBtn);
            this.Controls.Add(this.LikedBtn);
            this.Controls.Add(this.QuestionLabel);
            this.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.Name = "EvaluationAnswerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label QuestionLabel;
        private System.Windows.Forms.Button LikedBtn;
        private System.Windows.Forms.Button DislikeBtn;
    }
}