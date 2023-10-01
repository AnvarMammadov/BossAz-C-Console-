using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BossAz
{
    public class Vacancy
    {
        public string? VacancyName { get; set; } = "No Vacancy Name";
        public int Required_Age_Min { get; set; } = 18;
        public int Required_Age_Max { get; set; } = 60;
        public int Required_Work_Experience { get; set; } = 0;
        public string? AdditionalRequirements{ get; set; } = "No Requirements";
        public double Salary_Offered_Min { get; set; } = 350;
        public double Salary_Offered_Max { get; set; } = 750;
        public DateTime AnnouncementDate { get;} = DateTime.Now;
        public List<Tag> Tags { get; set; } = new List<Tag>();

        public void ShowVacancy()
        {
            Console.WriteLine($"Vacancy Name : {VacancyName}");
            Console.WriteLine($"Age Required : {Required_Age_Min} - {Required_Age_Max}");
            Console.WriteLine($"Experience Work Required : {Required_Work_Experience}");
            Console.WriteLine($"Salary Offered : {Salary_Offered_Min} - {Salary_Offered_Max}");
            Console.WriteLine($"Additional Requirements : {AdditionalRequirements}");
            Console.WriteLine($"Announcement Date : {AnnouncementDate.ToString("dd.MM.yyyy")}");
        }



    }
}
