using Estatistica;

public class DispersionTest
{
    [Theory]
    [InlineData(1.5, new double[] { 4, 5, 7, 8 })]
    [InlineData(0.8, new double[] { 6, 7, 7, 8, 8, 8, 8, 9, 9, 10 })]
    public void MeanDeviation_ReturnsCalculatedMeanDeviation_ForAnArrayOfValues(double expected, double[] values)
    {
        // Given

        // When
        var meanDeviation = Dispersion.MeanDeviation(values);
        // Then
        Assert.True(meanDeviation != 0);
        Assert.Equal(expected, meanDeviation);
    }

    [Fact]
    public void MeanDeviationByFrequency_ReturnsCalculatedMeanDeviation_GivenAListOfValueRangesAndAnArrayOfFrequencies()
    {
        // Given

        var values = new List<double[]>(){
           new double[] {0.50 , 0.51},
           new double[] {0.51 , 0.52},
           new double[] {0.52 , 0.53},
           new double[] {0.53 , 0.54},
           new double[] {0.54 , 0.55},
           new double[] {0.55 , 0.56}
        };

        int[] frequency = new int[]
        {
            12,35,21,10,8, 1
        };
        var expected = "0.0098";
        // When
        var calculatedMeanDeviation = Dispersion.MeanDeviationByFrequency(values, frequency);
        // Then
        Assert.IsType<double>(calculatedMeanDeviation);
        Assert.Equal(expected, calculatedMeanDeviation.ToString("N4"));
    }

    [Theory]
    [InlineData(2, new double[] { 10, 9, 11, 12, 8 })]
    [InlineData(5.36, new double[] { 15, 12, 16, 10, 11 })]
    [InlineData(1.8399999999999999, new double[] { 11, 10, 8, 11, 12 })]
    [InlineData(6, new double[] { 8, 12, 15, 9, 11 })]
    public void Variance_ReturnsCalculatedVariance_ForAnArrayOfValues(double expected, double[] calcBase)
    {
        // Given

        // When
        var variance = Dispersion.Variance(calcBase);

        // Then
        Assert.Equal(expected, variance);
    }

    [Theory]
    [InlineData(0.09797958971132709, new double[] { 1.43, 1.25, 1.49, 1.33, 1.45 })]
    [InlineData(1.224744871391589, new double[] { 21, 22, 22, 21, 24 })]
    public void SampleStandardDeviation_ReturnsStandardDeviation_ForAnArrayOfValues(double expected, double[] values)
    {
        // Given

        // When
        var sample = Dispersion.SampleStandardDeviation(values);
        // Then
        Assert.True(sample != 0);
        Assert.Equal(expected, sample);
    }

    [Fact]
    public void StandardDeviationByFrequency_ReturnsStandardDeviation_GivenAnArrayOfValuesAndAnArrayOfFrequency()
    {
        // Given

        var values = new double[] { 2, 7, 12, 17, 22, 27, };
        var frequency = new int[] { 5, 8, 15, 12, 7, 3 };

        var expected = 19.41863366288507;
        // When
        var standardDeviation = Dispersion.StandardDeviationByFrequency(values, frequency);
        // Then
        Assert.True(standardDeviation != 0);
        Assert.Equal(expected, standardDeviation);
    }
}