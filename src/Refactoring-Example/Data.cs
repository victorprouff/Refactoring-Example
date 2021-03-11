using System;
using System.Collections.Generic;
using System.Linq;
using Refactoring_Example.Models;

namespace Refactoring_Example
{
    public class Data
    {
        public Data(string customer, IEnumerable<Performance> performances)
        {
            Customer = customer;
            Performances = performances;
        }

        public string Customer { get; }
        public IEnumerable<Performance> Performances { get; }
        public long TotalAmount => Performances.Select(p => p.Amount).Sum();

        public int TotalVolumeCredits => Performances.Sum(VolumeCreditsFor);
        
        private int VolumeCreditsFor(Performance performance)
        {
            var result = Math.Max(performance.Audience - 30, 0);

            if (performance.Play.Type == "comedie")
            {
                result += (int) Math.Floor((double) performance.Audience / 5);
            }

            return result;
        }
    }
}