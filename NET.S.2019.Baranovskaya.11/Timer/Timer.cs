using System;
using System.Timers;
using Timer;

namespace TimerTask
{
    public class Timer
    {
        public delegate void Handler(object sender, ClockEventArgs e);
                
        public event Handler TimeOut;
        
        private int _time;

        private System.Timers.Timer _timer;
        
        public int Time
        {
            get => _time;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("invalid value");
                }

                _time = value;
            }
        }

        public Timer(int time)
        {
            _timer = new System.Timers.Timer(time);
            _timer.Elapsed += new ElapsedEventHandler(EndTimer);
        }

        public void SetTimer(int time)
        {
            _timer = new System.Timers.Timer(time);            
            _timer.Elapsed += new ElapsedEventHandler(EndTimer);
        }

        public void Start()
        {
            _timer.Start();
        }

        private void EndTimer(object sender, ElapsedEventArgs e)
        {
            _timer.Stop();
            DoTimeOut(this, new ClockEventArgs(Time));
        }

        private void DoTimeOut(object sender, ClockEventArgs e)
        { 
            TimeOut?.Invoke(sender, e);            
        }
    }
}
