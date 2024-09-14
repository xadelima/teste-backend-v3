using System;
namespace TheatricalPlayersRefactoringKata.Calculators;

public class ComedyCalculator : PerformanceCalculator
{
    public ComedyCalculator(Performance performance, Play play) : base(performance, play) { }

    public override decimal CalculateAmount()
    {
        decimal baseAmount = Math.Max(1000, Math.Min(4000, Play.Lines / 10));
        baseAmount += 3 * Performance.Audience;
        if (Performance.Audience > 20)
        {
            baseAmount += 100 + 5 * (Performance.Audience - 20);
        }
        return baseAmount;
    }

    public override int CalculateCredits()
    {
        return Math.Max(Performance.Audience - 30, 0) + Performance.Audience / 5;
    }
}