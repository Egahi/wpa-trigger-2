using System;
using System.Diagnostics;
using System.Windows;

namespace wpa_trigger_2
{
    internal class Program
    {
        const string WPA = "wpa.exe";
        const string WPA_NOT_FOUND_CAPTION = "WPA not found!";
        const string WPA_NOT_FOUND_ERROR_MESSAGE =
            "Windows Performance Analyzer (WPA) not found. " +
            "Kindly install it from the Microsoft store.";

        static void Main(string[] args)
        {
            Console.WriteLine("Hello wpa-trigger!");

            var startInfo = new ProcessStartInfo()
            {
                Arguments = "",
                FileName = WPA,
                WindowStyle = ProcessWindowStyle.Normal
            };

            try
            {
                using (var wpaProcess = Process.Start(startInfo))
                {
                    wpaProcess.WaitForExit();

                    int exitCode = wpaProcess.ExitCode;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());

                MessageBox.Show(WPA_NOT_FOUND_ERROR_MESSAGE, WPA_NOT_FOUND_CAPTION,
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }

            Console.WriteLine("Goodbye wpa-trigger.");
        }
    }
}
