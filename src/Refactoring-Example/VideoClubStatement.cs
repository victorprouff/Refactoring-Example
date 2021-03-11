using System;
using System.Linq;
using Refactoring_Example.Models;

namespace Refactoring_Example
{
    public class VideoClubStatement
    {
        public string Statement(Invoice invoice, Play[] plays)
        {
            long totalAmount = 0;
            var volumeCredits = 0;
            var result = $"Statement for ${invoice.Customer} \n";
            // var format

            foreach (var perf in invoice.Performances)
            {
                var play = plays.First(p => p.Id == perf.PlayId);
                long thisAmount = AmmontFor(play, perf);

                // Ajoute des crédits de volume
                volumeCredits += Math.Max(perf.Audience - 30, 0);
                //Ajoute des crédits par groupe de 5 spectateurs assistant à une comédie
                if (play.Type == "comedie")
                {
                    volumeCredits += (int)Math.Floor((double)perf.Audience / 5);
                }
                
                // Imprime la ligne de cette commande
                result += $" {play.Name}: {thisAmount / 100} ({perf.Audience} seats) \n";
                totalAmount += thisAmount;
            }

            result += $"Amount owed is {totalAmount / 100} \n";
            result += $"You earned {volumeCredits} credits\n";
            return result;
        }

        private long AmmontFor(Play play, Performance perf)
        {
            long thisAmount;
            switch (play.Type)
            {
                case "tragedy":
                    thisAmount = 40000;
                    if (perf.Audience > 30)
                    {
                        thisAmount += 1000 * (perf.Audience - 30);
                    }

                    break;
                case "comedy":
                    thisAmount = 30000;
                    if (perf.Audience > 20)
                    {
                        thisAmount += 10000 + 500 * (perf.Audience - 20);
                    }

                    thisAmount += 300 * perf.Audience;
                    break;
                default:
                    throw new Exception($"Unkwnon type : ${play.Type}");
            }

            return thisAmount;
        }
    }
}