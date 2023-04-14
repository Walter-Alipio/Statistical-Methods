namespace Estatistica;

public static class CombinatorialAnalysis
{
    public static double Factorial(int number)
    {
        if (number == 0 || number == 1) return 1;

        double fatorial = number;
        for (int i = 1; i < number; i++)
        {
            fatorial = (number - i) * fatorial;
        }
        return fatorial;
    }

    public static double Summations(int start, int end)
    {
        double summation = 0;
        for (int i = start; i < end; i++)
        {
            summation++;
        }
        return summation;
    }

    public static double Binomial(int numerator, int denominator)
    {
        if (numerator < 0 || denominator < 0)
        {
            throw new ArgumentException("The parameters should be positive integer numbers.");
        }
        return Factorial(numerator) / (Factorial(denominator) * Factorial(numerator - denominator));
    }

    public static double CountingPrinciple(int possibility, int steps)
    {
        return Math.Pow(possibility, steps);
    }

    public static double Arrangements(int numerator, int denominator)
    {
        if (numerator < 0 || denominator < 0)
        {
            throw new ArgumentException("The parameters should be positive integer numbers");
        }
        return Factorial(numerator) / Factorial(numerator - denominator);
    }

    public static double Combination(int elementos, int passo)
    {
        return Binomial(elementos, passo);
    }

    public static long CombinationLong(int elements, int step)
    {
        long result = 1;
        for (int i = 1; i <= step; i++)
        {
            result *= elements - step + i;
            result /= i;
        }
        return result;
    }
}