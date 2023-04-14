using Estatistica;

public class ProbabilitiesTest
{
    [Theory]
    [InlineData(0.5, 3, 6)]
    [InlineData(0.4, 4, 10)]
    [InlineData(0.0026, 52, 20000)]
    [InlineData(0.0013, 26, 20000)]
    public void OccurrenceProbability_ReturnsDoubleValue(double expected, double events, double sample)
    {
        // Given

        // When
        var occurrenceProbability = Probabilities.OccurrenceProbability(events, sample);
        // Then
        Assert.Equal(expected, occurrenceProbability);
    }
}