using BackPropagation.Models.Values;

namespace BackPropagation.Models
{
    internal record class Neurona(UbicacionNeurona Ubicacion)
    {
        public double ValoroUmbral { get; set; }
    }
}
