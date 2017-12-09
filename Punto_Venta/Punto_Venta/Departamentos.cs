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
    public partial class Departamentos : Form
    {
        conexion conn = new conexion();
        MySqlConnection conectar;
        MySqlCommand comando;
        MySqlDataReader lector;

        public Departamentos()
        {
            InitializeComponent();
            obtenerDepartamentos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbxDepto.Text.Length > 0)
                {
                    conectar = conn.ObtenerConexion();

                    comando = new MySqlCommand("select idDepartamentos from departamentos where idDepartamentos=1", conectar);
                    conectar.Open();
                    lector = comando.ExecuteReader();
                    int contador=0;
                    while (lector.Read())
                    {
                        contador = lector.GetInt32(0);
                    }
                    conectar.Close();
                    if (contador == 0)
                    {
                        comando = new MySqlCommand("INSERT INTO departamentos values(1,'" + tbxDepto.Text + "')", conectar);
                    }
                    else
                    {
                        comando = new MySqlCommand("INSERT INTO departamentos values(null,'" + tbxDepto.Text + "')", conectar);
                    }
                    conectar.Open();
                    comando.ExecuteNonQuery();
                    conectar.Close();
                    obtenerDepartamentos();
                }
                else
                {
                    MessageBox.Show("Debe asignar nombre al departamento");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        
        public void obtenerDepartamentos()
        {
            
            try
            {
                dtgDepto.Rows.Clear();
                conectar = conn.ObtenerConexion();
                comando = new MySqlCommand("Select * from departamentos where descripcion like '%"+tbxBuscar.Text+"%'", conectar);
                conectar.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    dtgDepto.Rows.Add(lector.GetString(0), lector.GetString(1));
                }
                conectar.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void tbxBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            obtenerDepartamentos();
        }
        int idDepto=0;
        DialogResult result;
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (idDepto != 0)
                {
                    
                        result = MessageBox.Show("¿Esta seguro de querer eliminar el departamento selecionado?", "Eliminar departamento", MessageBoxButtons.OKCancel);
                        if (result == DialogResult.OK)
                        {
                            conectar = conn.ObtenerConexion();
                            comando = new MySqlCommand("Delete from departamentos where idDepartamentos=" + idDepto + "", conectar);
                            conectar.Open();
                            comando.ExecuteNonQuery();
                            conectar.Close();
                            obtenerDepartamentos();
                        }
                }
                else
                {
                    MessageBox.Show("Primero es necesario seleccionar un departamento");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtgDepto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idDepto = Convert.ToInt32(dtgDepto.Rows[e.RowIndex].Cells[0].Value);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Departamentos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
