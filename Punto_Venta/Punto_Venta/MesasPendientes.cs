using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Punto_Venta
{
    public partial class MesasPendientes : Form
    {
        conexion conn = new conexion();
        MySqlConnection conectar;
        MySqlCommand comando;
        MySqlDataReader lector;
        public string NumeroMesa;
        public MesasPendientes()
        {
            InitializeComponent();
            NumeroMesa = "";
            ObtenerMesasPendientes();
        }
        public void ObtenerMesasPendientes()
        {
            try
            {
                dtgMesas.Rows.Clear();
                conectar = conn.ObtenerConexion();                
                comando = new MySqlCommand("select NumeroMesa as NumeroMesa from preventadetalle group by NumeroMesa order by NumeroMesa ASC ;", conectar);
                conectar.Open();
                MySqlDataReader lector;
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    dtgMesas.Rows.Add(lector.GetString(0));
                }
                conectar.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MesasPendientes_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                NumeroMesa = "";
                this.Close();
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            try
            {
                NumeroMesa = dtgMesas.CurrentCell.Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Close();
        }
    }
}
