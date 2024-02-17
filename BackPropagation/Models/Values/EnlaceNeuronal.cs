namespace BackPropagation.Models.Values
{
    internal record struct EnlaceNeuronal(Neurona Origen, Neurona Destino, double Peso)
    {
        public readonly int CapaOrigen => Origen.Ubicacion.Capa;
        public readonly int IndiceOrigen => Origen.Ubicacion.Index;

        public readonly int CapaDestino => Destino.Ubicacion.Capa;
        public readonly int IndiceDestino => Destino.Ubicacion.Index;
    }
}
