using System;
using FluentAssertions;
using Refactoring_Example.Models;
using Xunit;

namespace Refactoring_Example.Tests
{
    public class VideoClubStatementShould
    {
        [Fact]
        public void ValidStatement()
        {
            var invoice = new Invoice(
                "BigCo",
                performances: new[]
                {
                    new Performance(new Play("hamlet", "Hamlet", "tragedy"), 55),
                    new Performance(new Play("as-like", "As You Like It", "comedy"), 35),
                    new Performance(new Play("othello", "Othello", "tragedy"), 40)
                });

            var exemple = new VideoClubStatement();
            var result = exemple.Statement(invoice);

            var expected = "Statement for BigCo \n" +
                           " Hamlet: 650 (55 seats) \n" +
                           " As You Like It: 580 (35 seats) \n" +
                           " Othello: 500 (40 seats) \n" +
                           "Amount owed is 1730 \n" +
                           "You earned 47 credits\n";
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void ValidStatementHtml()
        {
            var invoice = new Invoice(
                "BigCo",
                performances: new[]
                {
                    new Performance(new Play("hamlet", "Hamlet", "tragedy"), 55),
                    new Performance(new Play("as-like", "As You Like It", "comedy"), 35),
                    new Performance(new Play("othello", "Othello", "tragedy"), 40)
                });

            var exemple = new VideoClubStatement();
            var result = exemple.StatementHtml(invoice);

            var expected = "<h1>Statement for BigCo </h1>\n" +
                           "<table>\n" +
                           "<tr><th>play</th><th>seats</th><th>cost</th></tr><tr><td>Hamlet</td><td>55</td><td>650</td></tr>\n" +
                           "<tr><td>As You Like It</td><td>35</td><td>580</td></tr>\n" +
                           "<tr><td>Othello</td><td>40</td><td>500</td></tr>\n" +
                           "</table>\n" +
                           "<p>Amount owed is <em>1730</em></p>\n" +
                           "<p>You earned <em>47</em> credits</p>\n";
            result.Should().BeEquivalentTo(expected);
        }
    }
}