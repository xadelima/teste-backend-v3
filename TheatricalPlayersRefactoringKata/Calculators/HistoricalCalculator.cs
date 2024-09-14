using TheatricalPlayersRefactoringKata;

public class HistoricalCalculator : PerformanceCalculator
{
    public HistoricalCalculator(Performance performance, Play play) : base(performance, play) {}

    public override decimal CalculateAmount()
    {
        // Combinação de tragédia e comédia
        var tragedyAmount = new TragedyCalculator(Performance, Play).CalculateAmount();
        var comedyAmount = new ComedyCalculator(Performance, Play).CalculateAmount();
        return tragedyAmount + comedyAmount;
    }

    public override int CalculateCredits()
    {
        return new TragedyCalculator(Performance, Play).CalculateCredits() +
               new ComedyCalculator(Performance, Play).CalculateCredits();
    }
}
