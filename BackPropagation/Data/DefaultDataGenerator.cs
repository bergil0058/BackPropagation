namespace BackPropagation.Data
{
    internal class DefaultDataGenerator
    {
        public static int[] Neuronas { get; } = [2, 4, 4, 2];
        public static int[] DefaultNeuronas { get; } = [2, 3, 2];
        private const int SeedUmbrales = 123;
        private const int SeedPesos = 456;

        private static readonly Random UmbralesRandom = new(SeedUmbrales);
        private static readonly Random PesosRandom = new(SeedUmbrales);

        internal static double GenerateDefaultUmbral() => UmbralesRandom.NextDouble();
        internal static double GenerateDefaultPeso() => PesosRandom.NextDouble();

        //internal static List<Peso> GenerateDefaultPesos()
        //{
        //    List<Peso> iRetVal = [];

        //    for (int i = 0; i < DefaultNeuronas.Length - 1;i++)
        //    {
        //        int iCapa = i + 1;
        //        int iNumeroNeuronas = DefaultNeuronas[i];
        //        int iCapaDestino = iCapa + 1;
        //        int iNumeroNeuronasNextCapa = DefaultNeuronas[i + 1];
        //        for (int j = 0; j < iNumeroNeuronas; j++)
        //        {
        //            int iIndiceOrigen = j + 1;
        //            for (int k = 0; k < iNumeroNeuronasNextCapa; k++)
        //            {
        //                int iIndiceDestino = k + 1;

        //                UbicacionPeso iUbicacion = new(iCapa, iCapaDestino, iIndiceOrigen, iIndiceDestino);
        //                double iPeso = GenerateDefaultPeso();

        //                Peso iNewPeso = new(iUbicacion, iPeso);
        //                iRetVal.Add(iNewPeso);
        //            }
        //        }
        //    }

        //    return iRetVal;
        //}
    }
}
