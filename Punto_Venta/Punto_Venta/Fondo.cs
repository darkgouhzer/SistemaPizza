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
    public partial class Fondo : Form
    {
        string idUsuario, dinero;
        conexion conn = new conexion();
        MySqlConnection conectar;
        MySqlCommand comando;
        MySqlDataReader lector;
        int regCaja = 0;

        public Fondo(string iduser)
        {
            InitializeComponent();
            tbxEfectivo.MaxLength = 8;
            idUsuario = iduser;
            regcajanum();
            if (regCaja > 0)
            {
                tbxEfectivo.Text = dinero;
            }
        }

        public void regcajanum()
        {
            conectar = conn.ObtenerConexion();
            comando = new MySqlCommand("select dinero from cortecaja", conectar);
            conectar.Open();
            lector = comando.ExecuteReader();
            while (lector.Read())
            {
                dinero = lector.GetDouble(0).ToString("C2");
                regCaja++;
            }
            conectar.Close();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            if (tbxEfectivo.Text.Length >= 0)
            {
                this.Visible = false;
                conectar = conn.ObtenerConexion();
                if (regCaja == 0)
                {
                    comando = new MySqlCommand("INSERT INTO cortecaja values(1," + Convert.ToDouble(tbxEfectivo.Text.Substring(1)) + ",now())", conectar);
                }
                else
                {
                    comando = new MySqlCommand("UPDATE cortecaja set dinero=" + Convert.ToDouble(tbxEfectivo.Text.Substring(1)) + "", conectar);
                }
                conectar.Open();
                comando.ExecuteNonQuery();
                conectar.Close();
                this.Close();
            }
            else
            {
                MessageBox.Show("Debe ingresar la cantidad de dinero en caja.");
                tbxEfectivo.Focus();
            }
        }

        DialogResult result;
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            result = MessageBox.Show("¿Esta seguro que desea salir?", ":(", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Close();
            }

        }

        private void tbxEfectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!("\b0123456789.".Contains(e.KeyChar)))
            {
                e.Handled = true;
                if (e.KeyChar == 46 && tbxEfectivo.Text.IndexOf('.') != -1)
                {
                    e.Handled = true;

                    return;
                }
                if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != 46)
                {
                    e.Handled = true;

                }

                if (e.KeyChar == (char)13)
                {
                    btnInicio.Focus();
                }
            }
        }

        private void tbxEfectivo_Validated(object sender, EventArgs e)
        {
            Double value;
            if (Double.TryParse(tbxEfectivo.Text, out value))
                tbxEfectivo.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", value);
            //else
            //    tbxEfectivo.Text = String.Empty;
        }

        private void tbxEfectivo_Leave(object sender, EventArgs e)
        {
            if (tbxEfectivo.Text == "")
            {
                tbxEfectivo.Text = "0.00";
            }
        }
    }
}
