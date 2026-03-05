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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EvaluationAnswerForm));
            this.QuestionLabel = new System.Windows.Forms.Label();
            this.LikedBtn = new System.Windows.Forms.Button();
            this.DislikeBtn = new System.Windows.Forms.Button();
            this.ShadedDislikeBtn = new System.Windows.Forms.Button();
            this.ShadedLikeBtn = new System.Windows.Forms.Button();
            this.HeaderPanel = new System.Windows.Forms.Panel();
            this.SubmitBtn = new System.Windows.Forms.Button();
            this.EvaluationFormElipse = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.SubmitBtnElipse = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse3 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.CloseBtn = new System.Windows.Forms.Button();
            this.HeaderPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // QuestionLabel
            // 
            this.QuestionLabel.Font = new System.Drawing.Font("Roboto Condensed", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuestionLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.QuestionLabel.Location = new System.Drawing.Point(-2, 62);
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
            this.LikedBtn.Location = new System.Drawing.Point(182, 261);
            this.LikedBtn.Name = "LikedBtn";
            this.LikedBtn.Size = new System.Drawing.Size(75, 75);
            this.LikedBtn.TabIndex = 1;
            this.LikedBtn.UseVisualStyleBackColor = false;
            this.LikedBtn.Click += new System.EventHandler(this.LikedBtn_Click);
            // 
            // DislikeBtn
            // 
            this.DislikeBtn.BackColor = System.Drawing.Color.Transparent;
            this.DislikeBtn.FlatAppearance.BorderSize = 0;
            this.DislikeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DislikeBtn.Image = ((System.Drawing.Image)(resources.GetObject("DislikeBtn.Image")));
            this.DislikeBtn.Location = new System.Drawing.Point(388, 261);
            this.DislikeBtn.Name = "DislikeBtn";
            this.DislikeBtn.Size = new System.Drawing.Size(75, 75);
            this.DislikeBtn.TabIndex = 2;
            this.DislikeBtn.UseVisualStyleBackColor = false;
            this.DislikeBtn.Click += new System.EventHandler(this.DislikeBtn_Click);
            // 
            // ShadedDislikeBtn
            // 
            this.ShadedDislikeBtn.BackColor = System.Drawing.Color.Transparent;
            this.ShadedDislikeBtn.FlatAppearance.BorderSize = 0;
            this.ShadedDislikeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShadedDislikeBtn.Image = ((System.Drawing.Image)(resources.GetObject("ShadedDislikeBtn.Image")));
            this.ShadedDislikeBtn.Location = new System.Drawing.Point(388, 261);
            this.ShadedDislikeBtn.Name = "ShadedDislikeBtn";
            this.ShadedDislikeBtn.Size = new System.Drawing.Size(75, 75);
            this.ShadedDislikeBtn.TabIndex = 3;
            this.ShadedDislikeBtn.UseVisualStyleBackColor = false;
            this.ShadedDislikeBtn.Click += new System.EventHandler(this.ShadedDislikeBtn_Click);
            // 
            // ShadedLikeBtn
            // 
            this.ShadedLikeBtn.BackColor = System.Drawing.Color.Transparent;
            this.ShadedLikeBtn.FlatAppearance.BorderSize = 0;
            this.ShadedLikeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShadedLikeBtn.Image = ((System.Drawing.Image)(resources.GetObject("ShadedLikeBtn.Image")));
            this.ShadedLikeBtn.Location = new System.Drawing.Point(182, 261);
            this.ShadedLikeBtn.Name = "ShadedLikeBtn";
            this.ShadedLikeBtn.Size = new System.Drawing.Size(75, 75);
            this.ShadedLikeBtn.TabIndex = 4;
            this.ShadedLikeBtn.UseVisualStyleBackColor = false;
            this.ShadedLikeBtn.Click += new System.EventHandler(this.ShadedLikeBtn_Click);
            // 
            // HeaderPanel
            // 
            this.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(80)))), ((int)(((byte)(60)))));
            this.HeaderPanel.Controls.Add(this.CloseBtn);
            this.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.Size = new System.Drawing.Size(650, 59);
            this.HeaderPanel.TabIndex = 5;
            // 
            // SubmitBtn
            // 
            this.SubmitBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.SubmitBtn.FlatAppearance.BorderSize = 0;
            this.SubmitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SubmitBtn.Font = new System.Drawing.Font("Inter Medium", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubmitBtn.ForeColor = System.Drawing.SystemColors.Menu;
            this.SubmitBtn.Location = new System.Drawing.Point(430, 388);
            this.SubmitBtn.Name = "SubmitBtn";
            this.SubmitBtn.Size = new System.Drawing.Size(208, 51);
            this.SubmitBtn.TabIndex = 7;
            this.SubmitBtn.Text = "Submit answer";
            this.SubmitBtn.UseVisualStyleBackColor = false;
            this.SubmitBtn.Click += new System.EventHandler(this.SubmitBtn_Click);
            // 
            // EvaluationFormElipse
            // 
            this.EvaluationFormElipse.ElipseRadius = 20;
            this.EvaluationFormElipse.TargetControl = this;
            // 
            // SubmitBtnElipse
            // 
            this.SubmitBtnElipse.ElipseRadius = 5;
            this.SubmitBtnElipse.TargetControl = this.SubmitBtn;
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 20;
            this.bunifuElipse2.TargetControl = this;
            // 
            // bunifuElipse3
            // 
            this.bunifuElipse3.ElipseRadius = 20;
            this.bunifuElipse3.TargetControl = this;
            // 
            // CloseBtn
            // 
            this.CloseBtn.FlatAppearance.BorderSize = 0;
            this.CloseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseBtn.Image = ((System.Drawing.Image)(resources.GetObject("CloseBtn.Image")));
            this.CloseBtn.Location = new System.Drawing.Point(600, 1);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(46, 56);
            this.CloseBtn.TabIndex = 29;
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // EvaluationAnswerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(64)))), ((int)(((byte)(43)))));
            this.ClientSize = new System.Drawing.Size(650, 451);
            this.Controls.Add(this.SubmitBtn);
            this.Controls.Add(this.HeaderPanel);
            this.Controls.Add(this.QuestionLabel);
            this.Controls.Add(this.DislikeBtn);
            this.Controls.Add(this.LikedBtn);
            this.Controls.Add(this.ShadedLikeBtn);
            this.Controls.Add(this.ShadedDislikeBtn);
            this.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(7);
            this.Name = "EvaluationAnswerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.HeaderPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label QuestionLabel;
        private System.Windows.Forms.Button LikedBtn;
        private System.Windows.Forms.Button DislikeBtn;
        private System.Windows.Forms.Button ShadedDislikeBtn;
        private System.Windows.Forms.Button ShadedLikeBtn;
        private System.Windows.Forms.Panel HeaderPanel;
        private System.Windows.Forms.Button SubmitBtn;
        private Bunifu.Framework.UI.BunifuElipse EvaluationFormElipse;
        private Bunifu.Framework.UI.BunifuElipse SubmitBtnElipse;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse3;
        public System.Windows.Forms.Button CloseBtn;
    }
}