namespace BookConsoleApplication
{
    using NLog;

    public class Program
    {
        public static Logger logger;

        static void Main(string[] args)
        {
            logger = new Logger();
        }
    }
}
