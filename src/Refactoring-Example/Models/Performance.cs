namespace Refactoring_Example.Models
{
    public class Performance
    {
        private readonly PerformanceCalculator _calculator;
        public Performance(Play play, int audience)
        {
            Play = play;
            Audience = audience;
            _calculator = new PerformanceCalculator(this);
        }

        public Play Play { get; }
        public int Audience { get; }
        public long Amount => _calculator.Amount();
        public int VolumeCredits => _calculator.VolumeCredits();
    }
}