﻿using System;
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
            long totalAmount = 0;
            var volumeCredits = 0;
            var result = $"Statement for ${invoice.Customer} \n";
            // var format

            foreach (var perf in invoice.Performances)
            {
                volumeCredits += VolumeCreditsFor(perf);

                // Imprime la ligne de cette commande
                result += $" {PlayFor(perf.PlayId).Name}: {AmmontFor(perf) / 100} ({perf.Audience} seats) \n";
                totalAmount += AmmontFor(perf);
            }

            result += $"Amount owed is {totalAmount / 100} \n";
            result += $"You earned {volumeCredits} credits\n";
            return result;
        }

        private int VolumeCreditsFor(Performance perf)
        {
            var volumeCredits = Math.Max(perf.Audience - 30, 0);

            if (PlayFor(perf.PlayId).Type == "comedie")
            {
                volumeCredits += (int) Math.Floor((double) perf.Audience / 5);
            }

            return volumeCredits;
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