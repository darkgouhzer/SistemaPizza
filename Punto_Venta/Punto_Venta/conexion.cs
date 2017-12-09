using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punto_Venta
{
    public class conexion
    {
        public MySqlConnection ObtenerConexion()
        {
            //MySqlConnection conectar = new MySqlConnection("server=127.0.0.1:8080; database=puntoventa; Uid=root; pwd=clave;");
            MySqlConnection conectar = new MySqlConnection("Server=localhost;Database=puntoventa;Uid=root;Pwd=clave;");
            //MySqlConnection conectar = new MySqlConnection("Server=192.168.0.13;Port=3306;Database=controlproduccion;Uid=administrador;Pwd=123;");
            return conectar;
        }
    }
}
