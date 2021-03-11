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

        public int TotalVolumeCredits => Performances.Select(p=>p.VolumeCredits).Sum();
    }
}