using BackPropagation.Algoritmos;
using BackPropagation.Builders;
using BackPropagation.Data;
using BackPropagation.Models;
using BenchmarkDotNet.Attributes;

namespace BackPropagation.Benchmarks
{
    public class DefaultBenchmark
    {
        public static IEnumerable<int[]> Neuronas()
        {
            yield return DefaultDataGenerator.DefaultNeuronas;
            yield return DefaultDataGenerator.Neuronas;
        }

        [Benchmark]
        [ArgumentsSource(nameof(Neuronas))]
        public void Run(int[] aNeuronas) 
        {
            Red iRed = RedBuilder.Build(aNeuronas);

            // Feed first layer with actual values
            List<double> iValoresPrimeraCapa = new([0.25, 0.75]);
            iRed.FeedFirstLayer(iValoresPrimeraCapa);

            // Get network's outputs
            List<double> iSalidaRed = AlgoritmoSalidaRed.GetSalida(iRed, out List<SalidaNeurona> iAllSalidas);
        }
    }
}
