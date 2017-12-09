using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Punto_Venta
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            //Application.Run(new nuevoUsuario());
            Application.Run(new VentaPizza("1"));
            //Application.Run(new prueba());
            //Application.Run(new ProductoPantallaPrincipal("1"));
            //Application.Run(new Reportes());
             //Application.Run(new Corte_de_Caja("1"));
            //Application.Run(new Clientes("1"));
            //Application.Run(new nuevoProducto("1"));
            //Application.Run(new modificarProducto("1","1"));
            //Application.Run(new Espagueti());
        }
    }
}
