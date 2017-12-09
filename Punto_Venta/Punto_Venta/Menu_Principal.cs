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
    public partial class Menu_Principal : Form
    {
        conexion conn = new conexion();
        MySqlConnection conectar;
        MySqlCommand comando;
        MySqlDataReader lector;
        string idUsuario="";
        string privilegio = "";
        public Menu_Principal(string iduser)
        {
            InitializeComponent();
            idUsuario = iduser;
            privilegios();
        }
        public void privilegios()
        {
            try
            {
                privilegio = "";
                conectar = conn.ObtenerConexion();
                comando = new MySqlCommand("select privilegio from usuarios where id='" + idUsuario + "'", conectar);
                conectar.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    privilegio = lector.GetString("privilegio");
                }
                conectar.Close();
                if (privilegio == "administrador")
                {
                    btnCajaRapida.Enabled = true;
                    btnCuentasUsuarios.Enabled = true;
                    btnInventarios.Enabled = true;
                    btnProveedores.Enabled = true;
                    btnProductosPantalla.Enabled = true;
                    btnReportes.Enabled = true;
                }
                else if(privilegio=="cajero")
                {
                    btnCajaRapida.Enabled = true;
                    btnCuentasUsuarios.Enabled = false;
                    btnInventarios.Enabled = false;
                    btnProveedores.Enabled = true;
                    btnProductosPantalla.Enabled = false;
                    btnReportes.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Ventas vn = new Ventas(idUsuario);
            //vn.ShowDialog();
            VentaPizza vp = new VentaPizza(idUsuario);
            vp.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cuentas_de_Usuario CU = new Cuentas_de_Usuario();
            CU.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Inventario Inv = new Inventario(idUsuario);
            Inv.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Proveedores PR = new Proveedores(idUsuario);
            PR.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Reportes rpt = new Reportes();
            rpt.ShowDialog();
        }
        
        private void Cerrar_Sesion_Click(object sender, EventArgs e)
        {
            ProductoPantallaPrincipal ppp = new ProductoPantallaPrincipal(idUsuario);
            ppp.ShowDialog();
        }

        DialogResult result;
        private void button5_Click(object sender, EventArgs e)
        {
            result = MessageBox.Show("¿Desea cerrar sesion?", "Cerrar Sesion", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                Close();
            }
        }

        private void Menu_Principal_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
