using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BossAz
{
    public class Worker
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
        public string? Surname { get => surname; set { if(Validation.CheckName(value))surname = value; } }
        public string? UserName { get => userName; set { if (Validation.CheckName(value)) userName = value; } }
        public string? Password { get => password; set { if (Validation.CheckName(value)) password = value; } }
        public string? City { get; set; } = "No City";
        public string? Phone { get => phone; set {if(Validation.CheckPhoneNumber(value))phone = value; } }
        public int Age { get => age; set {if (Validation.CheckAge(value)) age = value; } }
        public List<Appeal> Appeals { get; set; }=new List<Appeal>();
        public List<Notification> Notifications { get; set; } = new List<Notification>();
        public List<CV> CVs { get; set; } = new List<CV>();


        public void ShowWorkerInfo()
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

        public void ShowCVs()
        {
            int id = 0;
            foreach (var vac in CVs)
            {
                Console.WriteLine($"{++id} ) "); vac.ShowCV(); Console.WriteLine("\n");
            }
            Console.WriteLine("\n");
        }

        public void ShowAppeals()
        {
            int id =0;  
            foreach (var appeal in Appeals)
            {
                Console.WriteLine($"{++id} ) ");appeal.ShowAppeal(); Console.WriteLine("\n");   
            }
            Console.WriteLine("\n");
        }

        public void CreateCV()
        {
            CV newCV = new CV();

            Console.Write("Enter Speciality : ");
            newCV.Speciality = Console.ReadLine();

            Console.Write("Enter Education Level : ");
            newCV.EducationLevel = Console.ReadLine();

            Console.Write("Enter University Admission Score : ");
            if (double.TryParse(Console.ReadLine(), out double admissionScore))
            {
                newCV.University_Admission_Score = admissionScore;
            }
            else
            {
                Console.WriteLine("Invalid input for University Admission Score. Using the default value.");
            }

            Console.WriteLine("Enter Skills (comma-separated): ");
            string skillsInput = Console.ReadLine();
            List<Skill> skillsList = skillsInput.Split(',').Select(skill => new Skill(skill.Trim())).ToList();
            newCV.Skills = skillsList;

            Company newCompany = new Company();
            while (true)
            {

                Console.WriteLine("Enter Company Name: ");
                newCompany.CompanyName = Console.ReadLine();

                Console.WriteLine("Enter Start Date (DD-MM-YYYY): ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime startDate))
                {
                    newCompany.StartDate = startDate;
                }
                else
                {
                    Console.WriteLine("Invalid date format for Start Date.");
                    continue;
                }

                Console.WriteLine("Enter End Date (DD-MM-YYYY): ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime endDate))
                {
                    newCompany.EndDate = endDate;
                }
                else
                {
                    Console.WriteLine("Invalid date format for End Date.");
                    continue;
                }

                newCV.Companies.Add(newCompany);

                Console.WriteLine("Do you want to add another company? (Yes/No): ");
                string addAnother = Console.ReadLine();
                if (!addAnother.Equals("Yes", StringComparison.OrdinalIgnoreCase))
                {
                    break; 
                }
            }

            newCV.WorkExperience = OtherFunctions.GetWorkExperince(newCV.Companies);

            Console.WriteLine("Enter Languages (comma-separated): ");
            string languagesInput = Console.ReadLine();
            List<Language> languagesList = languagesInput.Split(',').Select(language => new Language(language.Trim())).ToList();
            newCV.Languages = languagesList;

            Console.WriteLine("Do you have an Honors Diploma? (Yes/No): ");
            string honorsInput = Console.ReadLine();
            newCV.HonorsDiploma = honorsInput.Equals("Yes", StringComparison.OrdinalIgnoreCase);

            Console.WriteLine("Enter GitHub Link (optional): ");
            newCV.GitLink = Console.ReadLine();

            Console.WriteLine("Enter LinkedIn Link (optional): ");
            newCV.LinkEdin = Console.ReadLine();

            CVs.Add(newCV);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("CV created successfully!");
            Console.ResetColor();
        }

    }
}
