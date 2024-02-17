using BackPropagation.Data;
using BackPropagation.Models;
using BackPropagation.Models.Values;

namespace BackPropagation.Builders
{
    internal class RedBuilder()
    {
        internal static Red Build(int[] NumeroNeuronas)
        {
            Red iRetVal = null!;

            // Each index is a layer
            List<Capa> iCapas = [];
            for (int i = 0; i < NumeroNeuronas.Length; i++)
            {
                // Layer loop
                int iLayer = i + 1;
                int iNumeroNeuronas = NumeroNeuronas[i];

                // Index loop
                List<Neurona> iCapaNeuronas = [];
                for (int j = 0; j < iNumeroNeuronas; j++)
                {
                    int iIndex = j + 1;
                    UbicacionNeurona iUbicacion = new(iLayer, iIndex);

                    Neurona iNeurona = new(iUbicacion);
                    if (iLayer > 1) iNeurona.Umbral = DefaultDataGenerator.GenerateDefaultUmbral();
                    iCapaNeuronas.Add(iNeurona);
                }
                Capa iCapa = new(iLayer, iCapaNeuronas);
                iCapas.Add(iCapa);
            }
            iRetVal = new(iCapas);
            return iRetVal;
        }
    }
}
