using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimerTask;

namespace TimerConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer timer = new Timer(2000);

            Timer t = new Timer(2);

            Timer.Del deleg = Print;

            Timer.TimeOut += deleg;

            timer.Start();
            Console.WriteLine("start... 2 sec");

            Console.ReadLine();

        }

        public static void Print(string m)
        {
            Console.WriteLine(m);
        }
    }
}
