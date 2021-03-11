using System;

namespace Refactoring_Example.Models
{
    public class Performance
    {
        private readonly PerformanceCalculator _calculator;
        public Performance(Play play, int audience)
        {
            Play = play;
            Audience = audience;
            _calculator = CreatePerformanceCalculator();
        }

        public Play Play { get; }
        public int Audience { get; }
        public long Amount => _calculator.Amount();
        public int VolumeCredits => _calculator.VolumeCredits();

        private PerformanceCalculator CreatePerformanceCalculator()
        {
            return Play.Type switch
            {
                PlayType.Tragedy => new TragedyCalculator(this),
                PlayType.Comedy => new ComedyCalculator(this),
                _ => throw new Exception($"Unkwnon type : {Play.Type}")
            };
        }
    }
}