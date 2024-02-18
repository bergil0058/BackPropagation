using BackPropagation.Models;
using BackPropagation.Models.Values;

namespace BackPropagation.Algoritmos
{
    internal class AlgoritmoSalidaRed
    {
        internal static List<double> GetSalida(Red Red, out List<SalidaNeurona> oSalidasNeuronas)
        {
            Capa iUltimaCapa = Red.Capas.Last();
            List<Neurona> iNeuronasSalida = iUltimaCapa.Neuronas;
            List<double> iRetVal = new(iNeuronasSalida.Count);

            oSalidasNeuronas = []; // Will store all calculated outputs to speed-up hole process
            foreach (Neurona iNeuronaSalida in iNeuronasSalida)
            {
                double iSalidaNeurona = AlgoritmoSalidaNeurona.GetSalida(iNeuronaSalida, Red.Enlaces, ref oSalidasNeuronas);
                iRetVal.Add(iSalidaNeurona);

                SalidaNeurona iSalidaNeuronaSalida = new(iNeuronaSalida, iSalidaNeurona);
                oSalidasNeuronas.Add(iSalidaNeuronaSalida);
            }
            return iRetVal;
        }        
    }
}
