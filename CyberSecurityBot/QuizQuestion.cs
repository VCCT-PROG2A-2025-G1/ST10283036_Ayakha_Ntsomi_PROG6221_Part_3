using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurityBot
{
    internal class QuizQuestion
    {
        public string QuestionText {  get; set; }
        public string[] Options { get; set; }
        public int CorrectOptionIndex { get; set; }

        public QuizQuestion (string questionText, string[] options, int correctOptionIndex)
        {
            QuestionText = questionText;
            Options = options;
            CorrectOptionIndex = correctOptionIndex;
        }
    }
}
