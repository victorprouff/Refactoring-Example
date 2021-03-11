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
        public long TotalAmount => Performances.Sum(AmmontFor);
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
        
        public long AmmontFor(Performance performance)
        {
            long result;
            switch (performance.Play.Type)
            {
                case "tragedy":
                    result = 40000;
                    if (performance.Audience > 30)
                    {
                        result += 1000 * (performance.Audience - 30);
                    }

                    break;
                case "comedy":
                    result = 30000;
                    if (performance.Audience > 20)
                    {
                        result += 10000 + 500 * (performance.Audience - 20);
                    }

                    result += 300 * performance.Audience;
                    break;
                default:
                    throw new Exception($"Unkwnon type : ${performance.Play.Type}");
            }

            return result / 100;
        }
    }
}