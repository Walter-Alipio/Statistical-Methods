namespace Estatistica;

public static class Probabilities
{

    public static double OccurrenceProbability(double @event, double sample)
    {
        return @event / sample;
    }

    public static double ProbabilityOfFail(double @event, double sample)
    {
        return (sample - @event) / sample;
    }

}