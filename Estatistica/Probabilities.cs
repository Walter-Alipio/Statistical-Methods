namespace Estatistica;

public static class Probabilities
{

    public static double OccurrenceProbability(double @event, double sample)
    {
        return @event / sample;
    }

}