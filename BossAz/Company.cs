namespace BossAz
{
    public class Company
    {
        public string? CompanyName { get; set; } = "No Company";
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public void ShowCompany()
        {
            Console.WriteLine($"Company : {CompanyName} | Start Date - End Date : {StartDate.Year} - {EndDate.Year}");
        }
    }
}