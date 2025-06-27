using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurityBot
{
    internal class CyberTask
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty ;
        public DateTime? Reminder {  get; set; }
        public bool isCompleted { get; set; }

        public CyberTask() { }

        public CyberTask (string title, string description, DateTime? reminder = null)
        {
            Title = title;
            Description = description;
            Reminder = reminder;
            isCompleted = true;
        }

        public override string ToString()
        {
            string status = isCompleted ? "✅" : "❎";
            string reminderText = Reminder.HasValue ? $"(Reminder: {Reminder.Value.ToShortDateString()}" : "";
            return $"{status} {Title} - {Description} {reminderText}";
        }
    }
}
