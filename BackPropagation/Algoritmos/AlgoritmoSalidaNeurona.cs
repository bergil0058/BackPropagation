using BackPropagation.Models;
using BackPropagation.Models.Values;

namespace BackPropagation.Algoritmos
{
    internal class AlgoritmoSalidaNeurona
    {
        internal static double GetSalida(Neurona aNeurona, List<EnlaceNeuronal> aEnlaces, ref List<SalidaNeurona> Salidas)
        {
            double iRetVal = aNeurona.ValoroUmbral;

            int iCapaNeurona = aNeurona.Ubicacion.Capa;
            if (iCapaNeurona <= 1) return iRetVal;

            int iCapaAnterior = iCapaNeurona - 1;
            int iIndiceNeurona = aNeurona.Ubicacion.Index;
            IEnumerable<EnlaceNeuronal> iLeftEnlaces = aEnlaces.Where(x => x.CapaOrigen == iCapaAnterior
                                                                            && x.CapaDestino == iCapaNeurona
                                                                            && x.IndiceDestino == iIndiceNeurona);

            double iSumatorio = 0;
            foreach (EnlaceNeuronal iLeftEnlace in iLeftEnlaces.ToList())
            {
                //double iSumando = iLeftEnlace.Peso * GetSalida(iLeftEnlace.Origen, aEnlaces);
                double iSumando = iLeftEnlace.Peso;

                // Check if output for this neurona has already been calculated
                double iSalidaNeuronaAnteriorValue = GetSalidaNeuronaAnterior(iLeftEnlace.Origen, aEnlaces, ref Salidas);
                iSumando *= iSalidaNeuronaAnteriorValue;
                iSumatorio += iSumando;
            }
            iRetVal += iSumatorio;

            return iRetVal;
        }


        private static double GetSalidaNeuronaAnterior(Neurona aNeuronaAnterior, List<EnlaceNeuronal> aEnlaces, ref List<SalidaNeurona> Salidas)
        {
            SalidaNeurona? iSalidaNeurona = Salidas.FirstOrDefault(x => x.Neurona == aNeuronaAnterior);
            if (iSalidaNeurona != default) return iSalidaNeurona.Salida;

            double iSalidaNeuronaAnteriorValue = GetSalida(aNeuronaAnterior, aEnlaces, ref Salidas);

            SalidaNeurona iNewSalidaNeurona = new(aNeuronaAnterior, iSalidaNeuronaAnteriorValue);
            Salidas.Add(iNewSalidaNeurona);

            return iSalidaNeuronaAnteriorValue;
        }
    }
}
