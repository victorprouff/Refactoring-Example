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

        public virtual int VolumeCredits()
        {
            return Math.Max(Performance.Audience - 30, 0);
        }
    }
}