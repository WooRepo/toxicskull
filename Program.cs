using System;
using System.Diagnostics;
using System.Linq;

namespace ToxicSkullControl
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Usage: toxicskull.exe <on|off|help>");
                return;
            }

            string command = args[0].ToLower();

            switch (command)
            {
                case "on":
                    RunKeystroke();
                    break;

                case "off":
                    KillKeystroke();
                    break;

                case "help":
                    DisplayHelp();
                    break;

                default:
                    Console.WriteLine("Invalid command. Usage: toxicskull.exe <on|off|help>");
                    break;
            }
        }

        private static void RunKeystroke()
        {
            try
            {
                string skullPath = "skull.exe";

                Process.Start(new ProcessStartInfo
                {
                    FileName = skullPath,
                    UseShellExecute = true
                });

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The keystroke is now running. To type a skull emoji, press Ctrl+Alt+S.");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error starting keystroke: {ex.Message}");
            }
        }

        private static void KillKeystroke()
        {
            try
            {
                var processes = Process.GetProcessesByName("skull");
                if (!processes.Any())
                {
                    Console.WriteLine("Keystroke is not running. Press Help for more info.");
                    return;
                }

                foreach (var process in processes)
                {
                    process.Kill();
                    process.WaitForExit();
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Keystroke has been stopped. Thank you for using ToxicSkull!");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error stopping keystroke: {ex.Message}");
            }
        }

        private static void DisplayHelp()
        {
            Console.WriteLine("Usage: toxicskull.exe <on|off|help>");
            Console.WriteLine("  on   - Starts the keystroke.");
            Console.WriteLine("  off  - Stops the running keystroke.");
            Console.WriteLine("  help - Displays this help message.");
        }
    }
}
