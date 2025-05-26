using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurityBot
{
    internal class ConsoleUI
    {
        public static void PrintAsciiArt() 
        {
            try 
            {
                string ascii = File.ReadAllText("ascii.txt");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(ascii);
                Console.ResetColor();
            }
            catch 
            {
                Console.WriteLine("Cybersecurity Awareness Bot\n");
            }
        }

        public static void DisplayWelcome() 
        {
            Console.ForegroundColor= ConsoleColor.Blue;
            Console.WriteLine("================================================");
            Console.WriteLine("  Welcome to the Cybersecurity Awareness Bot  ");
            Console.WriteLine("================================================");
            Console.ResetColor();
        }

        public static void TypeEffect(string message, int delay = 25) 
        {
            foreach (char c in message) 
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
            Console.WriteLine();
        }

        public static void PrintDivider() 
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("------------------------------------------------");
            Console.ResetColor();
        }

        public static void PrintPrompt(string message) 
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(message);
            Console.ResetColor();
        }

        public static void PrintBotResponse(string response) 
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("CyberBot: ");
            Console.ResetColor();
            TypeEffect(response);
        }
    }
}
