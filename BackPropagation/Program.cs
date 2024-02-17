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

    List<double> iSalidaRed = AlgoritmoSalidaRed.GetSalida(iRed);
    Console.WriteLine($"Salida Red: '{string.Join(" ; ", iSalidaRed)}'");

}
catch (Exception ex)
{
    Console.WriteLine(ex);
}