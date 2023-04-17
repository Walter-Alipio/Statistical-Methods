using Estatistica;

public class CombinatorialAnalysisTest
{
    [Theory]
    [InlineData(120, 5)]
    [InlineData(5040, 7)]
    public void Factorial_ReturnsDoubleValue(double expected, int value)
    {
        // Given

        // When
        var factorial = CombinatorialAnalysis.Factorial(value);
        // Then
        Assert.True(factorial != 0);
        Assert.Equal(expected, factorial);
    }

    [Theory]
    [InlineData(10.0, 5, 2)]
    [InlineData(45.0, 10, 8)]
    public void Binomial_ReturnsDoubleValue(double expected, int numerator, int denominator)
    {
        // Given

        // When
        var binomial = CombinatorialAnalysis.Binomial(numerator, denominator);
        // Then
        Assert.Equal(expected, binomial);
    }
    [Fact]
    public void Binomial_ReturnsArgumentException_WhenValuesAreNegative()
    {
        // Given

        var expected = "The parameters should be positive integer numbers.";
        // When
        // Then
        Assert.Throws<ArgumentException>(() => CombinatorialAnalysis.Binomial(-5, -2));
        var exceptionMessage = Assert.Throws<ArgumentException>(() => CombinatorialAnalysis.Binomial(-5, -2));
        Assert.Equal(expected, exceptionMessage.Message);
    }

    [Theory]
    [InlineData(6, 3, 2)]
    [InlineData(720, 10, 3)]
    [InlineData(3024, 9, 4)]
    public void Arrangements_ReturnsDoubleValue(double expected, int numerator, int denominator)
    {
        // Given

        // When
        var arranjoSimples = CombinatorialAnalysis.Arrangements(numerator, denominator);
        // Then
        Assert.True(arranjoSimples != 0);
        Assert.Equal(expected, arranjoSimples);
    }

    [Theory]
    [InlineData(792, 12, 5)]
    [InlineData(455, 15, 12)]
    public void Combination_ReturnsCalculatedCombination_GivenNumberOfElementsAndSteps(double expected, int elements, int step)
    {
        // Given

        // When
        var CalculatedCombination = CombinatorialAnalysis.Combination(elements, step);
        // Then
        Assert.Equal(expected, CalculatedCombination);
    }

    [Fact]
    public void CombinationLong_ReturnsCalculatedCombinationValue_AsTypeLong()
    {
        // Given

        var expected = 50063860;
        // When
        var combinacaoSimplesLong = CombinatorialAnalysis.CombinationLong(60, 6);
        // Then
        Assert.Equal(expected, combinacaoSimplesLong);
    }

    [Fact]
    public void CountingPrinciple_ReturnsTotalOfPossibilities_ForEqualPossibilitiesAndAmountOfSteps()
    {
        // Given

        var possibilities = 10;
        var steps = 4;

        var expected = 10000.0;
        // When 

        var pfc = CombinatorialAnalysis.CountingPrincipleForEqualProbabilities(possibilities, steps);
        // Then
        Assert.Equal(expected, pfc);
    }
}