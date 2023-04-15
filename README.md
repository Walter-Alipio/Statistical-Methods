# :chart_with_upwards_trend: Biblioteca-Estatística

## chart_with_downwards_trend :chart_with_downwards_trend: Projeto de estudos

## 🔨 Objetivo do projeto

O objetivo desse repositório é manter uma coleção de métodos úteis para trabalhar com dadeos estátisticos.

## ✔️ Tecnologias utilizadas

- [.NET 7](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
- [XUnite](https://xunit.net/)

<br>

<!-- ## 🛠️ Abrir e rodar o projeto -->

[**Fórmulas utilizadas**](./Formulas/README.md)

<br>

# Classes e métodos

| CentralTendency Class |                                                         |                                                                                                    |
| --------------------- | ------------------------------------------------------- | -------------------------------------------------------------------------------------------------- |
| Return Type           | Methods names                                           | Description                                                                                        |
| double                | Mean(int[] values)                                      | Retorna a média de um array do tipo int                                                            |
| double                | Mean(double[] values)                                   | Retorna a média de um array do tipo double                                                         |
| double                | WeightedAverage(int[] values, int[] weight)             | Retorna a Média Ponderada de um array de valores do tipo int e do array de pesos do tipo int       |
| double                | WeightedAverage(double[] values, int[] weight)          | Retorna a Média Ponderada de um array de valores do tipo double e do array de pesos do tipo int    |
| double                | WeightAverageByFrequency(int[] values, int[] frequency) | Retorna a Média Ponderada de um array de valores do tipo int e do array de frequências do tipo int |
| List<int>             | Mode(int[] values)                                      | Retorna uma lista com a moda do array de tipo int                                                  |
| double                | Median(double[] values)                                 | Retorna a Mediana de um array do tipo double                                                       |
| double                | Median(int[] values)                                    | Retorna a Mediana de um array do tipo int                                                          |
| double                | Midpoint(int superiorLimit, int inferiorLimit)          | Retorna o Ponto Médio dado o limite superior e o limite inferior do tipo int                       |
| double                | Midpoint(double superiorLimit, double inferiorLimit)    | Retorna o Ponto Médio dado o limite superior e o limite inferior do tipo double                    |
| int[]                 | Frequency(double[] values)                              | Retorna um array do tipo int com as frequências ordenadas de um array do tipo int                  |
| Dictionary<int, int>  | Frequency(int[] values)                                 | Retorna um Dicionário com valor e frequência de um array do tipo int                               |

<br>

| CombinatorialAnalysis Class |                                               |                                                                               |
| --------------------------- | --------------------------------------------- | ----------------------------------------------------------------------------- |
| Return Type                 | Methods names                                 | Description                                                                   |
| double                      | Factorial(int number)                         | Retorna o fatorial de um número                                               |
| double                      | Summations(int start, int end)                | Retorna o somatório dado um valor de inicio e fim                             |
| double                      | Binomial(int numerator, int denominator)      | Retorna o binomial de n(numerador),p(denominador) do tipo int                 |
| double                      | CountingPrinciple(int possibility, int steps) | Retorna o total de possibilidades dados o valor e quantidade de passos        |
| double                      | Arrangements(int numerator, int denominator)  | Retorna o arranjo simples de n(numerador) e k(denominador)                    |
| double                      | Combination(int elements, int step)           | Retorna a combinação simples de n(elements) e p(steps)                        |
| long                        | CombinationLong(int elements, int step)       | Retorna um valor do tipo long da combinação simples de n(elements) e p(steps) |

<br>

| Dispersion Class |                                                                      |                                                                                                                      |
| ---------------- | -------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------- |
| Return Type      | Methods names                                                        | Description                                                                                                          |
| double           | Amplitude(int superiorLimit, int inferiorLimit)                      | Retorna a amplitude dado um limite superior e um limite inferior                                                     |
| double           | MeanDeviation(double[] values)                                       | Retorna o Desvio Médio de um array do tipo double                                                                    |
| double           | MeanDeviationByFrequency(List<double[]> valuesList, int[] frequency) | Retorna o Desvio Médio por Frequência de uma lista de arrays do tipo double e um array de frequência do tipo inteiro |
| double           | Variance(double[] calculusBase)                                      | Retorna a variancia de um array do tipo double                                                                       |
| double           | StandardDeviation(double[] values)                                   | Retorna o Desvio PAdrão de um array do tipo double                                                                   |
| double           | StandardDeviationByFrequency(double[] midpoint, int[] frequency)     | Retorna o Desvio Padrão por Frequência dado um array do tipo double, ponto medio, e um array do tipo int, frequência |
| double           | SampleStandardDeviation(double[] values)                             | Retorna o Desvio Padrão Amostral de um array do tipo double                                                          |

<br>

| Probabilities Class |                                                     |                                                                                                           |
| ------------------- | --------------------------------------------------- | --------------------------------------------------------------------------------------------------------- |
| Return Type         | Methods names                                       | Description                                                                                               |
| double              | OccurrenceProbability(double @event, double sample) | Retorna a probabilidade de ocorrência de um evento dado um evento do tipo double e amostra do tipo double |

<br>

| StatisticalInference Class |                                                                 |                                                                                                                      |
| -------------------------- | --------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------- |
| Return Type                | Methods names                                                   | Description                                                                                                          |
| decimal                    | BinomialDistribution(int n, int x, double success, double fail) | Retorna a Distribuição Binomial do tipo double dado                                                                  |
| double                     | PearsonCorrelationCoefficient(int[] x, int[] y)                 | Retorna o Coeficiênte de Correlação de Pearson dado um array do tipo int, coluna x, e um array do tipo int, coluna y |
| double                     | LinearCorrelationCoefficient(int[] columX, int[] columY)        | Retorna o Coeficiênte de Correlação Linear dado um array do tipo int, coluna x, e um array do tipo int, coluna y     |
