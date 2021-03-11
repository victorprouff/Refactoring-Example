namespace Refactoring_Example.Models
{
    public class Performance
    {
        private readonly PerformanceCalculator Calculator;
        public Performance(Play play, int audience)
        {
            Play = play;
            Audience = audience;
            Calculator = new PerformanceCalculator(this);
        }

        public Play Play { get; }
        public int Audience { get; }
        public long Amount => Calculator.Amount;
    }
}