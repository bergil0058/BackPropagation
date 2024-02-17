using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackPropagation.Models.Values
{
    internal record struct Capa(int Index, List<Neurona> Neuronas)
    {
    }
}
