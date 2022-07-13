using System;
using System.Collections.Specialized;
using System.Deployment.Application;
using System.Diagnostics;
using System.Web;
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

            var queryStrings = GetQueryStringParameters();

            foreach (var key in queryStrings.Keys)
            {
                Console.WriteLine(key);
            }

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

        /// <summary>
        /// Get Query String Parameters
        /// Credit - https://docs.microsoft.com/en-us/visualstudio/deployment/how-to-retrieve-query-string-information-in-an-online-clickonce-application?view=vs-2022&tabs=csharp#to-obtain-query-string-information-from-a-clickonce-application
        /// </summary>
        /// <returns></returns>
        private static NameValueCollection GetQueryStringParameters()
        {
            NameValueCollection nameValueTable = new NameValueCollection();

            if (ApplicationDeployment.IsNetworkDeployed)
            {
                string queryString = ApplicationDeployment.CurrentDeployment.ActivationUri.Query;
                nameValueTable = HttpUtility.ParseQueryString(queryString);
            }

            return (nameValueTable);
        }
    }
}
