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
    public partial class Buscar : Form
    {
        public Buscar()
        {
            InitializeComponent();
            busqueda();
            tbxDescripcion.MaxLength = 60;
        }
        conexion conn = new conexion();
        MySqlConnection conectar;
        MySqlCommand comando;
        MySqlDataReader lector;

        obtenerCodigo _ui = new obtenerCodigo();

        public obtenerCodigo regresar
        {
            get
            {
                return (_ui);
            }
        }
        private void tbxDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                busqueda();
            }
        
        }

        public void busqueda()
        {
            try
            {
                if (tbxDescripcion.Text != null)
                {
                        dataGridView1.Rows.Clear();
                        conectar = conn.ObtenerConexion();
                        comando = new MySqlCommand("select codigo_barras,Descripcion from productos where Descripcion like  '%" + tbxDescripcion.Text + "%'", conectar);
                        conectar.Open();
                        lector = comando.ExecuteReader();

                        while (lector.Read())
                        {
                            dataGridView1.Rows.Add(lector.GetString(0), lector.GetString(1));
                        }
                        conectar.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                this.DialogResult = DialogResult.OK;
                _ui.valXn = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                this.Close();

            }
            else
            {
                MessageBox.Show("No hay datos para seleccionar");
            }
        }

        private void Buscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
