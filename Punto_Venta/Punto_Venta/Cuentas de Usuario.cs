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
    public partial class Cuentas_de_Usuario : Form
    {
        conexion conn = new conexion();
        MySqlConnection conectar;
        MySqlCommand comando;
        MySqlDataReader lector;
        public Cuentas_de_Usuario()
        {
            InitializeComponent();
            obtenerUsuarios();
            tbxBuscar.MaxLength = 45;
        }
        public void obtenerUsuarios()
        {
            try
            {

                List<usuariosLista> lista = new List<usuariosLista>();
                conectar = conn.ObtenerConexion();
                comando = new MySqlCommand("select id,nombre from usuarios WHERE nombre like '%"+tbxBuscar.Text+"%'", conectar);
                conectar.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    usuariosLista datos = new usuariosLista();
                    datos.ID = lector.GetInt32(0);
                    datos.nombre = lector.GetString(1);
                    lista.Add(datos);

                }
                conectar.Close();
                lbxUsuarios.DataSource = lista;
                lbxUsuarios.DisplayMember = "nombre";
                lbxUsuarios.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            nuevoUsuario nvoUser = new nuevoUsuario();
            nvoUser.ShowDialog();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            modificarUsuario modUs = new modificarUsuario(Convert.ToInt32(lbxUsuarios.SelectedValue));
            modUs.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Cuentas_de_Usuario_Activated(object sender, EventArgs e)
        {
            obtenerUsuarios();
        }
        DialogResult result;
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id=(int)lbxUsuarios.SelectedValue ;
            try
            {
                if (id!= 1)
                {
                    result = MessageBox.Show("¿Esta seguro de querer eliminar el usuario selecionado?", "Eliminar usuario", MessageBoxButtons.OKCancel);
                    if (result == DialogResult.OK)
                    {
                        conectar = conn.ObtenerConexion();
                        comando = new MySqlCommand("Delete from usuarios where id=" + id + "", conectar);
                        conectar.Open();
                        comando.ExecuteNonQuery();
                        conectar.Close();
                        MessageBox.Show("Usuario eliminado con éxito.");
                    }
                }
                else
                {
                    MessageBox.Show("No se puede eliminar al usuario principal.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbxBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            obtenerUsuarios();
        }

        private void Cuentas_de_Usuario_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
