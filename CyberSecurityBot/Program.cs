using System;
using System.Media;
using System.Runtime.Versioning;

namespace CyberSecurityBot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (OperatingSystem.IsWindows()) 
            {
                PlayGreetingAudio();
            }
      
            ConsoleUI.PrintAsciiArt();
            ConsoleUI.DisplayWelcome();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nWhat's your name? ");
            Console.ResetColor();

            string? userName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(userName)) 
            {
                userName = "Guest";
            }
            
            Console.WriteLine();
            ConsoleUI.TypeEffect($"Welcome, {userName}! I'm your Cyybersecurity Awareness Bot.\n");

            CyberBot bot = new CyberBot(userName);

            while (true) 
            {
                ConsoleUI.PrintDivider();
                ConsoleUI.PrintPrompt("Ask me a question (type 'exit' to quit): ");
                string? input = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(input)) 
                {
                    ConsoleUI.TypeEffect("Please enter something!\n");
                    continue;
                }

                if (input.Equals("exit, StringComparison.OrdinalIgnoreCase")) 
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    ConsoleUI.TypeEffect("Goodbye! Stay safe online!\n");
                    Console.ResetColor();
                    break;
                }

                string response = bot.GetResponse(input);
                ConsoleUI.PrintBotResponse(response);
            }
        }

        static void PlayGreetingAudio() 
        {
            try
            {
                var player = new System.Media.SoundPlayer("greeting.wav");
                player.PlaySync();
            }
            catch (Exception ex) 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error playing greeting: " + ex.Message);
                Console.ResetColor();
            }
        }
    }
}
