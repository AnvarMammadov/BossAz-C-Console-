using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BossAz
{
    public static  class ErrorHandling
    {
        public static void LogError(string errorMessage)
        {
            string logFilePath = "error.log";
            string logMessage = $"{DateTime.Now} - Error: {errorMessage}";

            try
            {
                File.AppendAllText(logFilePath, logMessage + Environment.NewLine);
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Error while logging: {ex.Message}");
            }
        }

    }
}
