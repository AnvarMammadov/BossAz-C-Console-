using System;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Runtime.Intrinsics.Arm;

namespace BossAz
{
    public class App
    {
        public static void Start()
        {

            Database database = new Database();
            database.Workers = new List<Worker> {
                new Worker{
                    Name="Anvar",
                    Surname="Mammadov",
                    Age=22,
                    City="Baku",
                    Phone="0514268456",
                    UserName="anvar",
                    Password="0000",
                },
                new Worker{
                    Name="Murad",
                    Surname="Gojayev",
                    Age=21,
                    City="Baku",
                    Phone="0514325567",
                    UserName="murad",
                    Password="1111",
                    CVs=new List<CV> {
                        new CV
                        {
                            Speciality="JavaScript",
                            EducationLevel="Tam ali",
                            University_Admission_Score=450,
                            HonorsDiploma=true,
                            Companies=new List<Company>
                            {
                                new Company
                                {
                                    CompanyName="Microsoft",
                                    StartDate=DateTime.Now.AddYears(-5),
                                    EndDate=DateTime.Now.AddYears(-3)
                                }
                            },
                            WorkExperience=2,
                            Skills=new List<Skill>
                            {
                                new Skill("JavaScript"),new Skill("Front-End")
                            },
                            Languages=new List<Language>
                            {
                                new Language("English"),new Language("Portugues")
                            },
                            GitLink="github.com/muradgojayev",
                            LinkEdin="linkedin.com/in/muradgojayev",
                            Tags=new List<Tag>
                            {
                                new Tag{TagName="JavaScript"},new Tag{TagName="Front-End"}
                            }

                        }
                    },
                },
                new Worker
                {
                    Name = "Amin",
                    Surname = "Ahmadov",
                    Age = 25,
                    City = "Ganja",
                    Phone = "0555123456",
                    UserName = "ali",
                    Password = "1234",
                },
                new Worker
                {
                    Name = "Nigar",
                    Surname = "Mehdiyeva",
                    Age = 23,
                    City = "Sumqayit",
                    Phone = "0503112233",
                    UserName = "nigar",
                    Password = "4321",
                },
                new Worker
                {
                    Name = "Elvin",
                    Surname = "Rzayev",
                    Age = 28,
                    City = "Baku",
                    Phone = "0512123456",
                    UserName = "elvin",
                    Password = "5678",
                }
            };

            database.Employers = new List<Employer>
            {
                new Employer
    {
        Name = "Ali",
        Surname = "Aliyev",
        Age = 24,
        City = "Goycay",
        Phone = "0515556242",
        UserName = "ali",
        Password = "3333",
        Vacancies = new List<Vacancy>
        {
            new Vacancy
            {
                VacancyName = "C# Developer",
                Required_Work_Experience = 4,
                Required_Age_Min = 18,
                Required_Age_Max = 30,
                Salary_Offered_Min = 1500,
                Salary_Offered_Max = 3000,
                AdditionalRequirements = "Mesuliyətli olsun",
                Tags = new List<Tag>
                {
                    new Tag { TagName = "C#" },
                    new Tag { TagName = "Programming" },
                }
            },
            new Vacancy
            {
                VacancyName = "Java Developer",
                Required_Work_Experience = 3,
                Required_Age_Min = 20,
                Required_Age_Max = 35,
                Salary_Offered_Min = 1600,
                Salary_Offered_Max = 3200,
                AdditionalRequirements = "Java konusunda deneyimli olmalıdır.",
                Tags = new List<Tag>
                {
                    new Tag { TagName = "Java" },
                    new Tag { TagName = "Programming" },
                }
            },
            new Vacancy
            {
                VacancyName = "Front-End Developer",
                Required_Work_Experience = 2,
                Required_Age_Min = 22,
                Required_Age_Max = 40,
                Salary_Offered_Min = 1800,
                Salary_Offered_Max = 3500,
                AdditionalRequirements = "React veya Angular bilgisi olmalıdır.",
                Tags = new List<Tag>
                {
                    new Tag { TagName = "Front-End" },
                    new Tag { TagName = "Web Development" },
                }
            }
        }
    },
    new Employer
    {
        Name = "Nurlan",
        Surname = "Mehdiyev",
        Age = 30,
        City = "Baku",
        Phone = "0512345688",
        UserName = "nurlan",
        Password = "9876",
        Vacancies = new List<Vacancy>
        {
            new Vacancy
            {
                VacancyName = "Web Developer",
                Required_Work_Experience = 3,
                Required_Age_Min = 20,
                Required_Age_Max = 35,
                Salary_Offered_Min = 2000,
                Salary_Offered_Max = 3500,
                AdditionalRequirements = "Front-end ve back-end bilgisi olmalıdır.",
                Tags = new List<Tag>
                {
                    new Tag { TagName = "Web Development" },
                    new Tag { TagName = "HTML" },
                    new Tag { TagName = "CSS" },
                }
            },
            new Vacancy
            {
                VacancyName = "Database Administrator",
                Required_Work_Experience = 5,
                Required_Age_Min = 25,
                Required_Age_Max = 45,
                Salary_Offered_Min = 2500,
                Salary_Offered_Max = 4500,
                AdditionalRequirements = "Veritabanı yönetimi konusunda deneyimli olmalıdır.",
                Tags = new List<Tag>
                {
                    new Tag { TagName = "Database" },
                    new Tag { TagName = "SQL" },
                }
            },
            new Vacancy
            {
                VacancyName = "UI/UX Designer",
                Required_Work_Experience = 2,
                Required_Age_Min = 22,
                Required_Age_Max = 35,
                Salary_Offered_Min = 1800,
                Salary_Offered_Max = 3200,
                AdditionalRequirements = "Grafik tasarım ve kullanıcı deneyimi tasarımı konusunda deneyimli olmalıdır.",
                Tags = new List<Tag>
                {
                    new Tag { TagName = "UI/UX" },
                    new Tag { TagName = "Design" },
                }
            },
            new Vacancy
            {
                VacancyName = "System Administrator",
                Required_Work_Experience = 4,
                Required_Age_Min = 28,
                Required_Age_Max = 45,
                Salary_Offered_Min = 2300,
                Salary_Offered_Max = 4000,
                AdditionalRequirements = "Sistem yönetimi konusunda deneyimli olmalıdır.",
                Tags = new List<Tag>
                {
                    new Tag { TagName = "System Administration" },
                    new Tag { TagName = "IT" },
                }
            }
        }
    }
            };

            database.Tags = new List<Tag>
            {
                new Tag{TagName="C#"},new Tag{TagName="C++"},new Tag{TagName="Java"},new Tag{TagName="JavaScript"},new Tag{TagName="Python"},new Tag{TagName="SQL"},
                new Tag{TagName="Back-End"},new Tag{TagName="Front-End"},new Tag{TagName="Django"},new Tag{TagName="Swift"},new Tag{TagName="IT"},new Tag{TagName="Driver"}
            };
            database.AddTag();
            string? chooseAppMenuOperation = "";
            while (true)
            {
                database = FileHelper.ReadJsonDatabase(database);
                OtherFunctions.MyClear();
                Worker currentWorker;
                Employer currentEmployer;
                UI_Functions.AppMenu();
                chooseAppMenuOperation = Console.ReadLine()?.Trim();
                if (chooseAppMenuOperation != null)
                {
                    if (chooseAppMenuOperation == "1")
                    {
                        OtherFunctions.MyClear();
                        Console.WriteLine("\t\t\t = = = Worker Login Page = = = \n\n");
                        string[] workerAccInfo = UI_Functions.GetUserNameAndPass();
                        if (Validation.Check_Workers_UserName_And_Pass_In_Database(workerAccInfo, database))
                        {
                            currentWorker = OtherFunctions.GetCurrentWorker(workerAccInfo, database); Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Login Successfully");
                            Console.ResetColor(); Thread.Sleep(650);
                            while (true)
                            {
                                OtherFunctions.MyClear();
                                UI_Functions.ShowWorkerMenu(currentWorker);
                                string? chooseWM = Console.ReadLine()?.Trim();

                                OtherFunctions.MyClear();
                                if (chooseWM == "1")
                                {
                                    while (true)
                                    {
                                        OtherFunctions.MyClear();
                                        UI_Functions.ShowAnnouncement(database);
                                        Console.WriteLine("\nBack      [0]");
                                        Console.Write("Enter Employer ID : ");
                                        int idEmp = Convert.ToInt32(Console.ReadLine()?.Trim());
                                        if (idEmp == 0) break;

                                        if (idEmp - 1 < 0 || idEmp - 1 >= database.Employers.Count)
                                        {
                                            OtherFunctions.NotFound("This Employer");
                                            OtherFunctions.PressAnyKey(); OtherFunctions.MyClear();
                                        }
                                        else
                                        {
                                            OtherFunctions.MyClear();
                                            database.Employers[idEmp - 1].ShowVacancies(); Console.WriteLine("\n");
                                            Console.WriteLine("\nBack    [0]");
                                            Console.Write("Enter Announcement ID : ");
                                            int idAn = Convert.ToInt32(Console.ReadLine()?.Trim());
                                            if (idAn == 0) break;
                                            if (idAn - 1 < 0 || idAn - 1 >= database.Employers[idEmp - 1].Vacancies.Count)
                                            {
                                                OtherFunctions.NotFound("This Announcement"); OtherFunctions.PressAnyKey();
                                                OtherFunctions.MyClear();
                                            }
                                            else
                                            {
                                                var vacancy = database.Employers[idEmp - 1].Vacancies[idAn - 1];
                                                Console.WriteLine("Apply   [1]");
                                                Console.WriteLine("Back    [2]");
                                                string? appOrBack = Console.ReadLine()?.Trim();
                                                if (appOrBack == "1")
                                                {
                                                    if (currentWorker.CVs.Count == 0)
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("Your are have not CV...Please turn back and create CV");
                                                        Console.ResetColor();
                                                        OtherFunctions.PressAnyKey(); OtherFunctions.MyClear(); break;
                                                    }
                                                    else
                                                    {
                                                        var notificationWorker = new Notification
                                                        {
                                                            Message = $"You are applied announcement...\nAnnouncement Name : {vacancy.VacancyName}\n" +
                                                            $"Announcement Advertiser : {database.Employers[idEmp - 1].Name}  {database.Employers[idEmp - 1].Surname}"
                                                        };
                                                        currentWorker.Notifications.Add(notificationWorker);

                                                        var notificationEmployer = new Notification
                                                        {
                                                            Message = $"A worker who applies to your Announcement...\nAnnouncement Name : {vacancy.VacancyName}\n" +
                                                            $"Worker : {currentWorker.Name}  {currentWorker.Surname}"
                                                        };

                                                        currentWorker.Appeals.Add(new Appeal { vacancy = vacancy });
                                                        database.Employers[idEmp - 1].Applicants.Add(currentWorker);
                                                        database.Employers[idEmp - 1].Notifications.Add(notificationEmployer);
                                                        FileHelper.WriteJson(database);
                                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                                        Console.WriteLine("Applied Successfully.."); Console.ResetColor();
                                                        OtherFunctions.PressAnyKey(); OtherFunctions.MyClear(); break;

                                                    }
                                                }
                                                else if (appOrBack == "2") { break; }
                                                else { OtherFunctions.NotFound("Operation"); continue; }
                                            }
                                        }
                                    }

                                }
                                else if (chooseWM == "2")
                                {
                                    UI_Functions.SearchAnnouncementsByTags(database);
                                    OtherFunctions.PressAnyKey(); OtherFunctions.MyClear(); continue;
                                }
                                else if (chooseWM == "3")
                                {
                                    Console.WriteLine("\t\t\t = = = Notifications = = = \n\n");
                                    currentWorker.ShowNoticifications(); OtherFunctions.PressAnyKey(); continue;
                                }
                                else if (chooseWM == "4")
                                {
                                    Console.WriteLine("\t\t\t = = = CVS = = = \n\n");
                                    currentWorker.ShowCVs(); OtherFunctions.PressAnyKey(); continue;
                                }
                                else if (chooseWM == "5")
                                {
                                    Console.WriteLine("\t\t\t = = = Appeals = = = \n\n");
                                    currentWorker.ShowAppeals(); OtherFunctions.PressAnyKey(); continue;
                                }
                                else if (chooseWM == "6")
                                {
                                    Console.WriteLine("\t\t\t = = = Create New CV = = = \n\n");
                                    currentWorker.CreateCV(); FileHelper.WriteJson(database); OtherFunctions.PressAnyKey(); continue;
                                }
                                else if (chooseWM == "7")
                                {
                                    Console.WriteLine("\t\t\t = = = Account Information = = = \n\n");
                                    currentWorker.ShowWorkerInfo(); OtherFunctions.PressAnyKey(); continue;
                                }
                                else if (chooseWM == "0") { break; }
                                else { OtherFunctions.NotFound("This Operation"); OtherFunctions.PressAnyKey(); continue; }
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Username or password is wrong !!! Please try again...");
                            Console.ResetColor(); OtherFunctions.PressAnyKey(); OtherFunctions.MyClear(); continue;
                        }
                    }
                    else if (chooseAppMenuOperation == "2")
                    {
                        OtherFunctions.MyClear();
                        Console.WriteLine("\t\t\t = = = Employer Login Page = = = \n\n");
                        string[] employerAccInfo = UI_Functions.GetUserNameAndPass();
                        OtherFunctions.MyClear();
                        if (Validation.Check_Employers_UserName_And_Pass_In_Database(employerAccInfo, database))
                        {
                            currentEmployer = OtherFunctions.GetCurrentEmployer(employerAccInfo, database); Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Login Successfully");
                            Console.ResetColor(); Thread.Sleep(650);
                            while (true)
                            {
                                OtherFunctions.MyClear();
                                UI_Functions.ShowEmployerMenu(currentEmployer);
                                string? chooseEM = Console.ReadLine()?.Trim();
                                OtherFunctions.MyClear();
                                if (chooseEM == "1")
                                {
                                    while (true)
                                    {
                                        OtherFunctions.MyClear();
                                        UI_Functions.ShowCVs(database);
                                        Console.WriteLine("\nBack      [0]");
                                        Console.Write("Enter Worker ID : ");
                                        int idWork = Convert.ToInt32(Console.ReadLine()?.Trim());
                                        if (idWork == 0) break;

                                        if (idWork - 1 < 0 || idWork - 1 >= database.Workers.Count)
                                        {
                                            OtherFunctions.NotFound("This Worker");
                                            OtherFunctions.PressAnyKey(); OtherFunctions.MyClear();
                                        }
                                        else
                                        {
                                            OtherFunctions.MyClear();
                                            database.Workers[idWork - 1].ShowCVs(); Console.WriteLine("\n");
                                            Console.WriteLine("\nBack    [0]");
                                            Console.Write("Enter CV ID : ");
                                            int idCV = Convert.ToInt32(Console.ReadLine()?.Trim());
                                            if (idCV == 0) break;
                                            if (idCV - 1 < 0 || idCV - 1 >= database.Workers[idWork - 1].CVs.Count)
                                            {
                                                OtherFunctions.NotFound("This CV"); OtherFunctions.PressAnyKey();
                                                OtherFunctions.MyClear();
                                            }
                                            else
                                            {
                                                var cv = database.Workers[idWork - 1].CVs[idCV - 1];
                                                Console.WriteLine("Apply   [1]");
                                                Console.WriteLine("Back    [2]");
                                                string? appOrBack = Console.ReadLine()?.Trim();
                                                if (appOrBack == "1")
                                                {
                                                    var notificationWorker = new Notification
                                                    {
                                                        Message = $"You received an offer from Employer : {currentEmployer.Name}  {currentEmployer.Surname}\n" +
                                                        $"Speciality : {database.Workers[idWork - 1].CVs[idCV - 1].Speciality}"

                                                    };
                                                    database.Workers[idWork - 1].Notifications.Add(notificationWorker);

                                                    var notificationEmployer = new Notification
                                                    {
                                                        Message = $"You made a job offer to Worker : {database.Workers[idWork - 1].Name}  {database.Workers[idWork - 1].Surname}\n" +
                                                          $"Speciality : {database.Workers[idWork - 1].CVs[idCV - 1].Speciality}"
                                                    };
                                                    currentEmployer.Notifications.Add(notificationEmployer);

                                                    FileHelper.WriteJson(database);
                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.WriteLine("Applied Successfully.."); Console.ResetColor();
                                                    OtherFunctions.PressAnyKey(); OtherFunctions.MyClear(); break;
                                                }
                                                else if (appOrBack == "2") { break; }
                                                else { OtherFunctions.NotFound("Operation"); continue; }
                                            }
                                        }
                                    }
                                }
                                else if (chooseEM == "2") {
                                    UI_Functions.SearchWorkerCVsByTags(database);
                                    OtherFunctions.PressAnyKey(); OtherFunctions.MyClear(); continue;
                                }
                                else if (chooseEM == "3") {
                                    Console.WriteLine("\t\t\t = = = Notifications = = = \n\n");
                                    currentEmployer.ShowNoticifications(); OtherFunctions.PressAnyKey(); continue;
                                }
                                else if (chooseEM == "4") {
                                    Console.WriteLine("\t\t\t = = = Vacancies = = = \n\n");
                                    currentEmployer.ShowVacancies();OtherFunctions.PressAnyKey();continue;
                                }
                                else if (chooseEM == "5") { Console.WriteLine("\t\t\t = = = Applicants = = = \n\n");
                                    currentEmployer.ShowApplicants();OtherFunctions.PressAnyKey();continue; 
                                }
                                else if (chooseEM == "6") {
                                    Console.WriteLine("\t\t\t = = = Create New Vacancy = = = \n\n");
                                    currentEmployer.CreateVacancy(database); OtherFunctions.PressAnyKey(); continue;

                                }
                                else if (chooseEM == "7") {
                                    Console.WriteLine("\t\t\t = = = Account Information = = = \n\n");
                                    currentEmployer.ShowEmployerInfo(); OtherFunctions.PressAnyKey(); continue;
                                }
                                else if (chooseEM == "0") { break; }
                                else { OtherFunctions.NotFound("This Operation"); OtherFunctions.PressAnyKey(); continue; }
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Username or password is wrong !!! Please try again...");
                            Console.ResetColor(); OtherFunctions.PressAnyKey(); OtherFunctions.MyClear(); continue;
                        }
                    }
                    else if (chooseAppMenuOperation == "0") { Console.WriteLine("Application Closed..."); break; }
                    else { OtherFunctions.NotFound("Operation"); OtherFunctions.PressAnyKey(); OtherFunctions.MyClear(); continue; }
                }
            }


        }
    }
}
