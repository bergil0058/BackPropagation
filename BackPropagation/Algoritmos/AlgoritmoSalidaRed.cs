using BackPropagation.Models;
using BackPropagation.Models.Values;

namespace BackPropagation.Algoritmos
{
    internal class AlgoritmoSalidaRed
    {
        internal static List<double> GetSalida(Red Red)
        {
            Capa iUltimaCapa = Red.Capas.Last();
            List<Neurona> iNeuronasSalida = iUltimaCapa.Neuronas;
            List<double> iRetVal = new(iNeuronasSalida.Count);

            foreach (Neurona iNeuronaSalida in iNeuronasSalida)
            {
                double iSalidaNeurona = AlgoritmoSalidaNeurona.GetSalida(iNeuronaSalida, Red.Enlaces);
                iRetVal.Add(iSalidaNeurona);
            }
            return iRetVal;
        }        
    }
}
