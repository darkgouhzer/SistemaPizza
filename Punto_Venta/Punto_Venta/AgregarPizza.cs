using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punto_Venta
{
    public class AgregarPizza
    {        
        public int Codigo { get; set; }

        public int Tamaño { get; set; }
        public string TipoMasa { get; set; }
        public string NombrePizza { get; set; }
        public List<string> Ingredientes { get; set; }
        public List<string> IngredienteExtra { get; set; }
        public double PrecioIngExtra { get; set; }
        public double PrecioPizza { get; set; }
        public int NumeroIngredientes { get; set; }
        public int TipoPizza { get; set; }
    }
}
