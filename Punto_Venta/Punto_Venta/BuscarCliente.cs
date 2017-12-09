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
    public partial class BuscarCliente : Form
    {
        conexion conn = new conexion();
        MySqlConnection conectar;
        MySqlCommand comando;
        MySqlDataReader lector;
        public BuscarCliente()
        {
            InitializeComponent();
            busqueda();
            tbxDescripcion.MaxLength = 10;
        }


        public void busqueda()
        {
            try
            {
                if (tbxDescripcion.Text != null)
                {
                    dataGridView1.Rows.Clear();
                    conectar = conn.ObtenerConexion();
                    comando = new MySqlCommand("select Telefono,Nombre, Calle from Clientes where Telefono like  '%" + tbxDescripcion.Text + "%'", conectar);
                    conectar.Open();
                    lector = comando.ExecuteReader();

                    while (lector.Read())
                    {
                        dataGridView1.Rows.Add(lector.GetInt32(0), lector.GetString(1), lector.GetString(2));

                    }
                    conectar.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

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
            if (!("\b0123456789.".Contains(e.KeyChar)))
            {
                e.Handled = true;
                busqueda();
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

        private void BuscarCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
