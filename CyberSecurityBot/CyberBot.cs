using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurityBot
{
    internal class CyberBot
    {
        private string userName;

        public CyberBot(String name) 
        {
            userName = name ?? "Guest";
        }

        public string GetResponse(string question) 
        {
            string q = question.ToLower();

            if (q.Contains("how are you?"))
                return "I'm secure and ready to assist you!";
            if (q.Contains("purpose"))
                return "I'm here to educate you on cybersecurity awareness.";
            if (q.Contains("what can") && q.Contains("ask"))
                return "You can ask about password safety, phishing, or safe browsing.";

            if (q.Contains("password"))
                return "Always use a string password with atleast 12 characters with symbols and numbers.";
            if (q.Contains("phishing"))
                return "Be cautious of unexpected emails and links, verify before clicking!";
            if (q.Contains("browsing"))
                return "Stick to secure websites (HTTPS), and avoid suspicious downloads.";

            return "I didn't quite understand that. Could you rephrase?";
        }
    }
}
