using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Threading;

namespace WIFI_password_Viewer
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Title = "WIFI Password Viewer";

            //This gets the list of proflies
            string profilesOutput = RunCommand("netsh", "wlan show profiles");
            List<string> wifiNames = new List<string>();

            string[] lines = profilesOutput.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines)
            {
                string[] parts = line.Split(':');
                if (parts.Length >= 2)
                {
                    string label = parts[0].Trim();
                    string value = parts[1].Trim();
    
                    if (!string.IsNullOrEmpty(label) && !string.IsNullOrEmpty(value))
                    {
                        wifiNames.Add(value);
                    }
                }
            }

            //This will display the list with numbers
            Console.WriteLine("Available Wifi Profiles:\n");
            for (int i = 0; i < wifiNames.Count; i++)
             {
                    Console.WriteLine($"[{i + 1}] {wifiNames[i]}");
                 }

            //This will ask the user for input
            Console.WriteLine("\nChoose Wifi number: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int choice) && choice > 0 && choice <= wifiNames.Count)
                 {
                    string selectedWifi = wifiNames[choice - 1];

             //This will get the password

                    string result = RunCommand("netsh", $"wlan show profile name=\"{selectedWifi}\" key=clear");

                //This will display the result
                    Console.WriteLine("\n" + result);
                 }
                 else
                 {
                      Console.WriteLine("Invalid selection. ");

                 }
                    Console.WriteLine("\nPress any key to exit...");
                    Console.ReadKey();
                 }

        static string RunCommand(string command, string arguments)
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = command,
                Arguments = arguments,
                RedirectStandardOutput = true, //we want to catch the text output
                UseShellExecute = false, //This is required to redirect output
                CreateNoWindow = true // This will not the black command prompt window
            };

            using (Process process = Process.Start(psi))
            {
                using (System.IO.StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    return result;
                }
            }
        }
    }
}
