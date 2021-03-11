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

        public long Amount()
        {
            long result;
            switch (Performance.Play.Type)
            {
                case "tragedy":
                    result = 40000;
                    if (Performance.Audience > 30)
                    {
                        result += 1000 * (Performance.Audience - 30);
                    }

                    break;
                case "comedy":
                    result = 30000;
                    if (Performance.Audience > 20)
                    {
                        result += 10000 + 500 * (Performance.Audience - 20);
                    }

                    result += 300 * Performance.Audience;
                    break;
                default:
                    throw new Exception($"Unkwnon type : {Performance.Play.Type}");
            }

            return result / 100;
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