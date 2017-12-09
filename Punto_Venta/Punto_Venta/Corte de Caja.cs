using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace Punto_Venta
{
    public partial class Corte_de_Caja : Form
    {
        conexion conn = new conexion();
        MySqlConnection conectar;
        MySqlCommand comando;
        MySqlDataReader lector;

        string idusuario = "";
        public Corte_de_Caja(string iduser)
        {
            InitializeComponent();
            idusuario = iduser;
            obtenerUsuario();
            CalcularCorte();
        }
        public void obtenerUsuario()
        {
            conectar = conn.ObtenerConexion();
            comando = new MySqlCommand("select Nombre from usuarios where id="+idusuario+"",conectar);
            conectar.Open();
            lector = comando.ExecuteReader();
            while (lector.Read())
            {
                tbxCajero.Text = lector.GetString(0);
            }
            conectar.Close();
        }
        double dinero;
        DateTime ultimoCorte;
        DateTime desde, hasta;
        double TotalVentas,entradas,salidas,compras,devoluciones,tarjeta;
        double totalcaja;
        public void CalcularCorte()
        {
            totalcaja = 0;
            dinero=0;
            TotalVentas=0;
            entradas=0;
            salidas = 0;
            compras=0;
            devoluciones = 0;
            tarjeta = 0;
            try
            {
                int contador = 0;
                string entrefechas = "";

                //obteniendo dinero inicial en caja y fecha de ultimo corte
                conectar = conn.ObtenerConexion();
                comando = new MySqlCommand("select dinero, ultimoCorte from corteCaja where id=1", conectar);
                conectar.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    dinero = lector.GetDouble(0);
                    ultimoCorte = lector.GetDateTime(1);
                }
                conectar.Close();

                lblCaja.Text = dinero.ToString("C2");

                if (ultimoCorte.ToString("yyyyMMdd") == DateTime.Now.ToString("yyyyMMdd"))
                {
                    desde = ultimoCorte;
                    hasta = DateTime.Now;
                    entrefechas = "" + ultimoCorte.ToString("yyyyMMddHHmmss") + " and " + DateTime.Now.ToString("yyyyMMddHHmmss");
                }
                else
                {

                    desde = Convert.ToDateTime(DateTime.Now.Date);
                    hasta = DateTime.Now;
                    entrefechas = " "+ DateTime.Now.ToString("yyyyMMdd000000")+ " and " +DateTime.Now.ToString("yyyyMMdd235959")+" ";
                }

                //obteniendo total de ventas
                comando = new MySqlCommand("select count(*) from venta where fecha_venta between " + entrefechas, conectar);
                conectar.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    contador = lector.GetInt32(0);
                }
                conectar.Close();
                if (contador > 0)
                {
                    comando = new MySqlCommand("select sum(Total), sum(tarjeta) from venta where fecha_venta between " + entrefechas, conectar);
                    conectar.Open();
                    lector = comando.ExecuteReader();
                    while (lector.Read())
                    {
                        TotalVentas = lector.GetDouble(0);
                        tarjeta = lector.GetDouble(1);
                    }
                    conectar.Close();
                }

               
                lblVentasTotales.Text = TotalVentas.ToString("C2");
                lblTarjeta.Text = tarjeta.ToString("C2");
                //obteniendo total de entradas de efectivo
                comando = new MySqlCommand("select count(*) from entradaefectivo where fecha between " + entrefechas, conectar);
                conectar.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    contador = lector.GetInt32(0);
                }
                conectar.Close();

                if (contador > 0)
                {
                    comando = new MySqlCommand("select sum(cantidad) from entradaefectivo where fecha between " + entrefechas, conectar);
                    conectar.Open();
                    lector = comando.ExecuteReader();
                    while (lector.Read())
                    {
                        entradas = lector.GetDouble(0);
                    }
                    conectar.Close();
                }
                lblEntradas.Text = entradas.ToString("C2");
                //obteniendo total de salidas de efectivo
                comando = new MySqlCommand("select count(*) from salidaefectivo where fecha between " + entrefechas, conectar);
                conectar.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    contador = lector.GetInt32(0);
                }
                conectar.Close();
                if (contador > 0)
                {
                    comando = new MySqlCommand("select sum(cantidad) from salidaefectivo where fecha between " + entrefechas, conectar);
                    conectar.Open();
                    lector = comando.ExecuteReader();
                    while (lector.Read())
                    {
                        salidas = lector.GetDouble(0);
                    }
                    conectar.Close();
                }
                lblSalidas.Text = salidas.ToString("C2");

                //obteniendo total de compras
                comando = new MySqlCommand("select count(*) from compras where fecha_compra between " + entrefechas, conectar);
                conectar.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    contador = lector.GetInt32(0);
                }
                conectar.Close();
                if (contador > 0)
                {
                    comando = new MySqlCommand("select sum(importe) from compras where fecha_compra between " + entrefechas, conectar);
                    conectar.Open();
                    lector = comando.ExecuteReader();
                    while (lector.Read())
                    {
                        compras = lector.GetDouble(0);
                    }
                    conectar.Close();
                }
                lblCompras.Text = compras.ToString("C2");

                //obteniendo total de devoluciones ventas
                comando = new MySqlCommand("select count(*) from venta where status=0 and fecha_venta between " + entrefechas, conectar);
                conectar.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    contador = lector.GetInt32(0);
                }
                conectar.Close();
                if (contador > 0)
                {
                    comando = new MySqlCommand("select sum(Total) from venta where status=0 and fecha_venta between " + entrefechas, conectar);
                    conectar.Open();
                    lector = comando.ExecuteReader();
                    while (lector.Read())
                    {
                        devoluciones = lector.GetDouble(0);
                    }
                    conectar.Close();
                }
                lblDevoluciones.Text = devoluciones.ToString("C2");

                totalcaja = dinero + TotalVentas + entradas - tarjeta - salidas - compras - devoluciones;
                lblTotalCaja.Text = totalcaja.ToString("C2");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCorte_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Está a punto de realizar el corte de caja ¿Desea continuar?", "Corte de caja", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                conectar = conn.ObtenerConexion();
                comando = new MySqlCommand("UPDATE cortecaja SET dinero=" + totalcaja + ", ultimocorte=now() where id=1", conectar);
                conectar.Open();
                comando.ExecuteNonQuery();
                conectar.Close();
                Fondo f = new Fondo(idusuario);
                f.ShowDialog();
                MessageBox.Show("Corte de caja realizado con éxito.");
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font letra = new Font("Arial", 6);

              e.Graphics.DrawString("CORTE DE CAJA", letra, Brushes.Black, new Rectangle(2,2,200,50));
              e.Graphics.DrawString("CAJERO: "+tbxCajero.Text, letra, Brushes.Black, new Rectangle(2, 14, 200, 50));
              e.Graphics.DrawString("Fecha desde: " + desde.ToString("dd/MM/yyyy HH:mm:ss tt"), letra, Brushes.Black, new Rectangle(2, 26, 200, 50));
              e.Graphics.DrawString("Fecha hasta" + hasta.ToString("dd/MM/yyyy HH:mm:ss tt"), letra, Brushes.Black, new Rectangle(2, 38, 200, 50));
              e.Graphics.DrawString("================================", letra, Brushes.Black, new Rectangle(2, 50, 200, 50));
              e.Graphics.DrawString("Ventas totales: "+lblVentasTotales.Text, letra, Brushes.Black, new Rectangle(2, 62, 200, 50));
              e.Graphics.DrawString("Cantidad inicial: "+lblCaja.Text, letra, Brushes.Black, new Rectangle(2, 74, 200, 50));
              e.Graphics.DrawString("Entradas efectivo: " + lblEntradas.Text, letra, Brushes.Black, new Rectangle(2, 86, 200, 50));
              e.Graphics.DrawString("Tarjetas: " + lblTarjeta.Text, letra, Brushes.Black, new Rectangle(2, 98, 200, 50));
              e.Graphics.DrawString("Salidas efectivo: " + lblSalidas.Text, letra, Brushes.Black, new Rectangle(2, 110, 200, 50));
              e.Graphics.DrawString("Devoluciones: " + lblDevoluciones.Text, letra, Brushes.Black, new Rectangle(2, 122, 200, 50));
              e.Graphics.DrawString("Pago a proveedores: " + lblCompras.Text, letra, Brushes.Black, new Rectangle(2, 134, 200, 50));
              e.Graphics.DrawString("________________________________", letra, Brushes.Black, new Rectangle(2, 146, 200, 50));
              e.Graphics.DrawString("Total en caja: " + lblTotalCaja.Text, letra, Brushes.Black, new Rectangle(2, 158, 200, 50));

                    
        }

        private void Corte_de_Caja_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
