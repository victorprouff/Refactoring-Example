using System.Collections.Generic;

namespace Refactoring_Example.Models
{
    public class Data
    {
        public Data(string customer, IEnumerable<Performance> performances, long totalAmount, int totalVolumeCredits)
        {
            Customer = customer;
            Performances = performances;
            TotalAmount = totalAmount;
            TotalVolumeCredits = totalVolumeCredits;
        }

        public string Customer { get; }
        public IEnumerable<Performance> Performances { get; }
        public long TotalAmount { get; }
        public int TotalVolumeCredits { get; }
    }
}