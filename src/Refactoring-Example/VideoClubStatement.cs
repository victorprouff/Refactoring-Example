using System;
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
        
        public string StatementHtml(Invoice invoice)
        {
            var data = new Data(
                invoice.Customer,
                invoice.Performances,
                _plays);
            
            return RenderHtml(data);
        }

        private string RenderPlainText(Data data)
        {
            var result = $"Statement for ${data.Customer} \n";

            result = data.Performances.Aggregate(result, (current, performance) =>
                current + $" {data.PlayFor(performance.PlayId).Name}: {data.AmmontFor(performance)} ({performance.Audience} seats) \n");

            result += $"Amount owed is {data.TotalAmount} \n";
            result += $"You earned {data.TotalVolumeCredits} credits\n";
            return result;
        }

        private string RenderHtml(Data data)
        {
            return "";
        }
    }
}