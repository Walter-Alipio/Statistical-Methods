namespace Estatistica;

public static class Dispersion
{

    public static double Amplitude(int superiorLimit, int inferiorLimit)
    {
        return superiorLimit - inferiorLimit;
    }

    public static double MeanDeviation(double[] values)
    {
        var amount = values.Length;
        var mean = CentralTendency.Mean(values);
        double summation = 0;
        foreach (var value in values)
        {
            var aux = value - mean;
            if (aux < 0) aux *= -1;

            summation += aux;
        }

        return summation / amount;
    }

    public static double MeanDeviationByFrequency(List<double[]> valuesList, int[] frequency)
    {
        List<double> midpoint = new List<double>();

        foreach (var item in valuesList)
        {
            midpoint.Add(CentralTendency.Midpoint(item[0], item[1]));
        }

        var weightAverage = CentralTendency.WeightedAverage(midpoint.ToArray(), frequency);

        var numerator = 0.0;
        int weightList = midpoint.Count();

        for (int i = 0; i < weightList; i++)
        {
            var aux = midpoint[i] - weightAverage;
            if (aux < 0) aux *= -1;

            numerator += aux * frequency[i];
        }
        var denominator = frequency.Sum();

        return numerator / denominator;
    }

    public static double Variance(double[] calculusBase)
    {
        var mean = CentralTendency.Mean(calculusBase);
        List<double> variance = new();

        foreach (var item in calculusBase)
        {
            variance.Add(Math.Pow((item - mean), 2));
        }
        return CentralTendency.Mean(variance.ToArray());
    }

    public static double StandardDeviation(double[] values)
    {
        var amount = values.Length;
        var mean = CentralTendency.Mean(values);
        double summation = 0;
        foreach (var valor in values)
        {
            summation += Math.Pow((valor - mean), 2);
        }

        return Math.Sqrt(summation / amount);
    }

    public static double StandardDeviationByFrequency(double[] midpoint, int[] frequency)
    {
        var amount = midpoint.Length;
        var media = CentralTendency.Mean(midpoint);
        double summation = 0;

        for (int i = 0; i < midpoint.Length; i++)
        {
            summation += Math
                .Pow((midpoint[i] - media), 2)
                * frequency[i];
        }

        return Math.Sqrt(summation / amount);
    }

    public static double SampleStandardDeviation(double[] values)
    {
        var amount = values.Length;
        var mean = CentralTendency.Mean(values);
        double summation = 0;
        foreach (var valor in values)
        {
            summation += Math.Pow((valor - mean), 2);
        }

        return Math.Sqrt(summation / (amount - 1));
    }

}