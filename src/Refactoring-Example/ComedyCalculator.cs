using Refactoring_Example.Models;

namespace Refactoring_Example
{
    public class ComedyCalculator : PerformanceCalculator
    {
        public ComedyCalculator(Performance performance) : base(performance)
        {
        }

        public override long Amount()
        {
            var result = 30000;
            if (Performance.Audience > 20)
            {
                result += 10000 + 500 * (Performance.Audience - 20);
            }

            result += 300 * Performance.Audience;
            return result / 100;
        }
    }
}