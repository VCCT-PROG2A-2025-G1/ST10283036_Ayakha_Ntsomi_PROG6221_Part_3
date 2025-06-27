using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;


namespace CyberSecurityBot
{
    partial class TaskAssistantForm : Form
    {
        private List<CyberTask> tasks = new List<CyberTask>();

        private readonly string logFilePath = "activity_log.txt";

        private TextBox txtTitle;
        private TextBox txtDescription;
        private CheckBox chkReminder;
        private DateTimePicker datePickerReminder;
        private ListBox lstTasks;
        private ListBox lstActivityLog;
        private Button btnAddTask;
        private Button btnMarkComplete;
        private Button btnDeleteTask;


        public TaskAssistantForm()
        {
            InitializeComponent();
            RefreshTaskList();
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            string Title = txtTitle.Text;
            string desc = txtDescription.Text;
            DateTime? reminder = chkReminder.Checked ? datePickerReminder.Value : (DateTime?)null;

            if (string.IsNullOrWhiteSpace(Title)) 
            {
                MessageBox.Show("Please enter a task title.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tasks.Exists(t => t.Title.Equals(Title, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("A task with this title already exists.", "Duplicate Task", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            tasks.Add(new CyberTask { Title = Title, Description = desc, Reminder = reminder });
            LogActivity($"Task Added: '{Title}\' with reminder: {(reminder.HasValue ? reminder.Value.ToString("g") : "None")}");
            RefreshTaskList();
            ClearInputs();
        }

        private void btnMarkComplete_Click(object sender, EventArgs e)
        {
            if (lstTasks.SelectedItem is CyberTask task)
            {
                task.isCompleted = true;
                LogActivity ($"Task marked complete: '{task.Title}'");
                RefreshTaskList();
            }
        }

        private void btnDeleteTask_Click(Object sender, EventArgs e)
        {
            if (lstTasks.SelectedItem is CyberTask task)
            {
                tasks.Remove(task);
                LogActivity ($"Task Deleted: '{task.Title}'");
                RefreshTaskList();
            }
        }

        private void RefreshTaskList()
        {
            lstTasks.DataSource = null;
            lstTasks.DataSource = tasks;
        }

        private void ClearInputs()
        {
            txtTitle.Text = "";
            txtDescription.Text = "";
            chkReminder.Checked = false;
            datePickerReminder.Value = DateTime.Now;
        }

        private void LogActivity (string message)
        {
            string logEntry = $"{DateTime.Now:HH:mm:ss} - {message}";
            
            try
            {
                File.AppendAllText(logFilePath, logEntry + Environment.NewLine);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to write to log file: " + ex.Message);
            }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtTitle = new TextBox();
            this.txtDescription = new TextBox();
            this.chkReminder = new CheckBox();
            this.datePickerReminder = new DateTimePicker();
            this.lstTasks = new ListBox();
            this.lstActivityLog = new ListBox();
            this.btnAddTask = new Button();
            this.btnMarkComplete = new Button();
            this.btnDeleteTask = new Button();

            this.SuspendLayout();

            // txtTitle
            this.txtTitle.Location = new System.Drawing.Point(30, 30);
            this.txtTitle.Size = new System.Drawing.Size(300, 23);
            this.txtTitle.PlaceholderText = "Enter Task Title";

            // txtDescription
            this.txtDescription.Location = new System.Drawing.Point(30, 70);
            this.txtDescription.Size = new System.Drawing.Size(300, 23);
            this.txtDescription.PlaceholderText = "Enter Description";

            // chkReminder
            this.chkReminder.Location = new System.Drawing.Point(30, 110);
            this.chkReminder.Text = "Set Reminder";
            this.chkReminder.CheckedChanged += (s, e) => datePickerReminder.Enabled = chkReminder.Checked;

            // datePickerReminder
            this.datePickerReminder.Location = new System.Drawing.Point(30, 140);
            this.datePickerReminder.Size = new System.Drawing.Size(300, 23);
            this.datePickerReminder.Enabled = false;

            // lstTasks
            this.lstTasks.Location = new System.Drawing.Point(350, 30);
            this.lstTasks.Size = new System.Drawing.Size(400, 300);

            // lstActivityLog
            this.lstActivityLog = new ListBox();
            this.lstActivityLog.Location = new System.Drawing.Point(30, 260);
            this.lstActivityLog.Size = new System.Drawing.Size(720, 100);
            this.lstActivityLog.Font = new System.Drawing.Font("Consolas", 9);

            // btnAddTask
            this.btnAddTask.Location = new System.Drawing.Point(30, 180);
            this.btnAddTask.Text = "Add Task";
            this.btnAddTask.Click += new EventHandler(btnAddTask_Click);

            // btnMarkComplete
            this.btnMarkComplete.Location = new System.Drawing.Point(150, 180);
            this.btnMarkComplete.Text = "Mark Complete";
            this.btnMarkComplete.Click += new EventHandler(btnMarkComplete_Click);

            // btnDeleteTask
            this.btnDeleteTask.Location = new System.Drawing.Point(270, 180);
            this.btnDeleteTask.Text = "Delete Task";
            this.btnDeleteTask.Click += new EventHandler(btnDeleteTask_Click);

            // TaskAssistantForm
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.chkReminder);
            this.Controls.Add(this.datePickerReminder);
            this.Controls.Add(this.lstTasks);
            this.Controls.Add(this.lstActivityLog);
            this.Controls.Add(this.btnAddTask);
            this.Controls.Add(this.btnMarkComplete);
            this.Controls.Add(this.btnDeleteTask);
            this.Text = "Cybersecurity Task Assistant";
            this.ResumeLayout(false);
        }

        #endregion
    }
}