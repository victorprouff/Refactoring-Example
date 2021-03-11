using System.Collections.Generic;

namespace Refactoring_Example.Models
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
    }
}