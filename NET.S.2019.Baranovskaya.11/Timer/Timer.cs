using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TimerTask
{
    public class Timer
    {
        public delegate void Del(string message);

        public static event Del TimeOut;

        System.Timers.Timer _timer;

        public bool isGo;

        public int Time { get; }

        public Timer(int time)
        {
            Time = time;
            _timer = new System.Timers.Timer(Time);
        }

        public void SetTimer(int Time)
        {
            _timer = new System.Timers.Timer(Time);
        }
        public void Start()
        {
            _timer.Start();
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            // вызвать событие и передать ему нужжную инфу
            TimeOut("time is out");
            
        }
    }
}
