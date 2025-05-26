using Microsoft.VisualBasic.Devices;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurityBot
{
    internal class CyberBot
    {
        private string userName;
        private Dictionary<string, List<string>> keywordResponses;
        private Random random;
        private string? lastTopic = null;
        private string? favoriteTopic = null;

        public CyberBot(String name)
        {
            userName = name ?? "Guest";
            random = new Random();

            keywordResponses = new Dictionary<string, List<string>>
            {
                { "password", new List<string>
                    {
                        "Use a strong password at least 12 characters including symbols and numbers.",
                        "Avoid using your name or birth date in passwords.",
                        "Consider using a password manager for better security."
                    }
                },
                { "phishing", new List<string>
                    {
                        "Never click links in emails from unknown senders.",
                        "Phishing emails often have grammar mistakes or urgent language.",
                        "Verify the sender's email address before responding."
                    }
                },
                { "privacy", new List<string>
                    {
                        "Review your social media privacy settings regularly.",
                        "Avoid sharing sensitive personal info online.",
                        "Use incognito mode and disable tracking when browsing."
                    }
                },
                { "scam", new List<string>
                    {
                        "Scammers often impersonate trusted brands.",
                        "If it seems too good to be true, it probably is.",
                        "Report scams to your local cybercrime authority."
                    }
                },
                { "browsing", new List<string>
                    {
                        "Use HTTPS websites only.",
                        "Don't download files from untrusted sites.",
                        "Enable browser security extensions like HTTPS everywhere."
                    }
                }
            };
        }

        public string GetResponse(string question)
        {
            try
            {
                if (string.IsNullOrEmpty(question))
                    return "Please enter a valid question.";

                string q = question.ToLower();

                if (q.Contains("how are you?"))
                    return "I'm secure and ready to assist you!";
                if (q.Contains("purpose"))
                    return "I'm here to educate you on cybersecurity awareness.";
                if (q.Contains("what can") && q.Contains("ask"))
                    return "You can ask about password safety, phishing, or safe browsing.";

                if (q.Contains("worried") || q.Contains("anxious") || q.Contains("scared"))
                    return "It's completely understandable to feel that way. Scammers can be very convincing. I'm here to help you stay safe online.";

                if (q.Contains("frustrated") || q.Contains("confused"))
                    return "No worries! Cybersecurity can feel overwhelming at first, but I'm here to explain things clearly. Ask me anything.";

                if (q.Contains("curious") || q.Contains("interested"))
                    return "Curiosity is a great mindset for learning cybersecurity. Let me know what you'd like to explore!";

                if ((q.Contains("more") || q.Contains("again") || q.Contains("why")) && lastTopic != null)
                {
                    var responses = keywordResponses[lastTopic];
                    return responses[random.Next(responses.Count)];
                }


                if (q.Contains("i'm interested in"))
                {
                    foreach (var keyword in keywordResponses.Keys)
                    {
                        if (q.Contains(keyword))
                        {
                            favoriteTopic = keyword;
                            return $"Great! I'll remember that you're interested in {keyword}. It's a crucial part of staying safe online.";
                        }
                    }

                    return "That's a great interest! Could you be more specific like 'I'm interested in phishing' or 'privacy'?";
                }

                foreach (var keyword in keywordResponses.Keys)
                {
                    if (q.Contains(keyword))
                    {
                        lastTopic = keyword;
                        var responses = keywordResponses[keyword];
                        return responses[random.Next(responses.Count)];
                    }
                }

                if (q.Contains("remind me") && favoriteTopic != null)
                {
                    return $"As someone interested in {favoriteTopic}, you might want to learn about it. Want a tip?";
                }

                return "I didn't quite understand that. Could you rephrase?";

            }
            catch (IOException ex)
            {
                return $"Oops, something went wrong: {ex.Message}";
            }
        }

        private string GetRandomResponse(string topic) 
        {
            if (keywordResponses.TryGetValue(topic, out var responses)) 
            {
                return responses[random.Next(responses.Count)];
            }
            return "I'm not sure how to respond to that.";
        }
    }
}
