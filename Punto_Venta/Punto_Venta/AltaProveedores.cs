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
    public partial class AltaProveedores : Form
    {
        conexion conn = new conexion();
        public AltaProveedores()
        {
            InitializeComponent();
            tbxNombre.MaxLength = 100;
            tbxDireccion.MaxLength= 45;
            tbxTelefono.MaxLength = 15;
            
                
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbxNombre.Text.Length > 0 && tbxDireccion.Text.Length > 0  && tbxTelefono.Text.Length > 0)
                {
                    MySqlConnection conectar = conn.ObtenerConexion();
                    MySqlCommand comando = new MySqlCommand("Insert into proveedores values(null,'" + tbxNombre.Text + "','" + tbxDireccion.Text + "','" + tbxTelefono.Text + "')", conectar);
                    conectar.Open();
                    comando.ExecuteNonQuery();
                    conectar.Close();
                    MessageBox.Show("Proveedor agregado con éxito");
                    tbxNombre.Clear();
                    tbxDireccion.Clear();
                    tbxTelefono.Clear();
                }
                else
                {
                    MessageBox.Show("Todos los campos son obligatorios.");
                }
            }catch(Exception ex){
                MessageBox.Show(ex.Message);
            }
        }

        private void tbxTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!("\b0123456789".Contains(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void AltaProveedores_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
