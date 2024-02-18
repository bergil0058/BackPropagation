﻿// See https://aka.ms/new-console-template for more information
using BackPropagation.Algoritmos;
using BackPropagation.Builders;
using BackPropagation.Data;
using BackPropagation.Models;
using System.Text;

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
    string iPrint = GetPrint(iRed, iBefore, iAfter, iAllSalidas);
    Console.WriteLine(iPrint);
    File.WriteAllText("Output.txt", iPrint);
    

}
catch (Exception ex)
{
    Console.WriteLine(ex);
}

string GetPrint(Red aRed, DateTime aStart, DateTime aEnd, List<SalidaNeurona> aSalidas)
{
    StringBuilder iSb = new();

    iSb.AppendLine("Red:");
    iSb.AppendLine($"Numero total neuronas: '{aRed.NumeroNeuronas}'");
    iSb.AppendLine();

    iSb.AppendLine($"Time: '{aEnd.Subtract(aStart).TotalMilliseconds}' ms");
    iSb.AppendLine();

    iSb.AppendLine($"Salidas: '{string.Join(" ; ", aSalidas.Where(x => x.Neurona.Ubicacion.Capa == aRed.Capas.Count)
                                                            .Select(x => x.Salida))}'");
    aSalidas.ForEach(x => iSb.AppendLine(x.ToString()));
    iSb.AppendLine();

    iSb.AppendLine("Enlaces:");
    aRed.Enlaces.ForEach(x => iSb.AppendLine(x.ToString()));
    iSb.AppendLine();

    return iSb.ToString();
}