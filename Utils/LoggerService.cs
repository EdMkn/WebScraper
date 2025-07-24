using WebScraper.Interfaces;

namespace WebScraper.Utils
{
    public class LoggerService : ILoggerService
    {
        public void Info(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"[INFO] {message}");
            Console.ResetColor();
        }

        public void Warn(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[WARN] {message}");
            Console.ResetColor();
        }

        public void Error(string message, Exception? ex = null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[ERROR] {message}");
            if (ex != null)
                Console.WriteLine($"         {ex.Message}");
            Console.ResetColor();
        }
    }
}
