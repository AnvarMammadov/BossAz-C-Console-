using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace BossAz
{
    public class CV
    {
        private string? gitLink = "No GitHub";
        private string? linkEdin = "No Linkedin";

        public string? Speciality { get; set; } = "No Speciality";
        public string? EducationLevel { get; set; } = "Orta";
        public double University_Admission_Score { get; set; }=default(double);
        public List<Skill> Skills { get; set; } = new List<Skill> ();
        public List<Company> Companies { get; set; } = new List<Company> ();
        public int WorkExperience { get; set; } = 0;
        public List<Language> Languages { get; set; } = new List<Language> ();
        public bool HonorsDiploma { get; set; } = false;
        public string? GitLink { get => gitLink; set  { if(Validation.CheckGitHubLink(value))gitLink = value; } }
        public string? LinkEdin { get => linkEdin; set {if(Validation.CheckLinkedInLink(value)) linkEdin = value; } }
        public List<Tag> Tags { get; set; }=new List<Tag> ();
        public void ShowCV()
        {
            Console.WriteLine($"Speciality : {Speciality}");
            Console.WriteLine($"Education Level : {EducationLevel}");
            Console.WriteLine($"University Admission Score : {University_Admission_Score}");
            Console.Write($"Skills : ");
            foreach (var skill in Skills) { Console.Write($"{skill.SkillName} , "); }
            Console.WriteLine("\n");
            Console.WriteLine("\t = = Companies = = \n\n");
            int idComp = 0;
            foreach (var company in Companies) { Console.Write($"{++idComp} . "); company.ShowCompany();}
            Console.WriteLine("\n");
            Console.WriteLine($"Work Experience : {OtherFunctions.GetWorkExperince(Companies)} Year");
            Console.WriteLine("\n");
            Console.Write($"Skills : ");
            foreach (var lan in Languages) { Console.Write($"{lan.LanguageName} , "); }
            Console.WriteLine("\n");
            string? honorsDiploma = (HonorsDiploma == true) ? "Yes" : "No";
            Console.WriteLine($"Honors Diploma : {honorsDiploma}");
            Console.WriteLine($"GitLink : {GitLink}");
            Console.WriteLine($"LinkedIn Link : {LinkEdin}");
        }

    }
}
