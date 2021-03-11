using System.Collections.Generic;
using System.Linq;

namespace Refactoring_Example.Models
{
    public class Data
    {
        public Data(string customer, IEnumerable<Performance> performances, long totalAmount, int totalVolumeCredits, Play[] plays)
        {
            Customer = customer;
            Performances = performances;
            TotalAmount = totalAmount;
            TotalVolumeCredits = totalVolumeCredits;
            Plays = plays;
        }

        public string Customer { get; }
        public IEnumerable<Performance> Performances { get; }
        public long TotalAmount { get; }
        public int TotalVolumeCredits { get; }
        public Play[] Plays { get; }
        
        public Play PlayFor(string playId) => Plays.First(p => p.Id == playId);
    }
}