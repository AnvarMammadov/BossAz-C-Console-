using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BossAz
{
    public  class Appeal
    {
        public Vacancy vacancy { get; set; } = new Vacancy { };
        public DateTime AppealDate { get; }=DateTime.Now;

        public void ShowAppeal()
        {
            vacancy.ShowVacancy();
            Console.WriteLine($"Appeal Date : {AppealDate.ToString("dd.MM.yyyy")}");
        }
    }
}
