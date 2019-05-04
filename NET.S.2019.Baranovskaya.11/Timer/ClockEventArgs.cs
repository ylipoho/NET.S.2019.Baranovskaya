namespace Timer
{
    using System;

    public class ClockEventArgs : EventArgs
    {
        public ClockEventArgs(int time)
        {
            this.Time = time;
            this.Message = string.Format("time: {0}", time);
        }

        public int Time { get; private set; }

        public string Message { get; private set; }
    }
}
