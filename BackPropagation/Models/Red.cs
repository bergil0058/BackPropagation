using BackPropagation.Data;
using BackPropagation.Models.Values;

namespace BackPropagation.Models
{
    internal class Red
    {
        public List<Capa> Capas { get; }
        public List<EnlaceNeuronal> Enlaces { get; }
        public int NumeroNeuronas { get; }



        public Red(List<Capa> aCapas)
        {
            this.Capas = aCapas
                .OrderBy(x => x.Index)
                .ToList();

            this.Enlaces = GenerateEnlaces(this.Capas);

            this.NumeroNeuronas = aCapas.SelectMany(x => x.Neuronas).Count();
        }



        internal Neurona GetNeurona(int aCapa, int aIndice) => Capas[aCapa - 1].Neuronas[aIndice - 1];

        internal void FeedFirstLayer(List<double> aValoresPrimeraCapa)
        {
            for (int i = 0; i < aValoresPrimeraCapa.Count; i++)
            {
                int iIndex = i + 1;
                this.Capas
                    .First()
                    .Neuronas
                    .First(x => x.Ubicacion.Index == iIndex)
                    .ValoroUmbral = aValoresPrimeraCapa[i];
            }
        }


        private static List<EnlaceNeuronal> GenerateEnlaces(List<Capa> aCapas)
        {
            List<EnlaceNeuronal> iRetVal = [];

            for (int i = 0; i < aCapas.Count - 1; i++) // Exclude last layer
            {
                Capa iCapa = aCapas[i];
                List<Neurona> iNeuronasCapa = iCapa.Neuronas;
                //IEnumerable<Peso> iPesosCapa = aPesos.Where(x => x.Ubicacion.CapaOrigen == iCapa.Index);
                for (int j = 0; j < iNeuronasCapa.Count; j++)
                {
                    Neurona iOrigen = iNeuronasCapa[j];
                    //IEnumerable<Peso> iPesosNeurona = iPesosCapa.Where(x => x.Ubicacion.IndiceOrigen == iOrigen.Ubicacion.Index);

                    // Get next layer
                    Capa iNextCapa = aCapas[i + 1];
                    List<Neurona> iNeuronasNextCapa = iNextCapa.Neuronas;
                    //IEnumerable<Peso> iPesosNextCapa = iPesosNeurona.Where(x => x.Ubicacion.CapaDestino == iNextCapa.Index);
                    for (int k = 0; k < iNeuronasNextCapa.Count; k++)
                    {
                        Neurona iDestino = iNeuronasNextCapa[k];
                        //Peso iPeso = iPesosNextCapa.FirstOrDefault(x => x.Ubicacion.IndiceDestino == iDestino.Ubicacion.Index);

                        EnlaceNeuronal iEnlace = new(iOrigen, iDestino, DefaultDataGenerator.GenerateDefaultPeso());
                        iRetVal.Add(iEnlace);
                    }
                }
            }
            return iRetVal;
        }
    }
}
