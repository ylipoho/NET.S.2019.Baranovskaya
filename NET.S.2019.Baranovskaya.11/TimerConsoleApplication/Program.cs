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
            TimerTask.Timer timer = new TimerTask.Timer(2000);
            
            timer.Start();

            Console.ReadLine();

        }
    }
}
