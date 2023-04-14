namespace Estatistica;

public static class StatisticalInference
{
    public static decimal BinomialDistribution(int n, int x, double success, double fail)
    {
        var combination = CombinatorialAnalysis.Binomial(n, x);
        var probSuccess = Math.Pow(success, x);
        var probFail = Math.Pow(fail, (n - x));

        return (decimal)((combination * probSuccess * probFail) * 100);
    }

    public static double PearsonCorrelationCoefficient(int[] x, int[] y)
    {
        int amount = x.Length;
        List<int> xY = new List<int>();
        List<int> xSquare = new List<int>();
        List<int> ySquare = new List<int>();

        for (int i = 0; i < amount; i++)
        {
            xY.Add(x[i] * y[i]);
            xSquare.Add(x[i] * x[i]);
            ySquare.Add(y[i] * y[i]);
        }

        int xSum = x.Sum();
        int ySum = y.Sum();
        int xySum = xY.Sum();
        int xSquareSum = xSquare.Sum();
        int ySquareSum = ySquare.Sum();

        var numerator = amount * xySum - xSum * ySum;

        var partialValue = (amount * xSquareSum - (xSum * xSum)) *
            (amount * ySquareSum - (ySum * ySum));

        var denominator = Math.Sqrt(partialValue);

        double result = numerator / denominator;

        return result;
    }

    public static double LinearCorrelationCoefficient(int[] columX, int[] columY)
    {
        var amountOfLines = columX.Length;

        int columXSum = columX.Sum();

        int ColumYSum = columY.Sum();

        int ColumXMultiplyYSum = 0;

        int ColumXSquareSum = 0;

        int ColumYSquareSum = 0;

        for (int i = 0; i < amountOfLines; i++)
        {
            ColumXMultiplyYSum += columX[i] * columY[i];

            ColumXSquareSum += columX[i] * columX[i];

            ColumYSquareSum += columY[i] * columY[i];
        }

        double numerator = amountOfLines * ColumXMultiplyYSum - columXSum * ColumYSum;

        double denominator = Math.Sqrt(amountOfLines * ColumXSquareSum - (columXSum * columXSum)) *
                                Math.Sqrt(amountOfLines * ColumYSquareSum - (ColumYSum * ColumYSum));

        return numerator / denominator;
    }

}