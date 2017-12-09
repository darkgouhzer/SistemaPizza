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
    public partial class entradaInventario : Form
    {
        conexion conn = new conexion();
        MySqlConnection conectar;
        MySqlCommand comando;
        MySqlDataReader lector;
        string idusuario = "";
        public entradaInventario(string iduser)
        {
            InitializeComponent();
            idusuario = iduser;
            tbxCodBar.MaxLength = 25;
        }

        public entradaInventario(string codbar, string iduser)
        {
            InitializeComponent();
            idusuario = iduser;
            tbxCodBar.Text = codbar;
            tbxCodBar.MaxLength = 25;
        }
        private void tbxCodBar_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                int cont = 0;
                if (e.KeyCode == Keys.Enter)
                {
                    if (tbxCodBar.Text.Length > 0)
                    {
                        conectar = conn.ObtenerConexion();
                        comando = new MySqlCommand("Select Descripcion from productos WHERE Codigo_barras='" + tbxCodBar.Text + "'", conectar);
                        conectar.Open();
                        lector = comando.ExecuteReader();
                        while (lector.Read())
                        {
                            tbxNombre.Text = lector.GetString(0);
                          
                            cont++;
                        }
                        conectar.Close();
                        if (cont == 0)
                        {
                            MessageBox.Show("El código de producto no existe.");
                            tbxCodBar.Focus();
                        }
                        else
                        {
                            tbxCantidad.Focus();
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void tbxCodBar_Leave(object sender, EventArgs e)
        {
            buscarProducto();
        }
        public void buscarProducto()
        {
            try
            {
                int cont = 0;
                if (tbxCodBar.Text.Length > 0)
                {
                    conectar = conn.ObtenerConexion();
                    comando = new MySqlCommand("Select Descripcion from productos WHERE Codigo_barras='" + tbxCodBar.Text + "'", conectar);
                    conectar.Open();
                    lector = comando.ExecuteReader();
                    while (lector.Read())
                    {
                        cont++;
                        tbxNombre.Text = lector.GetString(0);

                    }
                    conectar.Close();
                    if (cont == 0)
                    {
                        MessageBox.Show("El código de producto no existe.");
                        tbxCodBar.Focus();
                    }
                    else
                    {
                        tbxCantidad.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbxCantidad.Text.Length > 0)
                {
                    conectar = conn.ObtenerConexion();
                    comando = new MySqlCommand("UPDATE productos SET Cantidad=Cantidad+" + tbxCantidad.Text +
                        " WHERE Codigo_barras=" + tbxCodBar.Text + "", conectar);
                    conectar.Open();
                    comando.ExecuteNonQuery();
                    conectar.Close();
                    tbxCodBar.Clear();
                    tbxNombre.Clear();
                    tbxCantidad.Clear();
                    MessageBox.Show("Cantidad agregada con éxito.");
                }
                else
                {
                    MessageBox.Show("Debe indicar una cantidad a ingresar.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbxCodBar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbxCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!("\b0123456789.".Contains(e.KeyChar)))
            {
                e.Handled = true;
                
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

        private void btnSP_Click(object sender, EventArgs e)
        {
            Buscar bsp = new Buscar();
            DialogResult dr = bsp.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tbxCodBar.Text = bsp.regresar.valXn;
                buscarProducto();
                tbxCantidad.Focus();
            }
        }
    }
}
