namespace HelloApp
{
    public class TimeService
    {
        private ITimer _timer;
        public TimeService(ITimer timer)
        {
            _timer = timer;
        }

        public string GetTime()
        {
            return _timer.Time;
        }
    }
}
