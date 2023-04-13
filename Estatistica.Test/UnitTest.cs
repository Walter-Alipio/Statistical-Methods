namespace Estatistica.Test;

public class UnitTest1
{
    [Theory]
    [InlineData(15, new int[] { 10, 18, 11, 15, 20, 21, 16, 10, 8, 20, 16, 22 })]
    [InlineData(31, new int[] { 23, 34, 30, 22, 34, 53, 34, 28, 30, 22 })]
    public void Media_ReturnIntValue(int expected, int[] valores)
    {
        //Arrange
        var estatistica = new EstatisticaClass();
        //Act
        var media = estatistica.MediaSimples(valores);
        //Assert
        Assert.IsType<double>(media);
        Assert.Equal(expected, media);
    }

    [Theory]
    [InlineData(16, new int[] { 10, 18, 11, 15, 20, 21, 16, 10, 8, 20, 16, 22 })]
    [InlineData(30, new int[] { 23, 34, 30, 22, 34, 53, 34, 28, 30, 22 })]
    public void Mediana_ReturnIntValue(int expected, int[] values)
    {
        // Given
        var estatistica = new EstatisticaClass();

        // When
        var mediana = estatistica.Mediana(values);

        // Then
        Assert.IsType<double>(mediana);
        Assert.Equal(expected, mediana);
    }

    [Theory]
    [InlineData(new int[] { 10, 16, 20 }, new int[] { 10, 18, 11, 15, 20, 21, 16, 10, 8, 20, 16, 22 })]
    [InlineData(new int[] { 34 }, new int[] { 23, 34, 30, 22, 34, 53, 34, 28, 30, 22 })]
    public void Moda_ReturnListInt(int[] expected, int[] values)
    {
        // Given
        var estatistica = new EstatisticaClass();

        // When
        var moda = estatistica.Moda(values);
        // Then
        Assert.NotEmpty(moda);
        Assert.Equal(expected, moda);
    }

    [Fact]
    public void Moda_RetunsEmpytList_WhenThereIsNoModa()
    {
        // Given
        var estatistica = new EstatisticaClass();

        var expected = new List<int>();

        int[] values = new int[] { 10, 10, 10 };

        var frequencia = estatistica.Frequencia(values);

        // When
        var moda = estatistica.Moda(values);
        // Then
        Assert.Empty(moda);
        Assert.Equal(expected, moda);
    }

    [Theory]
    [InlineData(2, new double[] { 10, 9, 11, 12, 8 })]
    [InlineData(5.36, new double[] { 15, 12, 16, 10, 11 })]
    [InlineData(1.8399999999999999, new double[] { 11, 10, 8, 11, 12 })]
    [InlineData(6, new double[] { 8, 12, 15, 9, 11 })]
    public void Variancia_ReturnsDoubleValue(double expected, double[] calcBase)
    {
        // Given
        var estatistica = new EstatisticaClass();

        // When
        var variancia = estatistica.Variancia(calcBase);

        // Then
        Assert.Equal(expected, variancia);
    }

    [Theory]
    [InlineData(0.09797958971132709, new double[] { 1.43, 1.25, 1.49, 1.33, 1.45 })]
    [InlineData(1.224744871391589, new double[] { 21, 22, 22, 21, 24 })]
    public void DesvioPadraoAmostral_ReturnsDoubleValue(double expected, double[] values)
    {
        // Given
        var estatistica = new EstatisticaClass();
        // When
        var desvioPadraoAmostral = estatistica.DesvioPadraoAmostral(values);
        // Then
        Assert.True(desvioPadraoAmostral != 0);
        Assert.Equal(expected, desvioPadraoAmostral);
    }

    [Theory]
    [InlineData(34500, new int[] { 30000, 50000, 25000 }, new int[] { 4, 3, 3 })]
    public void MediaPonderada_ReturnsDoubleValue(double expected, int[] valores, int[] pesos)
    {
        // Given
        var estatistica = new EstatisticaClass();
        // When
        var mediaPonderada = estatistica.MediaPonderada(valores, pesos);
        // Then
        Assert.True(mediaPonderada != 0);
        Assert.Equal(expected, mediaPonderada);
    }

    [Theory]
    [InlineData(1.5, new double[] { 4, 5, 7, 8 })]
    [InlineData(0.8, new double[] { 6, 7, 7, 8, 8, 8, 8, 9, 9, 10 })]
    public void DesvioMedioSimples_ReturnsDoubleValue(double expected, double[] values)
    {
        // Given
        var estatistica = new EstatisticaClass();
        // When
        var desvioMedioSimples = estatistica.DesvioMedioSimples(values);
        // Then
        Assert.True(desvioMedioSimples != 0);
        Assert.Equal(expected, desvioMedioSimples);
    }

    [Fact]
    public void DesvioMedioPorFrequencia_ReturnsDoubleValue()
    {
        // Given
        var estatistica = new EstatisticaClass();

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
        var desvioMedio = estatistica.DesvioMedioPorFrequencia(values, frequency);
        // Then
        Assert.IsType<double>(desvioMedio);
        Assert.Equal(expected, desvioMedio.ToString("N4"));
    }

    [Theory]
    [InlineData(27, 30, 25)]
    [InlineData(22, 25, 20)]
    public void PontoMedio_ReturnsDoubleValue(double expected, int limiteSup, int limiteInf)
    {
        // Given
        var estatistica = new EstatisticaClass();
        // When
        var pontoMedio = estatistica.PontoMedio(limiteSup, limiteInf);
        // Then
        Assert.True(pontoMedio != 0);
        Assert.Equal(expected, pontoMedio);
    }
    [Theory]
    [InlineData(27.5, 30.0, 25.0)]
    public void PontoMedioDouble_ReturnsDoubleValue(double expected, double limiteSup, double limiteInf)
    {
        // Given
        var estatistica = new EstatisticaClass();
        // When
        var pontoMedio = estatistica.PontoMedio(limiteSup, limiteInf);
        // Then
        Assert.True(pontoMedio != 0);
        Assert.Equal(expected, pontoMedio);
    }

    [Fact]
    public void DesvioPadrao_ReturnsDoubleValue()
    {
        // Given
        var estatistica = new EstatisticaClass();

        var values = new double[] { 2, 7, 12, 17, 22, 27, };
        var frequency = new int[] { 5, 8, 15, 12, 7, 3 };

        var expected = 19.41863366288507;
        // When
        var desvioPadrao = estatistica.DesvioPadrao(values, frequency);
        // Then
        Assert.True(desvioPadrao != 0);
        Assert.Equal(expected, desvioPadrao);
    }

    [Theory]
    [InlineData(120, 5)]
    [InlineData(5040, 7)]
    public void Fatorial_ReturnsDoubleValue(double expected, int value)
    {
        // Given
        var estatistica = new EstatisticaClass();

        // When
        var fatorial = estatistica.Fatorial(value);
        // Then
        Assert.True(fatorial != 0);
        Assert.Equal(expected, fatorial);
    }

    [Theory]
    [InlineData(10.0, 5, 2)]
    [InlineData(45.0, 10, 8)]
    public void Binomial_ReturnsDoubleValue(double expected, int numerator, int denominator)
    {
        // Given
        var estatistica = new EstatisticaClass();
        // When
        var binomial = estatistica.Binomial(numerator, denominator);
        // Then
        Assert.Equal(expected, binomial);
    }
    [Fact]
    public void Binomial_ReturnsArgumentException_WhenValuesAreNegative()
    {
        // Given
        var estatistica = new EstatisticaClass();
        var expected = "Os parâmetros devem ser números inteiros positivos";
        // When
        // Then
        Assert.Throws<ArgumentException>(() => estatistica.Binomial(-5, -2));
        var exceptionMessage = Assert.Throws<ArgumentException>(() => estatistica.Binomial(-5, -2));
        Assert.Equal(expected, exceptionMessage.Message);
    }

    [Theory]
    [InlineData(6, 3, 2)]
    [InlineData(720, 10, 3)]
    [InlineData(3024, 9, 4)]
    public void ArranjoSimples_ReturnsDoubleValue(double expected, int numerador, int denominador)
    {
        // Given
        var estatistica = new EstatisticaClass();
        // When
        var arranjoSimples = estatistica.ArranjoSimples(numerador, denominador);
        // Then
        Assert.True(arranjoSimples != 0);
        Assert.Equal(expected, arranjoSimples);
    }

    [Theory]
    [InlineData(792, 12, 5)]
    [InlineData(455, 15, 12)]
    public void CombinacaoSimples_ReturnsDoubleValue(double expected, int elements, int step)
    {
        // Given
        var estatistica = new EstatisticaClass();
        // When
        var combinacaoSimples = estatistica.CombinacaoSimples(elements, step);
        // Then
        Assert.Equal(expected, combinacaoSimples);
    }

    [Theory]
    [InlineData(0.5, 3, 6)]
    [InlineData(0.4, 4, 10)]
    [InlineData(0.5, 3, 6)]
    [InlineData(0.5, 3, 6)]
    [InlineData(0.0026, 52, 20000)]
    [InlineData(0.0013, 26, 20000)]
    public void ProbabilidadeOcorrencia_ReturnsDoubleValue(double expected, double events, double sample)
    {
        // Given
        var estatistica = new EstatisticaClass();
        // When
        var probabilidadeDeOcorrencia = estatistica.ProbabilidadeOcorrencia(events, sample);
        // Then
        Assert.Equal(expected, probabilidadeDeOcorrencia);
    }

    [Fact]
    public void CombinacaoSimplesLong_ReturnsLongValue()
    {
        // Given
        var estatistica = new EstatisticaClass();
        var expected = 50063860;
        // When
        var combinacaoSimplesLong = estatistica.CombinacaoSimplesLong(60, 6);
        // Then
        Assert.Equal(expected, combinacaoSimplesLong);
    }

    [Fact]
    public void CoeficienteDeCorrelacaoDePearson_ReturnsDoubleValue()
    {
        // Given
        var estatistica = new EstatisticaClass();

        var x = new int[] { 3, 5, 8, 13, 16, 17, 20, 22 };
        var y = new int[] { 6, 17, 27, 20, 45, 28, 34, 53 };

        var expected = 0.84644093213224;
        // When
        var coeficienteDePearson = estatistica.CoeficienteDeCorrecaoDePearson(x, y);
        // Then
        Assert.Equal(expected, coeficienteDePearson);
    }

    [Theory]
    [InlineData(-0.7745966692414834, new int[] { 1, 2, 3, 4 }, new int[] { 1, 1, 1, 0 })]
    [InlineData(0.9669875568304563, new int[] { 1, 3, 2, 1 }, new int[] { 2, 6, 3, 1 })]
    public void CoeficienteDeCorrelacaoLinear_ReturnsDoubleValue(double expected, int[] x, int[] y)
    {
        // Given
        var estatistica = new EstatisticaClass();

        // When
        var coeficienteDeCorrelacaoLinear = estatistica.CoeficienteDeCorrelacaoLinear(x, y);

        // Then
        Assert.Equal(expected, coeficienteDeCorrelacaoLinear);
    }

    [Theory]
    [InlineData(0.0000567894470833484, 31, 10, 0.75, 0.25)]
    [InlineData(0.000424087760505323, 100, 6, 0.06, 0.84)]
    public void DistribuicaoBinomial_ReturnsDecimalValue(decimal expected, int n, int x, double success, double fail)
    {
        // Given
        var estatistica = new EstatisticaClass();
        // When
        var distribuicaoBinomial = estatistica.DistribuicaoBinomial(n, x, success, fail);
        // Then
        Assert.Equal(expected, distribuicaoBinomial);
    }

}