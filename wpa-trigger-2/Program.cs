using System;
using System.Diagnostics;
using System.Management;

namespace wpa_trigger_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Test run
            Console.WriteLine("Hello wpa-trigger!");
            // Process.Start("notepad.exe", "README.txt");

            var startInfo = new ProcessStartInfo();
            //startInfo.UseShellExecute = false;

            // Get path to "ProgramFiles"
            //string programFilesPath = startInfo.EnvironmentVariables["ProgramW6432"];

            //// fail safe, just in case the "ProgramW6432" environment variable is not set for some reason
            //if (String.IsNullOrEmpty(programFilesPath))
            //{
            //    programFilesPath = startInfo.EnvironmentVariables["PROGRAMFILES"];
            //}

            startInfo.Arguments = "";
            //startInfo.FileName = @"C:\Program Files\WindowsApps\Microsoft.WindowsPerformanceAnalyzerInternal_10.0.22549.0_x64__8wekyb3d8bbwe\10\Windows Performance Toolkit (Microsoft-Internal)\wpa.exe";
            //startInfo.FileName = @"C:\Program Files\WindowsApps\Microsoft.WindowsPerformanceAnalyzer_10.0.22621.0_x64__8wekyb3d8bbwe\10\Windows Performance Toolkit\wpa.exe";
            //startInfo.FileName = programFilesPath + @"\WindowsApps\Microsoft.WindowsPerformanceAnalyzer_10.0.22621.0_x64__8wekyb3d8bbwe\10\Windows Performance Toolkit\wpa.exe";
            startInfo.FileName = "wpa.exe";
            startInfo.WindowStyle = ProcessWindowStyle.Normal;

            using (var wpaProcess = Process.Start(startInfo))
            {
                wpaProcess.WaitForExit();

                int exitCode = wpaProcess.ExitCode;
            }

            Console.WriteLine("Goodbye wpa-trigger.");
        }
    }
}
