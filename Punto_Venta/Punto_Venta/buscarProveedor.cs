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
    public partial class buscarProveedor : Form
    {
        conexion conn = new conexion();
        MySqlConnection conectar;
        MySqlCommand comando;
        MySqlDataReader lector;
        public buscarProveedor()
        {
            InitializeComponent();
            proveedoresRellenar();
        }

        public void proveedoresRellenar()
        {
            try
            {
                dtgProveedores.Rows.Clear();
                conectar = conn.ObtenerConexion();
                comando = new MySqlCommand("select id, Nombre from proveedores where Nombre like '%" + tbxBuscar.Text + "%'", conectar);
                conectar.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    dtgProveedores.Rows.Add(lector.GetString(0), lector.GetString(1));
                }
                conectar.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbxBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            proveedoresRellenar();
        }

        obtenerCodigo _ui = new obtenerCodigo();
        public obtenerCodigo regresar
        {
            get
            {
                return (_ui);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dtgProveedores.Rows.Count > 0)
            {
                this.DialogResult = DialogResult.OK;
                _ui.valXn = dtgProveedores.CurrentRow.Cells[0].Value.ToString();
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

        private void buscarProveedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
