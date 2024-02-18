// See https://aka.ms/new-console-template for more information
using BackPropagation.Algoritmos;
using BackPropagation.Builders;
using BackPropagation.Data;
using BackPropagation.Models;

Console.WriteLine("Hello, World!");

try
{

    Red iRed = RedBuilder.Build(DefaultDataGenerator.DefaultNeuronas);

    List<double> iValoresPrimeraCapa = new([0.25, 0.75]);
    iRed.FeedFirstLayer(iValoresPrimeraCapa);

    DateTime iBefore = DateTime.Now;
    List<double> iSalidaRed = AlgoritmoSalidaRed.GetSalida(iRed, out List<SalidaNeurona> iAllSalidas);
    DateTime iAfter = DateTime.Now;

    // Print
    Console.WriteLine($"Numero total neuronas: '{iRed.NumeroNeuronas}'");Console.WriteLine();
    Console.WriteLine($"Salida Red: '{string.Join(" ; ", iSalidaRed)}'"); Console.WriteLine();
    Console.WriteLine($"Time: '{iAfter.Subtract(iBefore).TotalMilliseconds}' ms"); Console.WriteLine();
    Console.WriteLine("Salidas:");
    iAllSalidas.ForEach(Console.WriteLine); Console.WriteLine();
    Console.WriteLine("Enlaces:");
    iRed.Enlaces.ForEach(x => Console.WriteLine(x));

}
catch (Exception ex)
{
    Console.WriteLine(ex);
}