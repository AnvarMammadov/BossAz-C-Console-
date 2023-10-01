using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BossAz
{
    public class Notification
    {
        public string? Message { get; set; } = "No Message";
        public DateTime MessageDate { get;} = DateTime.Now;

        public void ShowNotification()
        {
            Console.WriteLine($"Message : {Message}");
            Console.WriteLine($"Message Date : {MessageDate.ToString("dd.MM.yyyy")}");
        }
    }
}
