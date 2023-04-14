

using Estatistica;

public class CentralTendencyTests
{
    [Theory]
    [InlineData(15, new int[] { 10, 18, 11, 15, 20, 21, 16, 10, 8, 20, 16, 22 })]
    [InlineData(31, new int[] { 23, 34, 30, 22, 34, 53, 34, 28, 30, 22 })]
    public void Mean_ReturnIntValue(int expected, int[] values)
    {
        //Arrange

        //Act
        var mean = CentralTendency.Mean(values);
        //Assert
        Assert.IsType<double>(mean);
        Assert.Equal(expected, mean);
    }

    [Theory]
    [InlineData(16, new int[] { 10, 18, 11, 15, 20, 21, 16, 10, 8, 20, 16, 22 })]
    [InlineData(30, new int[] { 23, 34, 30, 22, 34, 53, 34, 28, 30, 22 })]
    public void Median_ReturnIntValue(int expected, int[] values)
    {
        // Given

        // When
        var median = CentralTendency.Median(values);

        // Then
        Assert.IsType<double>(median);
        Assert.Equal(expected, median);
    }

    [Theory]
    [InlineData(new int[] { 10, 16, 20 }, new int[] { 10, 18, 11, 15, 20, 21, 16, 10, 8, 20, 16, 22 })]
    [InlineData(new int[] { 34 }, new int[] { 23, 34, 30, 22, 34, 53, 34, 28, 30, 22 })]
    public void Mode_ReturnListInt(int[] expected, int[] values)
    {
        // Given

        // When
        var moda = CentralTendency.Mode(values);
        // Then
        Assert.NotEmpty(moda);
        Assert.Equal(expected, moda);
    }

    [Fact]
    public void Mode_RetunsEmpytList_WhenThereIsNoMode()
    {
        // Given

        var expected = new List<int>();

        int[] values = new int[] { 10, 10, 10 };

        var frequency = CentralTendency.Frequency(values);

        // When
        var mode = CentralTendency.Mode(values);
        // Then
        Assert.Empty(mode);
        Assert.Equal(expected, mode);
    }

    [Theory]
    [InlineData(34500, new int[] { 30000, 50000, 25000 }, new int[] { 4, 3, 3 })]
    public void WeightAverage_ReturnsDoubleValue(double expected, int[] valores, int[] pesos)
    {
        // Given

        // When
        var weightAverage = CentralTendency.WeightedAverage(valores, pesos);
        // Then
        Assert.True(weightAverage != 0);
        Assert.Equal(expected, weightAverage);
    }


    [Theory]
    [InlineData(27, 30, 25)]
    [InlineData(22, 25, 20)]
    public void Midpoint_ReturnsDoubleValue(double expected, int limiteSup, int limiteInf)
    {
        // Given

        // When
        var midpoint = CentralTendency.Midpoint(limiteSup, limiteInf);
        // Then
        Assert.True(midpoint != 0);
        Assert.Equal(expected, midpoint);
    }
    [Theory]
    [InlineData(27.5, 30.0, 25.0)]
    public void MidpointDouble_ReturnsDoubleValue(double expected, double limiteSup, double limiteInf)
    {
        // Given

        // When
        var midpoint = CentralTendency.Midpoint(limiteSup, limiteInf);
        // Then
        Assert.True(midpoint != 0);
        Assert.Equal(expected, midpoint);
    }
}