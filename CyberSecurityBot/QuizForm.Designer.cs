using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CyberSecurityBot
{
    partial class QuizForm : Form
    {
        private List<QuizQuestion> questions;
        private int currentQuestionIndex = 0;
        private int score = 0;

        private Label lblQuestion;
        private RadioButton[] optionButtons;
        private Button btnNext;
        private Label lblFeedback;

        public QuizForm()
        {
            InitializeComponent();
            SetUpOptionButtons();
            LoadQuestions();
            DisplayQuestion();
        }

        private void InitializeComponent()
        {
            this.lblQuestion = new Label();
            this.optionButtons = new RadioButton[4];
            this.btnNext = new Button();
            this.lblFeedback = new Label();

            // Form Styling
            this.Text = "Cybersecurity Quiz";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.WhiteSmoke;
            this.ClientSize = new Size(800, 350);
            this.Font = new Font("Segoe UI", 10);

            // lblQuestion
            this.lblQuestion.Location = new Point(30, 20);
            this.lblQuestion.Size = new Size(720, 60);
            this.lblQuestion.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblQuestion.ForeColor = Color.DarkBlue;
            this.lblQuestion.AutoSize = false;
            this.lblQuestion.TextAlign = ContentAlignment.MiddleLeft;
            this.Controls.Add(this.lblQuestion);

            // btnNext
            this.btnNext.Location = new Point(50, 270);
            this.btnNext.Size = new Size(120, 40);
            this.btnNext.Text = "Next ➡️";
            this.btnNext.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnNext.BackColor = Color.MediumSlateBlue;
            this.btnNext.ForeColor = Color.White;
            this.btnNext.FlatStyle = FlatStyle.Flat;
            this.btnNext.Click += new EventHandler(this.btnNext_Click);
            this.Controls.Add(this.btnNext);

            // lblFeedback
            this.lblFeedback.Location = new Point(160, 270);
            this.lblFeedback.Size = new Size(500, 40);
            this.lblFeedback.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            this.lblFeedback.ForeColor = Color.DarkBlue;
            this.lblFeedback.AutoSize = false;
            this.lblFeedback.TextAlign = ContentAlignment.MiddleLeft;
            this.Controls.Add(this.lblFeedback);

            // QuizForm
            this.ClientSize = new Size(800, 350);
            this.Controls.Add(this.lblQuestion);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.lblFeedback);
            this.Text = "CyberSecurity Quiz";
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void SetUpOptionButtons()
        {
            for (int i = 0; i < 4; i++)
            {
                optionButtons[i] = new RadioButton();
                optionButtons[i].Location = new Point(50, 100 + i * 40);
                optionButtons[i].Size = new Size(700, 30);
                optionButtons[i].Font = new Font("Segoe UI", 11F);
                optionButtons[i].ForeColor = Color.DimGray;
                optionButtons[i].FlatStyle = FlatStyle.Standard;
                this.Controls.Add(optionButtons[i]);
            }
        }

        private void LoadQuestions()
        {
            questions = new List<QuizQuestion>
            {

                new QuizQuestion 
                (
                    "What should you do if you receive an email asking for your password?",
                    new string[] { "Reply with your password", "Delete the email", "Report as phishing", "Ignore it" },
                    2
                ),
                new QuizQuestion
                (
                    "True or False: Public Wi-Fi is always safe to use for banking.",
                    new string[] { "True", "False", "", "" },
                    1
                ),
                new QuizQuestion
                (
                    "What is a strong password characteristic?",
                    new string[] { "Your name included", "At 12 characters with numbers and symbols", "Your birth date", "Simple words" },
                    1
                ),
                new QuizQuestion
                (
                    "What does two-factor authentication (2FA) do?",
                    new string[] {"Sends your password by email", "Adds an extra security step beyond password", "Allows password sharing", "Disables password requirement" },
                    1
                ),
                new QuizQuestion
                (
                    "Which of these is a sign of a phishing email?",
                    new string[] {"Official company logo", "Urgent language asking for personal info", "Correct spelling and grammar", "Personalized greeting" },
                    1
                ),
                new QuizQuestion
                (
                    "True or False: It's safe to use the same password for multiple accounts.",
                    new string[] { "True", "False", "", "" },
                    1
                ),
                new QuizQuestion
                (
                    "What should you do if receive a suspicious link?",
                    new string[] { "Click it immediately", "Ignore and delete the message", "Forward to friends", "Reply asking for details" },
                    1
                ),
                new QuizQuestion
                (
                    "What is good practice when browsing online?",
                    new string[] { "Use HTTP sites", "Download files from any site", "Look for HTTPS and secure connections", "Disable antivirus software" },
                    2
                ),
                new QuizQuestion
                (
                    "What is social engineering?",
                    new string[] { "A type of cybersecurity software", "Manipulating people to get confidential info", "Building social media profiles", "None of the above"},
                    1
                ),
                new QuizQuestion
                (
                    "True or False: You should update your software regularly.",
                    new string[] { "True", "False", "", "" },
                    0
                )
            };
        }

        private void DisplayQuestion()
        {
            if (currentQuestionIndex >= questions.Count)
            {
                ShowFinalScore();
                return;
            }

            var question = questions[currentQuestionIndex];
            lblQuestion.Text = $"Q{currentQuestionIndex + 1}: {question.QuestionText}";

            for (int i = 0; i < optionButtons.Length; i++)
            {
                if (i < question.Options.Length && !string.IsNullOrEmpty(question.Options[i]))
                {
                    optionButtons[i].Text = question.Options[i];
                    optionButtons[i].Visible = true;
                    optionButtons[i].Checked = false;
                    optionButtons[i].Enabled = true;
                }
                else
                {
                    optionButtons[i].Visible = false;
                }
            }

            lblFeedback.Text = "";
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            var question = questions[currentQuestionIndex];
            int selectedOption = Array.FindIndex(optionButtons, b => b.Checked);

            if (selectedOption != -1)
            {
                MessageBox.Show("Please select an answer before continuing.");
                return;
            }

            foreach (var btn in optionButtons)
                btn.Enabled = false;

            if (selectedOption == question.CorrectOptionIndex)
            {
                score++;
                lblFeedback.Text = "✅ Correct!";
                lblFeedback.ForeColor = Color.Green;
            }
            else
            {
                lblFeedback.Text = $"❎ Incorrect! The Correct answer is: {question.Options[question.CorrectOptionIndex]}";
                lblFeedback.ForeColor = Color.Red;
            }

            currentQuestionIndex++;

            System.Windows.Forms.Timer delayTimer = new System.Windows.Forms.Timer();
            delayTimer.Interval = 1500;
            delayTimer.Tick += (s, ev) =>
            {
                delayTimer.Stop();
                DisplayQuestion();
            };
            delayTimer.Start();
        }

        private void ShowFinalScore()
        {
            int totalQuestions = questions.Count;
            double percentage = (double)score / totalQuestions * 100;
            string message  = $"Quiz Complete!\n\n" +
                              $"Score: {score}/{totalQuestions}\n" +
                              $"Percentage: {percentage:F1}%\n\n";

            if (percentage == 100)
            {
                message += "Perfect! You're a cybersecurity pro!";
            }
            else if (percentage >= 80)
            {
                message = "Well done! You have a strong understanding of cybersecurity.";
            }
            else if (percentage >= 50)
            {
                message += "Not bad! You're getting there";
            }
            else
            {
                message += "Keep learning to stay safe online!";
            }

            MessageBox.Show(message, "Quiz completed");
            this.Close();
        }
    }
}