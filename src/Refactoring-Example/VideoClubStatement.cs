using System;
using System.Collections.Generic;
using System.Linq;
using Refactoring_Example.Models;

namespace Refactoring_Example
{
    public class VideoClubStatement
    {
        private readonly Play[] _plays;

        public VideoClubStatement(Play[] plays)
        {
            _plays = plays;
        }
        public string Statement(Invoice invoice)
        {
            var data = new Data(invoice.Customer, invoice.Performances);
            return RenderPlainText(data);
        }

        private string RenderPlainText(Data data)
        {
            var result = $"Statement for ${data.Customer} \n";

            foreach (var performance in data.Performances)
            {
                // Imprime la ligne de cette commande
                result += $" {PlayFor(performance.PlayId).Name}: {AmmontFor(performance) / 100} ({performance.Audience} seats) \n";
            }

            result += $"Amount owed is {TotalAmount(data.Performances) / 100} \n";
            result += $"You earned {TotalVolumeCredits(data.Performances)} credits\n";
            return result;
        }

        private long TotalAmount(IEnumerable<Performance> performances) => performances.Sum(AmmontFor);

        private int TotalVolumeCredits(IEnumerable<Performance> performances) => performances.Sum(VolumeCreditsFor);

        private int VolumeCreditsFor(Performance performance)
        {
            var result = Math.Max(performance.Audience - 30, 0);

            if (PlayFor(performance.PlayId).Type == "comedie")
            {
                result += (int) Math.Floor((double) performance.Audience / 5);
            }

            return result;
        }

        private Play PlayFor(string playId) => _plays.First(p => p.Id == playId);

        private long AmmontFor(Performance performance)
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

            return result;
        }
    }
}