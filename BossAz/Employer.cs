using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BossAz
{
    public class Employer
    {
        private static int id = 0;
        private string? surname = "No Surname";
        private string? name = "No Name";
        private string? userName = "No UserName";
        private string? password = "No Password";
        private string? phone = "No Phone Number";
        private int age = 18;

        public int ID { get; } = ++id;
        public string? Name { get => name; set { if (Validation.CheckName(value)) name = value; } }
        public string? Surname { get => surname; set { if (Validation.CheckName(value)) surname = value; } }
        public string? UserName { get => userName; set { if (Validation.CheckName(value)) userName = value; } }
        public string? Password { get => password; set { if (Validation.CheckName(value)) password = value; } }
        public string? City { get; set; } = "No City";
        public string? Phone { get => phone; set { if (Validation.CheckPhoneNumber(value)) phone = value; } }
        public int Age { get => age; set { if (Validation.CheckAge(value)) age = value; } }
        public List<Worker> Applicants { get; set; }=new List<Worker>();
        public List<Notification> Notifications { get; set; } = new List<Notification>();
        public List<Vacancy> Vacancies { get; set; } = new List<Vacancy>();

        public void ShowEmployerInfo()
        {
            Console.WriteLine($"ID : {id}");
            Console.WriteLine($"Name : {Name}");
            Console.WriteLine($"Surname : {Surname}");
            Console.WriteLine($"Age : {Age}");
            Console.WriteLine($"City : {City}");
            Console.WriteLine($"Phone Number : {OtherFunctions.FormatPhoneNumber(Phone)}");
            Console.WriteLine($"City : {City}");
        }

        public void ShowNoticifications()
        {
            int id = 0;
            foreach (var not in Notifications)
            {
                Console.Write($"{++id} ) "); not.ShowNotification(); Console.WriteLine("\n");
            }
            Console.WriteLine("\n");
        }

        public void ShowVacancies()
        {
            int id = 0;
            foreach(var vac in Vacancies)
            {
                Console.Write($"{++id} . ");vac.ShowVacancy(); Console.WriteLine("\n");
            }
            Console.WriteLine("\n");
        }

        public void ShowApplicants()
        {
            int id = 0;
            foreach(var app  in Applicants)
            {
                Console.Write($"{++id} . ");app.ShowWorkerInfo(); Console.WriteLine("\n");
            }
            Console.WriteLine("\n");
        }

        public void CreateVacancy(Database database)
        {
            Console.WriteLine("\t\t = = = Create New Vacancy = = = \n\n");

            Vacancy newVacancy = new Vacancy();

            Console.Write("Enter Vacancy Name: ");
            newVacancy.VacancyName = Console.ReadLine()?.Trim();

            Console.Write("Enter Minimum Required Age: ");
            newVacancy.Required_Age_Min = int.Parse(Console.ReadLine()?.Trim());

            Console.Write("Enter Maximum Required Age: ");
            newVacancy.Required_Age_Max = int.Parse(Console.ReadLine()?.Trim());

            Console.Write("Enter Required Work Experience (in years): ");
            newVacancy.Required_Work_Experience = int.Parse(Console.ReadLine()?.Trim());

            Console.Write("Enter Minimum Salary Offered: ");
            newVacancy.Salary_Offered_Min = double.Parse(Console.ReadLine()?.Trim());

            Console.Write("Enter Maximum Salary Offered: ");
            newVacancy.Salary_Offered_Max = double.Parse(Console.ReadLine()?.Trim());

            Console.Write("Enter Additional Requirements: ");
            newVacancy.AdditionalRequirements = Console.ReadLine()?.Trim();

            Console.WriteLine("\nEnter Tags for the Vacancy (comma-separated): ");
            string tagsInput = Console.ReadLine()?.Trim();
            string[] tags = tagsInput.Split(',').Select(tag => tag.Trim()).ToArray();

            foreach (var tagStr in tags)
            {
                Tag tag = database.Tags.FirstOrDefault(t => t.TagName.Equals(tagStr, StringComparison.OrdinalIgnoreCase));
                if (tag != null)
                {
                    newVacancy.Tags.Add(tag);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Tag '{tagStr}' not found. This tag will be ignored.");
                    Console.ResetColor();
                }
            }

            
            Vacancies.Add(newVacancy);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Vacancy created successfully!");
            Console.ResetColor();

            FileHelper.WriteJson(database);
        }

    }
}
