namespace BossAz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    App.Start();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nError : {ex.Message}");
                    Console.ResetColor();
                    ErrorHandling.LogError($"An error occurred : {ex.Message}");
                    OtherFunctions.PressAnyKey();
                }

            }  
        }
    }
}