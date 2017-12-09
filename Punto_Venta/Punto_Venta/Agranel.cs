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
    public partial class Agranel : Form
    {
        string codigoBar;
        conexion conn = new conexion();
        MySqlConnection conectar;
        MySqlCommand comando;
        MySqlDataReader lector;

        public Agranel(string codbar)
        {
            InitializeComponent();
            codigoBar = codbar;
            obtenerPrecio();
        }
        obtenerCodigo _ui = new obtenerCodigo();

        public obtenerCodigo regresar
        {
            get
            {
                return (_ui);
            }
        }
        double precio;
        public void obtenerPrecio()
        {
            try
            {
                precio = 0;
                conectar = conn.ObtenerConexion();
                comando = new MySqlCommand("SELECT Precio_venta FROM productos WHERE Codigo_barras='"+codigoBar+"'", conectar);
                conectar.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    precio = lector.GetDouble(0);
                    tbxPrecio.Text = ""+lector.GetDouble(0);
                    tbxPrecio.Focus();
                    tbxCantidad.Text = "1";
                }
                conectar.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            if (tbxCantidad.Text.Length > 0)
            {
                this.DialogResult = DialogResult.OK;
                _ui.valXn2 = Convert.ToDouble(tbxCantidad.Text);
                this.Close();

            }
            else
            {
                MessageBox.Show("No hay datos para seleccionar");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        double total;
        private void tbxCantidad_Leave(object sender, EventArgs e)
        {
            total = 0;
            total=precio*Convert.ToDouble(tbxCantidad.Text);

            tbxPrecio.Text=""+total;
        }

        private void tbxPrecio_Leave(object sender, EventArgs e)
        {
            total = 0;
            total = Convert.ToDouble(tbxPrecio.Text)/precio;
            tbxCantidad.Text = ""+total;
        }

        private void tbxCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 46 && tbxCantidad.Text.IndexOf('.') != -1)
            {

                e.Handled = true;
                return;

            }
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != 46)
            {

                e.Handled = true;

            }
        }
    }
}
