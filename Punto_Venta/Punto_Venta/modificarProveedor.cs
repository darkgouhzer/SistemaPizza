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
    public partial class modificarProveedor : Form
    {
        conexion conn = new conexion();
        MySqlConnection conectar;
        MySqlCommand comando;
        MySqlDataReader lector;
        int idP;
        public modificarProveedor(int idp)
        {
            InitializeComponent();
            idP = idp;
            rellenarCampos();
            tbxNombre.MaxLength = 100;
            tbxDireccion.MaxLength = 45;
            tbxTelefono.MaxLength = 15;
            
        }
        public void rellenarCampos()
        {
            try
            {
                conectar = conn.ObtenerConexion();
                comando = new MySqlCommand("Select * from proveedores where id=" + idP + "", conectar);
                conectar.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    tbxNombre.Text = lector.GetString(1);
                    tbxDireccion.Text = lector.GetString(2);
                    tbxTelefono.Text = lector.GetString(3);
                }
                conectar.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbxNombre.Text.Length > 0 && tbxDireccion.Text.Length > 0 && tbxTelefono.Text.Length > 0)
                {
                    conectar = conn.ObtenerConexion();
                    comando = new MySqlCommand("update proveedores set Nombre='" + tbxNombre.Text + "', Direccion='" + tbxDireccion.Text + "', Telefono='" + tbxTelefono.Text + "' where id=" + idP + "", conectar);
                    conectar.Open();
                    comando.ExecuteNonQuery();
                    conectar.Close();
                    MessageBox.Show("Proveedor modificado con éxito");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Todos los campos son obligatorios.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
