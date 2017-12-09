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
    public partial class BuscarProductoPP : Form
    {
        int depto = 0;
        public BuscarProductoPP(int dpto)
        {
            InitializeComponent();
            depto = dpto;
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
                    comando = new MySqlCommand("SELECT idproductopantallap,descripcion, precio, tamaño FROM productoPantallap WHERE DepartamentosPP_idDepartamentosPP = "+depto+" AND Descripcion LIKE  '%" + tbxDescripcion.Text + "%'", conectar);
                    conectar.Open();
                    lector = comando.ExecuteReader();

                    while (lector.Read())
                    {
                        if (lector.GetInt32(3) > 0)
                        {
                            dataGridView1.Rows.Add(lector.GetInt32(0), lector.GetString(1) + " " + lector.GetInt32(3)+" cm", lector.GetDouble(2));
                        }
                        else
                        {
                            dataGridView1.Rows.Add(lector.GetInt32(0), lector.GetString(1), lector.GetDouble(2));
                        }
                       
                        
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

        private void BuscarProductoPP_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Escape)
            {
                this.Close();
            }
        }

    }
}
