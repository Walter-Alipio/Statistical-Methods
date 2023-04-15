namespace Estatistica;

public static class CentralTendency
{
    public static double Mean(int[] values)
    {
        int denominator = values.Length;
        int numerator = 0;
        foreach (var value in values)
        {
            numerator += value;
        }

        return numerator / denominator;
    }

    public static double Mean(double[] values)
    {
        int denominator = values.Length;
        double numerator = 0;
        foreach (var value in values)
        {
            numerator += value;
        }

        return numerator / denominator;
    }

    public static double WeightedAverage(int[] values, int[] weight)
    {
        double numerator = 0.0;
        int denominator = 0;

        for (int i = 0; i < values.Length; i++)
        {
            numerator += values[i] * weight[i];

            denominator += weight[i];
        }

        return numerator / denominator;
    }

    public static double WeightedAverage(double[] values, int[] weight)
    {
        double numerator = 0.0;
        int denominator = 0;

        for (int i = 0; i < values.Length; i++)
        {
            numerator += values[i] * weight[i];

            denominator += weight[i];
        }

        return numerator / denominator;
    }

    public static double WeightAverageByFrequency(int[] values, int[] frequency)
    {
        double summation = 0.0;
        double divisor = 0.0;

        for (int i = 0; i < values.Length; i++)
        {
            summation += frequency[i] * values[i];
        }
        foreach (var item in frequency)
        {
            divisor += item;
        }

        return summation / divisor;
    }

    public static List<int> Mode(int[] values)
    {
        var frequency = Frequency(values);

        var highValue = frequency.MaxBy(x => x.Value).Value;

        if (frequency.Values.Count() == values.Length || frequency.Values.Count() == 1)
        {
            return new List<int>();
        }

        var mode = frequency.Where(x => x.Value == highValue).Select(x => x.Key).ToList();

        return mode.Order().ToList();
    }

    public static int ModeSingleOne(int[] frequency)
    {
        int mode = 0;
        int index = 0;
        for (int i = 0; i < frequency.Length; i++)
        {
            if (frequency[i] > frequency[index])
            {
                index = i;
                mode = frequency[i];
            }
        }
        return mode;
    }

    public static double Median(double[] values)
    {
        values = values.Order().ToArray();

        if (values.Length % 2 != 0)
        {
            double length = values.Length;
            double middle = Math.Ceiling(length / 2);
            return values[(int)(middle)];
        }

        var left = values.Take(values.Length / 2).ToArray();
        var right = values.Skip(values.Length / 2).ToArray();

        return (left[left.Length - 1] + right[0]) / 2;
    }

    public static double Median(int[] values)
    {
        values = values.Order().ToArray();

        if (values.Length % 2 != 0)
        {
            double middle = values.Length / 2;
            return values[(int)(middle)];
        }

        var left = values.Take(values.Length / 2).ToArray();
        var right = values.Skip(values.Length / 2).ToArray();

        return (left[left.Length - 1] + right[0]) / 2;
    }

    public static double Midpoint(int superiorLimit, int inferiorLimit)
    {
        return (superiorLimit + inferiorLimit) / 2;
    }

    public static double Midpoint(double superiorLimit, double inferiorLimit)
    {
        return (superiorLimit + inferiorLimit) / 2;
    }

    public static int[] Frequency(double[] values)
    {
        values = values.Order().ToArray();
        int index = 1;
        List<int> frequency = new List<int>();

        for (int i = 0; i < values.Length; i++)
        {
            var nextValue = i + 1;
            if (nextValue >= values.Length)
            {
                frequency.Add(index);
                break;
            }

            if (values[i] == values[nextValue])
            {
                index++;
            }

            frequency.Add(index);
            index = 1;
        }
        return frequency.ToArray();
    }

    public static Dictionary<int, int> Frequency(int[] values)
    {
        List<int> valuesList = new List<int>(values);

        return valuesList.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
    }

}