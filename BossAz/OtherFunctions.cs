using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BossAz
{
    public class OtherFunctions
    {
        /// <summary>
        /// Displays a "Not Found" message in red text on the console and prompts the user to try again.
        /// </summary>
        /// <param name="message">The specific item or resource that is not found.</param>
        public static void NotFound(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n{message} is not found. Please try again...\n");
            Console.ResetColor();
        }



        /// <summary>
        /// Clears the console screen and resets it.
        /// </summary>
        public static void MyClear() { Console.Clear(); Console.WriteLine("\x1b[3J"); }



        /// <summary>
        /// Displays a message prompting the user to press any key to continue.
        /// </summary>
        public static void PressAnyKey() { Console.WriteLine("\nPress any key for continue...\n"); Console.ReadLine(); }


        public static Worker GetCurrentWorker(string[] workerAccInfo, Database database)
        {
            if (database.Workers != null)
            {
                foreach(var worker in database.Workers) {
                    if(worker.UserName == workerAccInfo[0] && worker.Password == workerAccInfo[1]) { return worker;}
                }
            }
            throw new NullReferenceException("Workers list is empty");
        }


        public static Employer GetCurrentEmployer(string[] employerAccInfo, Database database)
        {
            if (database.Employers != null)
            {
                foreach (var employer in database.Employers)
                {
                    if (employer.UserName == employerAccInfo[0] && employer.Password == employerAccInfo[1]) { return employer; }
                }
            }
            throw new NullReferenceException("Employers list is empty");
        }



        public static string FormatPhoneNumber(string? phoneNumber)
        {

           return $"{phoneNumber.Substring(0, 3)} - {phoneNumber.Substring(3, 3)} - {phoneNumber.Substring(6, 2)} - {phoneNumber.Substring(8, 2)}";
        }

        public static int GetWorkExperince(List<Company> companies)
        {
            int exp = 0;
            foreach (var company in companies)
            {
                exp += company.EndDate.Year - company.StartDate.Year;
            }
            return exp;
        }
    }
}
