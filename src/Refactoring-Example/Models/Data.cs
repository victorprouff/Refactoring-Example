using System;
using System.Collections.Generic;
using System.Linq;

namespace Refactoring_Example.Models
{
    public class Data
    {
        public Data(string customer, IEnumerable<Performance> performances, Play[] plays)
        {
            Customer = customer;
            Performances = performances;
            Plays = plays;
        }

        public string Customer { get; }
        public IEnumerable<Performance> Performances { get; }
        public Play[] Plays { get; }
        public long TotalAmount => Performances.Sum(AmmontFor);
        public int TotalVolumeCredits => Performances.Sum(VolumeCreditsFor);
        
        public Play PlayFor(string playId) => Plays.First(p => p.Id == playId);
        
        private int VolumeCreditsFor(Performance performance)
        {
            var result = Math.Max(performance.Audience - 30, 0);

            if (PlayFor(performance.PlayId).Type == "comedie")
            {
                result += (int) Math.Floor((double) performance.Audience / 5);
            }

            return result;
        }
        
        public long AmmontFor(Performance performance)
        {
            long result;
            switch (PlayFor(performance.PlayId).Type)
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
                    throw new Exception($"Unkwnon type : ${PlayFor(performance.PlayId).Type}");
            }

            return result / 100;
        }
    }
}