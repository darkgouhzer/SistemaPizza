using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punto_Venta
{
    public class obtenerCodigo
    {
        private String _xn = "";
        private String _xnT = "";
        private double _xn2 = 0;

        public String valXn
        {
            get
            {
                return (_xn);
            }
            set
            {
                _xn = value;
            }
        }
        public String valXnT
        {
            get
            {
                return (_xnT);
            }
            set
            {
                _xnT = value;
            }
        }

        public double valXn2
        {
            get
            {
                return (_xn2);
            }
            set
            {
                _xn2 = value;
            }
        }
    }
}
