namespace Estatistica.Test;

public class StatisticalInferenceTest
{

    [Fact]
    public void PearsonCorrelationCoefficient_ReturnsCorrelationOfPearsonValue_ForColXValuesAndColYValues()
    {
        // Given

        var colX = new int[] { 3, 5, 8, 13, 16, 17, 20, 22 };
        var colY = new int[] { 6, 17, 27, 20, 45, 28, 34, 53 };

        var expected = 0.84644093213224;
        // When
        var pearsonCorrelationCoefficient = StatisticalInference.PearsonCorrelationCoefficient(colX, colY);
        // Then
        Assert.Equal(expected, pearsonCorrelationCoefficient);
    }

    [Theory]
    [InlineData(-0.7745966692414834, new int[] { 1, 2, 3, 4 }, new int[] { 1, 1, 1, 0 })]
    [InlineData(0.9669875568304563, new int[] { 1, 3, 2, 1 }, new int[] { 2, 6, 3, 1 })]
    public void LinearCorrelationCoefficient_ReturnsCorrelationValue_ForColXValuesAndColYValues(double expected, int[] colX, int[] colY)
    {
        // Given

        // When
        var linearCorrelationCoefficient = StatisticalInference.LinearCorrelationCoefficient(colX, colY);

        // Then
        Assert.Equal(expected, linearCorrelationCoefficient);
    }

    [Theory]
    [InlineData(0.0000567894470833484, 31, 10, 0.75)]
    [InlineData(0.152499399025936, 100, 6, 0.16)]
    public void BinomialDistribution_ReturnsDistributionValue_GivenNumberOfAttemptsTargetValueAndSuccessProbability(decimal expected, int attempts, int target, double success)
    {
        // Given

        // When
        var binomialDistribution = StatisticalInference.BinomialDistribution(attempts, target, success);
        // Then
        Assert.Equal(expected, binomialDistribution);
    }

}