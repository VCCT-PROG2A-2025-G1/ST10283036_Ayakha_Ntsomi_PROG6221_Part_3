using System;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CyberSecurityBot
{
    partial class NLPForm : Form
    {
        private TextBox txtUserInput;
        private Button btnSend;
        private ListBox lstConversation;

        private string userName;
        private List<string> activityLog = new List<string>(); // Activity log 
        public NLPForm (string userName)
        {
            this.userName = string.IsNullOrWhiteSpace(userName) ? "Guest" : userName;
            InitializeComponent();
            this.Text = $"CyberSecurity ChatBot - NLP Simulation ({this.userName})";
        }

        private void InitializeComponent()
        {
            txtUserInput = new TextBox();
            btnSend = new Button();
            lstConversation = new ListBox();
            SuspendLayout();
            // 
            // txtUserInput
            // 
            txtUserInput.Location = new Point(12, 310);
            txtUserInput.Size = new Size(450, 31);
            txtUserInput.KeyDown += TxtUserInput_KeyDown;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(478, 310);
            btnSend.Size = new Size(90, 31);
            btnSend.Text = "Send";
            btnSend.Click += BtnSend_Click;
            // 
            // lstConversation
            // 
            lstConversation.FormattingEnabled = true;
            lstConversation.ItemHeight = 25;
            lstConversation.Location = new Point(12, 11);
            lstConversation.Size = new Size(550, 280);
            // 
            // NLPForm
            // 
            ClientSize = new Size(580, 350);
            Controls.Add(lstConversation);
            Controls.Add(txtUserInput);
            Controls.Add(btnSend);
            Name = "NLPForm";
            ResumeLayout(false);
            PerformLayout();
        }

        private void BtnSend_Click (object sender, EventArgs e)
        {
            ProcessUserInput(txtUserInput.Text.Trim());
        }

        private void TxtUserInput_KeyDown (object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                ProcessUserInput(txtUserInput.Text.Trim());
            }
        }

        private void ProcessUserInput (string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return;

            lstConversation.Items.Add($"User: {input}");
            txtUserInput.Clear();

            string response = GenerateResponse(input.ToLower());
            lstConversation.Items.Add($"Bot: {response}");

            lstConversation.TopIndex = lstConversation.Items.Count - 1;
        }

        private string GenerateResponse (string input)
        {
            DateTime now = DateTime.Now;

            // === Activity Log Command ===
            if (input.Contains("show activity log") || input.Contains("what have you done") || input.Contains("display log"))
            {
                if (activityLog.Count == 0)
                    return "No activity logged yet.";

                var recent = activityLog.TakeLast(5).Reverse().ToList();
                return "Here's a summary of recent actions:\n" + string.Join("\n", recent.Select((entry, i) => $"{i + 1}. {entry}"));
            }

            // === NLP Keyword Responses ===
            if (input.Contains("phishing"))
            {
                LogActivity($"Explained phishing ({now:HH:mm})");
                return "Phishing is an attempt to steal persnal information by pretending to be someone trustworthy. Always verify emails carefully.";
            }

            if (input.Contains("password"))
            {
                LogActivity($"Gave password advice ({now:HH:mm})");
                return "Make sure to use strong passwords with a mix of letters, numbers, and symbols. Avoid reusing passwords across sites.";
            }

            if (input.Contains("two-factor authentication") || input.Contains("2fa"))
            {
                LogActivity($"Explained 2FA ({now:HH:mm})");
                return "Two-factor authentication adds an extra layer of security by requiring a second form of verification besides your password.";
            }

            if (input.Contains("privacy"))
            {
                LogActivity($"Discussed privacy settings ({now:HH:mm})");
                return "Protect your privacy by managing social media settings and being cautious about what information you share online.";
            }

            if (input.Contains("firewall"))
            {
                LogActivity($"Talked about firewalls ({now:HH:mm})");
                return "Firewalls help protect your computer from unauthorized access. Keep your firewall enabled at all times.";
            }

            // Task Reminder
            if (input.Contains("remind") || input.Contains("reminder") || input.Contains("task") || input.Contains("note"))
            {
                string task = ExtractTaskDescription(input);
                if (!string.IsNullOrEmpty(task))
                {
                    string log = $"Task added: \"{task}\" ({now:HH:mm})";
                    LogActivity(log);
                    return $"Task added: \"{task}\". I'll remind you!";
                }
                return "Sure! What should I remind you about?";
            }

            // === Quiz Handling ===
            if (input.Contains("quiz") || input.Contains("questions") || input.Contains("start quiz") || input.Contains("test"))
            {
                LogActivity($"Quiz started ({now:HH:mm})");
                return "Great! Starting the cybersecurity quiz... (You can open the quiz window now.)";
            }

            // === Default Response ===
            LogActivity($"Unhandled input processed ({now:HH:mm})");
            return "I'm still learning! Try asking about phishing, 2FA, or say 'add a task to update my password'.";
        }

        private void LogActivity (string entry)
        {
            if (activityLog.Count >= 100)
                activityLog.RemoveAt(0);
            activityLog.Add(entry);
        }

        private string ExtractTaskDescription(string input)
        {
            var match = Regex.Match(input, @"(remind me to|add a task to|note to self to|set a reminder to) (.+)", RegexOptions.IgnoreCase);
            if (match.Success & match.Groups.Count > 2)
                return match.Groups[2].Value.Trim();

            return string.Empty;
        }
    }
}

