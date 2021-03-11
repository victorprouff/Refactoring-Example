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
            switch (Play.Type)
            {
                case "tragedy":
                    return new TragedyCalculator(this);
                case "comedy":
                    return new ComedyCalculator(this);
                default:
                    throw new Exception($"Unkwnon type : {Play.Type}");
            }
        }
    }
}