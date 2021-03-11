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
            var data = new Data(
                invoice.Customer,
                invoice.Performances,
                _plays);
            
            return RenderPlainText(data);
        }

        private string RenderPlainText(Data data)
        {
            var result = $"Statement for ${data.Customer} \n";

            foreach (var performance in data.Performances)
            {
                result += $" {data.PlayFor(performance.PlayId).Name}: {data.AmmontFor(performance) / 100} ({performance.Audience} seats) \n";
            }

            result += $"Amount owed is {data.TotalAmount / 100} \n";
            result += $"You earned {data.TotalVolumeCredits} credits\n";
            return result;
        }
    }
}