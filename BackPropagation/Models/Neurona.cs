using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackPropagation.Models.Values;

namespace BackPropagation.Models
{
    internal record class Neurona(UbicacionNeurona Ubicacion)
    {
        public double Umbral { get; set; }
        public double ValorPrimeraCapa { get; set; }
    }
}
