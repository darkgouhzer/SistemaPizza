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
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace Punto_Venta
{
    public partial class Clientes : Form
    {
        conexion conn = new conexion();
        MySqlConnection conectar;
        MySqlCommand comando;
        String sqlCMD = "";
        MySqlDataReader lector;
        string idusuario = "";
        Int32 folio = 0;
        public DatosCliente objDatosCliente = new DatosCliente();
        public Clientes(string iduser)
        {
            InitializeComponent();
            idusuario = iduser;
        }

    

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            conectar = conn.ObtenerConexion();
            conectar.Open();
            comando = new MySqlCommand("SELECT COUNT(*) FROM Clientes where Telefono =" + tbxTelefono.Text, conectar);
            if(Convert.ToInt32(comando.ExecuteScalar())>0)
            {
                comando = new MySqlCommand("UPDATE Clientes SET Nombre = '" + tbxNombre.Text + "', Telefono = '" + tbxTelefono.Text + "', "+
                    " Calle = '"+tbxDireccion.Text +"', Colonia = '"+tbxColonia.Text+"', NumeroExterior =" + tbxNoExt.Text +
                    " WHERE ClienteID = " + tbxClienteID.Text, conectar);
            }
            else
            {
                comando = new MySqlCommand("Insert into Clientes (Nombre, Telefono, Calle, Colonia,NumeroExterior) Values ('" + tbxNombre.Text + "','" + tbxTelefono.Text + "','" + tbxDireccion.Text + "','" + tbxColonia.Text + "','" + tbxNoExt.Text + "');", conectar);
            }           
            
            comando.ExecuteNonQuery();
            conectar.Close();
            objDatosCliente = new DatosCliente();
            objDatosCliente.Nombre = tbxNombre.Text;
            objDatosCliente.Telefono = tbxTelefono.Text;
            objDatosCliente.Calle = tbxDireccion.Text;
            objDatosCliente.Colonia = tbxColonia.Text;
            objDatosCliente.NumeroExterior = tbxNoExt.Text;
            this.Close();
        }

        public void Limpiar()
        {
            tbxNombre.Clear();
            tbxTelefono.Clear();
            tbxDireccion.Clear();
            tbxColonia.Clear();
            tbxNoExt.Clear();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                BuscarCliente bc = new BuscarCliente();                
                DialogResult dr = bc.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    tbxTelefono.Text = bc.regresar.valXn;


                }
                tbxTelefono_Leave(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
    
        }

       

        private void tbxTelefono_Leave(object sender, EventArgs e)
        {
            conectar = conn.ObtenerConexion();
            comando = new MySqlCommand("Select * from Clientes where Telefono ='" + tbxTelefono.Text + "'", conectar);
            conectar.Open();
            lector = comando.ExecuteReader();
            if(lector.Read())
            {
                tbxClienteID.Text = lector.GetString(0);
                tbxNombre.Text = lector.GetString(1);
                tbxDireccion.Text = lector.GetString(3);
                tbxColonia.Text = lector.GetString(4);
                tbxNoExt.Text = lector.GetString(5);
            }
            else
            {
                tbxClienteID.Clear();
                tbxNombre.Clear();
                tbxDireccion.Clear();
                tbxColonia.Clear();
                tbxNoExt.Clear();
            }
            conectar.Close();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Clientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
