using System;
using System.Collections.Generic;
using System.Globalization;
using TheatricalPlayersRefactoringKata;

public class StatementPrinter
{
    public string Print(Invoice invoice, Dictionary<string, Play> plays)
    {
        var totalAmount = 0m;
        var volumeCredits = 0;
        var result = string.Format("Statement for {0}\n", invoice.Customer);
        CultureInfo cultureInfo = new CultureInfo("en-US");

        foreach (var perf in invoice.Performances)
        {
            var play = plays[perf.PlayId];
            PerformanceCalculator calculator = GetCalculator(perf, play);
            var thisAmount = calculator.CalculateAmount();
            volumeCredits += calculator.CalculateCredits();

            // print line for this order
            result += string.Format(cultureInfo, "  {0}: {1:C} ({2} seats)\n", play.Name, thisAmount / 100, perf.Audience);
            totalAmount += thisAmount;
        }
        result += string.Format(cultureInfo, "Amount owed is {0:C}\n", totalAmount / 100);
        result += string.Format("You earned {0} credits\n", volumeCredits);
        return result;
    }

    private PerformanceCalculator GetCalculator(Performance perf, Play play)
    {
        return play.Type switch
        {
            "tragedy" => new TragedyCalculator(perf, play),
            "comedy" => new ComedyCalculator(perf, play),
            "historical" => new HistoricalCalculator(perf, play),
            _ => throw new Exception("unknown type: " + play.Type)
        };
    }
}
