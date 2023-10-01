using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace BossAz
{
    public class UI_Functions
    {
        /// <summary>
        /// Displays the main menu of the application, allowing the user to choose between worker, employer, or exiting the application.
        /// </summary>
        public static void AppMenu()
        {
            Console.WriteLine("\t\t\t\t = = = B O S S . A Z = = = \n\n\n");
            Console.WriteLine("Worker    [1]");
            Console.WriteLine("Employer  [2]");
            Console.WriteLine("\nExit      [0]\n");
        }



        /// <summary>
        /// Prompts the user to enter a username and password via the console and returns them as an array of two strings.
        /// </summary>
        /// <returns>An array containing the username and password entered by the user.</returns>
        public static string[] GetUserNameAndPass()
        {
            string[] userAccountInfo = new string[2];
            Console.Write("Enter username : ");
            userAccountInfo[0] = Console.ReadLine().Trim();
            Validation.CheckName(userAccountInfo[0]);
            Console.Write("Enter password : ");
            userAccountInfo[1] = Console.ReadLine().Trim();
            Validation.CheckName(userAccountInfo[1]);

            return userAccountInfo;
        }

        public static void ShowWorkerMenu(Worker worker)
        {
            int notCount = worker.Notifications.Count;
            Console.WriteLine("Announcements         [1]");
            Console.WriteLine("Search                [2]");
            Console.WriteLine($"Notifications ({notCount})     [3]");
            Console.WriteLine($"My CVs ({worker.CVs.Count})            [4]");
            Console.WriteLine($"Appeals ({worker.Appeals.Count})           [5]");
            Console.WriteLine("Create CV             [6]");
            Console.WriteLine("Account Info          [7]");
            Console.WriteLine("Back                  [0]");

        }

        public static void ShowEmployerMenu(Employer employer) {
            int n = employer.Notifications.Count, ev = employer.Vacancies.Count, ea = employer.Applicants.Count;
            Console.WriteLine($"CVs                 [1]");
            Console.WriteLine($"Search              [2]");
            Console.WriteLine($"Notifications ({n})   [3]");
            Console.WriteLine($"Vacancies ({ev})       [4]");
            Console.WriteLine($"Applicants ({ea})      [5]");
            Console.WriteLine("Create Vacancy      [6]");
            Console.WriteLine("Account Info        [7]");
            Console.WriteLine("Back                [0]");
        }

        public static void ShowAnnouncement(Database database)
        {
            Console.WriteLine("\t\t\t = = = Announcements = = = \n\n");
            int id = 0;
            foreach (var announcement in database.Employers)
            {
                Console.WriteLine($"{++id} ) {announcement.Name}   {announcement.Surname}"); 
                announcement.ShowVacancies(); Console.WriteLine("\n");

            }
        }

        public static void ShowCVs(Database database)
        {
            Console.WriteLine("\t\t\t = = = CVS = = = \n\n");
            int id = 0;
            foreach (var cv in database.Workers)
            {
                Console.WriteLine($"{++id} ) {cv.Name}  {cv.Surname}");
                cv.ShowCVs(); Console.WriteLine("\n");
            }
        }


        public static void SearchAnnouncementsByTags(Database database)
        {
            Console.WriteLine("\t\t\t = = = Search Announcements by Tags = = = \n\n");
            Console.WriteLine("\t\t = = Tags = = \n");
            foreach (var tag in database.Tags)
            {
                Console.Write($"{tag.TagName}  ,  ");
            }
            Console.WriteLine("\n\n");
            Console.WriteLine("Enter tags to search (comma-separated): ");
            string tagsInput = Console.ReadLine()?.Trim();
            string[] searchTags = tagsInput.Split(',').Select(tag => tag.Trim()).ToArray();

            List<Vacancy> matchingAnnouncements = new List<Vacancy>();

            foreach (var tag in searchTags)
            {
                var matchingVacancies = database.Employers
                    .SelectMany(e => e.Vacancies)
                    .Where(v => v.Tags.Any(t => t.TagName.Equals(tag, StringComparison.OrdinalIgnoreCase)))
                    .ToList();

                matchingAnnouncements.AddRange(matchingVacancies);
            }

            if (matchingAnnouncements.Count > 0)
            {
                Console.WriteLine("\t\t = = = Matching Announcements = = = \n\n");
                int id = 0;
                foreach (var vacancy in matchingAnnouncements)
                {
                    Console.Write($"{++id} ) ");
                    vacancy.ShowVacancy();
                    Console.WriteLine("Tags: " + string.Join(", ", vacancy.Tags.Select(t => t.TagName)));
                    Console.WriteLine("\n");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No matching announcements found.");
                Console.ResetColor();
            }
        }



        public static void SearchWorkerCVsByTags(Database database)
        {
            Console.WriteLine("\t\t\t = = = Search Worker CVs by Tags = = = \n\n");
            Console.WriteLine("\t\t = = Tags = = \n");

            foreach (var tag in database.Tags)
            {
                Console.Write($"{tag.TagName}  ,  ");
            }

            Console.WriteLine("\n\n");
            Console.WriteLine("Enter tags to search (comma-separated): ");
            string tagsInput = Console.ReadLine()?.Trim();
            string[] searchTags = tagsInput.Split(',').Select(tag => tag.Trim()).ToArray();

            List<CV> matchingCVs = new List<CV>();

            foreach (var tag in searchTags)
            {
                foreach (var worker in database.Workers)
                {
                    var matchingWorkerCVs = worker.CVs
                        .Where(cv => cv.Tags.Any(t => t.TagName.Equals(tag, StringComparison.OrdinalIgnoreCase)))
                        .ToList();

                    matchingCVs.AddRange(matchingWorkerCVs);
                }
            }

            if (matchingCVs.Count > 0)
            {
                Console.WriteLine("\t\t = = = Matching Worker CVs = = = \n\n");
                int id = 0;
                foreach (var cv in matchingCVs)
                {
                    Console.Write($"{++id} ) ");
                    cv.ShowCV();
                    Console.WriteLine("Tags: " + string.Join(", ", cv.Tags.Select(t => t.TagName)));
                    Console.WriteLine("\n");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No matching worker CVs found.");
                Console.ResetColor();
            }
        }



    }
}
