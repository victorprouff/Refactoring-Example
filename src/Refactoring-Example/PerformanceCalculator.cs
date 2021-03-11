using System;
using Refactoring_Example.Models;

namespace Refactoring_Example
{
    public class PerformanceCalculator
    {
        public PerformanceCalculator(Performance performance)
        {
            Performance = performance;
        }

        public Performance Performance { get; }
    }
}