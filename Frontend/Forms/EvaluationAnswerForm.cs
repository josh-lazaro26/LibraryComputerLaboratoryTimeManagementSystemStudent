using LibraryComputerLaboratoryTimeManagementSystemStudent.Frontend.Services.StudentServices;
using Newtonsoft.Json.Linq;
using System;
using System.Windows.Forms;

namespace LibraryComputerLaboratoryTimeManagementSystemStudent.Frontend.Forms
{
    public partial class EvaluationAnswerForm : Form
    {
        private readonly StudentServices _studentServices;
        private string _evaluationId;
        private string _selectedEvaluationType; // "like" or "dislike"

        public EvaluationAnswerForm()
        {
            InitializeComponent();
            _studentServices = new StudentServices();
            this.Load += EvaluationAnswerForm_Load;
        }

        private async void EvaluationAnswerForm_Load(object sender, EventArgs e)
        {
            // Show shaded/unshaded defaults — nothing selected yet
            SetLikeSelected(false);
            SetDislikeSelected(false);

            try
            {
                JObject evaluation = await _studentServices.GetLatestEvaluationAsync();

                if (evaluation == null)
                {
                    MessageBox.Show("No evaluation found.", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    return;
                }

                _evaluationId = evaluation["id"]?.ToString();
                QuestionLabel.Text = evaluation["question"]?.ToString() ?? "How was your session today?";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading evaluation: {ex.Message}");
                MessageBox.Show("Failed to load evaluation.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }


        /// <summary>
        /// Shows ShadedLikeBtn when selected, LikedBtn when not selected.
        /// </summary>
        private void SetLikeSelected(bool selected)
        {
            LikedBtn.Visible = !selected;
            ShadedLikeBtn.Visible = selected;
        }

        /// <summary>
        /// Shows ShadedDislikeBtn when selected, DislikeBtn when not selected.
        /// </summary>
        private void SetDislikeSelected(bool selected)
        {
            DislikeBtn.Visible = !selected;
            ShadedDislikeBtn.Visible = selected;
        }

        private async void SubmitBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_selectedEvaluationType))
            {
                MessageBox.Show("Please select an answer before submitting.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrWhiteSpace(_evaluationId))
            {
                MessageBox.Show("Evaluation ID is missing.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                SubmitBtn.Enabled = false;

                bool success = await _studentServices.AnswerEvaluationAsync(
                    id: _evaluationId,
                    comment: "",                      // no comment field in UI, pass empty
                    evaluationType: _selectedEvaluationType
                );

                if (success)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to submit evaluation. Please try again.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SubmitBtn.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error submitting evaluation: {ex.Message}");
                MessageBox.Show("An error occurred while submitting.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                SubmitBtn.Enabled = true;
            }
        }

        private void ShadedDislikeBtn_Click(object sender, EventArgs e)
        {
            _selectedEvaluationType = null;
            SetLikeSelected(false);
            SetDislikeSelected(false);
        }

        private void ShadedLikeBtn_Click(object sender, EventArgs e)
        {
            _selectedEvaluationType = null;
            SetLikeSelected(false);
            SetDislikeSelected(false);
        }

        private void LikedBtn_Click(object sender, EventArgs e)
        {
            _selectedEvaluationType = "Liked";
            SetLikeSelected(true);
            SetDislikeSelected(false);
        }

        private void DislikeBtn_Click(object sender, EventArgs e)
        {
            _selectedEvaluationType = "Disliked";
            SetLikeSelected(false);
            SetDislikeSelected(true);
        }
    }
}