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
using System.Security.Cryptography;

namespace Punto_Venta
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            crearAdmin();
        }

        conexion conn = new conexion();
        MySqlConnection conectar;
        MySqlCommand comando;
        MySqlDataReader lector;
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void crearAdmin()
        {
            try
            {
                conectar = conn.ObtenerConexion();
                comando = new MySqlCommand("select count(*) from usuarios", conectar);
                conectar.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    if (lector.GetInt32(0) == 0)
                    {
                        nuevoUsuario nvoadm = new nuevoUsuario();
                        nvoadm.ShowDialog();
                    }
                }

                conectar.Close();
            }catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        string idUsuario="";
        private void btnInicio_Click(object sender, EventArgs e)
        {
            idUsuario = "";
            this.Visible = false;
            string contrasena;
            try
            {
                conectar = conn.ObtenerConexion();

                MD5 hashm = MD5.Create();
                contrasena = GetMd5Hash(hashm, tbxPwd.Text);
                comando = new MySqlCommand("select id from usuarios where Nombre = '" + tbxUsuario.Text + "' and Contrasena= '" + contrasena + "'", conectar);
                conectar.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    idUsuario = lector.GetString(0);
                }
                conectar.Close();


                if (idUsuario != "")
                {
                    comando = new MySqlCommand("UPDATE usuarios SET ultimoinicio=now() where id="+idUsuario+"", conectar);
                    conectar.Open();
                    comando.ExecuteNonQuery();
                    conectar.Close();
                    Efectivo efec = new Efectivo(idUsuario);
                    efec.ShowDialog();
                    this.Visible = false;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Datos de usuario incorrectos.");
                    this.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        private void tbxUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                tbxPwd.Focus();
            }
        }

        private void tbxPwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnInicio.Focus();
            }
        }
    }
}
