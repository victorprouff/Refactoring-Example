using System;
using Refactoring_Example.Models;

namespace Refactoring_Example
{
    public abstract class PerformanceCalculator
    {
        public PerformanceCalculator(Performance performance)
        {
            Performance = performance;
        }

        public Performance Performance { get; }

        public virtual long Amount()
        {
            throw new Exception("Subclass responsibility");
        }

        public int VolumeCredits()
        {
            var result = Math.Max(Performance.Audience - 30, 0);

            if (Performance.Play.Type == "comedie")
            {
                result += (int) Math.Floor((double) Performance.Audience / 5);
            }

            return result;
        }
    }
}