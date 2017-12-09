using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punto_Venta
{
    public class DatosProductos
    {     
        public String sCodigo { get; set; }
        public String sCodigoP { get; set; }
        public Int32 iCantidad { get; set; }
        public String sDescripcion { get; set; }
        public double dPrecio { get; set; }
        public double dTotal { get; set; }
        public Int32 iNumeroMesa { get; set; }
        public String sLigueIngExtra { get; set; }

    }
}
