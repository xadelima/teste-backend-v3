using TheatricalPlayersRefactoringKata;

public abstract class PerformanceCalculator
{
    protected Performance Performance;
    protected Play Play;

    public PerformanceCalculator(Performance performance, Play play)
    {
        Performance = performance;
        Play = play;
    }

    public abstract decimal CalculateAmount();
    public abstract int CalculateCredits();
}

