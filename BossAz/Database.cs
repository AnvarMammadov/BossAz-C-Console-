using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BossAz
{
    public class Database
    {
       public List<Worker>? Workers { get; set; }= new List<Worker>();  
       public List<Employer>? Employers { get; set; }=new List<Employer>();
        public List<Tag> Tags { get; set; }=new List<Tag>();    

        public void AddTag()
        {
            bool flag = false;
            foreach (var emp in Employers)
            {
                foreach (var vac in emp.Vacancies)
                {
                    foreach(var tag in vac.Tags) {
                        flag= true;
                        foreach (var t in Tags)
                        {
                            if (t.TagName == tag.TagName) { flag = false; break; }
                        }
                        if (flag) { Tags.Add(tag); }
                    }
                }
            }
        }
    }
}
