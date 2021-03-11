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
            var result = $"<h1>Statement for ${data.Customer} </h1>\n";
            result += "<table>\n";
            result += "<tr><th>play</th><th>seats</th><th>cost</th></tr>";
            
            result = data.Performances.Aggregate(result, (current, performance) => 
                current + $"<tr><td>{data.PlayFor(performance.PlayId).Name}</td><td>{performance.Audience}</td><td>{data.AmmontFor(performance)}</td></tr>\n");

            result += "</table>\n";

            result += $"<p>Amount owed is <em>{data.TotalAmount}</em></p>\n";
            result += $"<p>You earned <em>{data.TotalVolumeCredits}</em> credits</p>\n";
            return result;
        }
    }
}