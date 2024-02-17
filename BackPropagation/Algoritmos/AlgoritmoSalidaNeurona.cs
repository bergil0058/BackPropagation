using BackPropagation.Models;
using BackPropagation.Models.Values;

namespace BackPropagation.Algoritmos
{
    internal class AlgoritmoSalidaNeurona
    {
        internal static double GetSalida(Neurona aNeurona, List<EnlaceNeuronal> aEnlaces)
        {
            double iRetVal = 0;

            int iCapaNeurona = aNeurona.Ubicacion.Capa;
            if (iCapaNeurona <= 1) return aNeurona.ValorPrimeraCapa;
            else iRetVal = aNeurona.Umbral;

            int iCapaAnterior = iCapaNeurona - 1;
            int iIndiceNeurona = aNeurona.Ubicacion.Index;
            IEnumerable<EnlaceNeuronal> iLeftEnlaces = aEnlaces.Where(x => x.CapaOrigen == iCapaAnterior
                                                                            && x.CapaDestino == iCapaNeurona
                                                                            && x.IndiceDestino == iIndiceNeurona);

            double iSumatorio = 0;
            foreach (EnlaceNeuronal iLeftEnlace in iLeftEnlaces.ToList())
            {
                double iSumando = iLeftEnlace.Peso * GetSalida(iLeftEnlace.Origen, aEnlaces);
                iSumatorio += iSumando;
            }
            iRetVal += iSumatorio;

            return iRetVal;
        }
    }
}
