using System.Linq;
namespace Estatistica;

public class EstatisticaClass
{
    public double MediaSimples(int[] valores)
    {
        int denominador = valores.Length;
        int numerador = 0;
        foreach (var valor in valores)
        {
            numerador += valor;
        }

        return numerador / denominador;
    }

    public double MediaSimples(double[] valores)
    {
        int denominador = valores.Length;
        double numerador = 0;
        foreach (var valor in valores)
        {
            numerador += valor;
        }

        return numerador / denominador;
    }

    public double MediaPonderada(int[] valores, int[] pesos)
    {
        double numerador = 0.0;
        int denominador = 0;

        for (int i = 0; i < valores.Length; i++)
        {
            numerador += valores[i] * pesos[i];

            denominador += pesos[i];
        }

        return numerador / denominador;
    }

    public double MediaPonderada(double[] valores, int[] pesos)
    {
        double numerador = 0.0;
        int denominador = 0;

        for (int i = 0; i < valores.Length; i++)
        {
            numerador += valores[i] * pesos[i];

            denominador += pesos[i];
        }

        return numerador / denominador;
    }

    public double MediaPonderadaPorFrequencia(int[] valores, int[] frequencia)
    {
        double somatorio = 0.0;
        double divisor = 0.0;

        for (int i = 0; i < valores.Length; i++)
        {
            somatorio += frequencia[i] * valores[i];
        }
        foreach (var item in frequencia)
        {
            divisor += item;
        }

        return somatorio / divisor;
    }

    public int[] Frequencia(double[] valores)
    {
        valores = valores.Order().ToArray();
        int index = 1;
        List<int> frequencia = new List<int>();

        for (int i = 0; i < valores.Length; i++)
        {
            var nextValue = i + 1;
            if (nextValue >= valores.Length)
            {
                frequencia.Add(index);
                break;
            }

            if (valores[i] == valores[nextValue])
            {
                index++;
            }

            frequencia.Add(index);
            index = 1;
        }
        return frequencia.ToArray();
    }

    public Dictionary<int, int> Frequencia(int[] valores)
    {
        List<int> valoresList = new List<int>(valores);

        return valoresList.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
    }

    public double PontoMedio(int limiteSuperior, int limiteInferior)
    {
        return (limiteSuperior + limiteInferior) / 2;
    }

    public double PontoMedio(double limiteSuperior, double limiteInferior)
    {
        return (limiteSuperior + limiteInferior) / 2;
    }

    public double Mediana(double[] valores)
    {
        valores = valores.Order().ToArray();

        if (valores.Length % 2 != 0)
        {
            double length = valores.Length;
            double meio = Math.Ceiling(length / 2);
            return valores[(int)(meio)];
        }

        var esquerda = valores.Take(valores.Length / 2).ToArray();
        var direita = valores.Skip(valores.Length / 2).ToArray();

        return (esquerda[esquerda.Length - 1] + direita[0]) / 2;
    }

    public double Mediana(int[] valores)
    {
        valores = valores.Order().ToArray();

        if (valores.Length % 2 != 0)
        {
            double meio = valores.Length / 2;
            return valores[(int)(meio)];
        }

        var esquerda = valores.Take(valores.Length / 2).ToArray();
        var direita = valores.Skip(valores.Length / 2).ToArray();

        return (esquerda[esquerda.Length - 1] + direita[0]) / 2;
    }

    public double Amplitude(int limiteSuperior, int limiteInferior)
    {
        return limiteSuperior - limiteInferior;
    }

    public List<int> Moda(int[] valores)
    {
        var frequencia = this.Frequencia(valores);

        var maiorValor = frequencia.MaxBy(x => x.Value).Value;

        if (frequencia.Values.Count() == valores.Length || frequencia.Values.Count() == 1)
        {
            return new List<int>();
        }

        var moda = frequencia.Where(x => x.Value == maiorValor).Select(x => x.Key).ToList();

        return moda.Order().ToList();
    }

    public int Moda(double[] numeros, int[] frequencia)
    {
        int moda = 0;
        int index = 0;
        for (int i = 0; i < frequencia.Length; i++)
        {
            if (frequencia[i] > frequencia[index])
            {
                index = i;
                moda = frequencia[i];
            }
        }
        return moda;
    }

    public double DesvioMedioSimples(double[] valores)
    {
        var quantidade = valores.Length;
        var media = this.MediaSimples(valores);
        double somatorio = 0;
        foreach (var valor in valores)
        {
            var aux = valor - media;
            if (aux < 0) aux *= -1;

            somatorio += aux;
        }

        return somatorio / quantidade;
    }

    public double DesvioMedioPorFrequencia(List<double[]> listaValores, int[] frequencia)
    {
        List<double> pontoMedio = new List<double>();

        foreach (var item in listaValores)
        {
            pontoMedio.Add(this.PontoMedio(item[0], item[1]));
        }

        var mediaPonderada = this.MediaPonderada(pontoMedio.ToArray(), frequencia);

        var numerador = 0.0;
        int tamanhoLista = pontoMedio.Count();

        for (int i = 0; i < tamanhoLista; i++)
        {
            var aux = pontoMedio[i] - mediaPonderada;
            if (aux < 0) aux *= -1;

            numerador += aux * frequencia[i];
        }
        var denominador = frequencia.Sum();

        return numerador / denominador;
    }

    public double Variancia(double[] baseDeCalculo)
    {
        var media = this.MediaSimples(baseDeCalculo);
        List<double> variancia = new();

        foreach (var item in baseDeCalculo)
        {
            variancia.Add(Math.Pow((item - media), 2));
        }
        return this.MediaSimples(variancia.ToArray());
    }

    public double DesvioPadrao(double[] valores)
    {
        var quantidade = valores.Length;
        var media = this.MediaSimples(valores);
        double somatorio = 0;
        foreach (var valor in valores)
        {
            somatorio += Math.Pow((valor - media), 2);
        }

        return Math.Sqrt(somatorio / quantidade);
    }

    public double DesvioPadrao(double[] pontoMedio, int[] frequencia)
    {
        var quantidade = pontoMedio.Length;
        var media = this.MediaSimples(pontoMedio);
        double somatorio = 0;

        for (int i = 0; i < pontoMedio.Length; i++)
        {
            somatorio += Math
                .Pow((pontoMedio[i] - media), 2)
                * frequencia[i];
        }

        return Math.Sqrt(somatorio / quantidade);
    }

    public double DesvioPadraoAmostral(double[] valores)
    {
        var quantidade = valores.Length;
        var media = this.MediaSimples(valores);
        double somatorio = 0;
        foreach (var valor in valores)
        {
            somatorio += Math.Pow((valor - media), 2);
        }

        return Math.Sqrt(somatorio / (quantidade - 1));
    }

    public double Fatorial(int number)
    {
        if (number == 0 || number == 1) return 1;

        double fatorial = number;
        for (int i = 1; i < number; i++)
        {
            fatorial = (number - i) * fatorial;
        }
        return fatorial;
    }

    public double Somatorio(int initial, int final)
    {
        double somatorio = 0;
        for (int i = initial; i < final; i++)
        {
            somatorio++;
        }
        return somatorio;
    }

    public double Binomial(int numerador, int denominador)
    {
        if (numerador < 0 || denominador < 0)
        {
            throw new ArgumentException("Os parâmetros devem ser números inteiros positivos");
        }
        return this.Fatorial(numerador) / (this.Fatorial(denominador) * this.Fatorial(numerador - denominador));
    }

    public double ArranjoSimples(int numerador, int denominador)
    {
        if (numerador < 0 || denominador < 0)
        {
            throw new ArgumentException("Os parâmetros devem ser números inteiros");
        }
        return this.Fatorial(numerador) / this.Fatorial(numerador - denominador);
    }

    public double CombinacaoSimples(int elementos, int passo)
    {
        return this.Binomial(elementos, passo);
    }

    public long CombinacaoSimplesLong(int elementos, int passo)
    {
        long result = 1;
        for (int i = 1; i <= passo; i++)
        {
            result *= elementos - passo + i;
            result /= i;
        }
        return result;
    }

    public double ProbabilidadeOcorrencia(double evento, double amostra)
    {
        return evento / amostra;
    }

    public decimal DistribuicaoBinomial(int n, int x, double sucesso, double falha)
    {
        var combinacao = this.Binomial(n, x);
        var probSucess = Math.Pow(sucesso, x);
        var probFail = Math.Pow(falha, (n - x));

        return (decimal)((combinacao * probSucess * probFail) * 100);
    }

    public double CoeficienteDeCorrecaoDePearson(int[] x, int[] y)
    {
        int tamanho = x.Length;
        List<int> xY = new List<int>();
        List<int> xQuadrado = new List<int>();
        List<int> yQuadrado = new List<int>();

        for (int i = 0; i < tamanho; i++)
        {
            xY.Add(x[i] * y[i]);
            xQuadrado.Add(x[i] * x[i]);
            yQuadrado.Add(y[i] * y[i]);
        }

        int xSum = x.Sum();
        int ySum = y.Sum();
        int xySum = xY.Sum();
        int xQuadradoSum = xQuadrado.Sum();
        int yQuadradoSum = yQuadrado.Sum();

        var numerador = tamanho * xySum - xSum * ySum;

        var partialValue = (tamanho * xQuadradoSum - (xSum * xSum)) *
            (tamanho * yQuadradoSum - (ySum * ySum));

        var denominador = Math.Sqrt(partialValue);

        double result = numerador / denominador;

        return result;
    }

    public double CoeficienteDeCorrelacaoLinear(int[] colunaX, int[] colunaY)
    {
        var quantidadeLinhas = colunaX.Length;

        int somaDeColunaX = colunaX.Sum();

        int somaDeColunaY = colunaY.Sum();

        int somaDeColunasXMutiplicaY = 0;

        int somaDeColunaXquadrado = 0;

        int somaDeColunaYquadrado = 0;

        for (int i = 0; i < quantidadeLinhas; i++)
        {
            somaDeColunasXMutiplicaY += colunaX[i] * colunaY[i];

            somaDeColunaXquadrado += colunaX[i] * colunaX[i];

            somaDeColunaYquadrado += colunaY[i] * colunaY[i];
        }

        double numerador = quantidadeLinhas * somaDeColunasXMutiplicaY - somaDeColunaX * somaDeColunaY;

        double denominador = Math.Sqrt(quantidadeLinhas * somaDeColunaXquadrado - (somaDeColunaX * somaDeColunaX)) *
                                Math.Sqrt(quantidadeLinhas * somaDeColunaYquadrado - (somaDeColunaY * somaDeColunaY));

        return numerador / denominador;
    }
}