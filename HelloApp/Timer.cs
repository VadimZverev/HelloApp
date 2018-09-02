namespace HelloApp
{
    public class Timer : ITimer
    {
        public Timer()
        {
            Time = System.DateTime.Now.ToString("hh:mm:ss");
        }

        public string Time { get; }
    }
}
