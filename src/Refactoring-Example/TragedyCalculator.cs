using Refactoring_Example.Models;

namespace Refactoring_Example
{
    public class TragedyCalculator : PerformanceCalculator
    {
        public TragedyCalculator(Performance performance) : base(performance)
        {
        }

        public override long Amount()
        {
            var result = 40000;
            if (Performance.Audience > 30)
            {
                result += 1000 * (Performance.Audience - 30);
            }

            return result / 100;
        }
    }
}