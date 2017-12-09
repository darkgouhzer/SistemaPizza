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
    public partial class nuevoUsuario : Form
    {
        conexion conn = new conexion();
        MySqlConnection conectar;
        MySqlCommand comando;
        MySqlDataReader lector;
        public nuevoUsuario()
        {
            InitializeComponent();
            tbxUsuarios.MaxLength = 45;
            cbxPrivilegios.SelectedIndex = 1;
        }
        public Boolean existeUsuario()
        {
            conectar = conn.ObtenerConexion();
            comando = new MySqlCommand("select count(*) from usuarios where nombre='" + tbxUsuarios.Text + "'", conectar);
            conectar.Open();
            int n = 0;
            lector = comando.ExecuteReader();
            while (lector.Read())
            {
                n = lector.GetInt32(0);
            }
            conectar.Close();
            if (n > 0)
            {
                return true;
            }
            return false;
        }
        string contrasena;
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbxUsuarios.Text.Length >= 5)
                {
                    if (tbxPwd.Text.Length >= 5 )
                    {
                        if (tbxPwd.Text == tbxPwd2.Text)
                        {
                            Boolean existe = false;
                            existe = existeUsuario();
                            conectar = conn.ObtenerConexion();
                            MD5 hashm = MD5.Create();
                            contrasena = GetMd5Hash(hashm, tbxPwd.Text);
                            int conuser = 0;

                            comando = new MySqlCommand("select count(*) from usuarios", conectar);
                            conectar.Open();
                            lector = comando.ExecuteReader();
                            while (lector.Read())
                            {
                                conuser = lector.GetInt32(0);
                            }

                            conectar.Close();
                            if (conuser == 0)
                            {
                                comando = new MySqlCommand("INSERT INTO usuarios values(1,'" + tbxUsuarios.Text + "','" + contrasena + "','administrador',null)", conectar);
                            }
                            else
                            {
                                comando = new MySqlCommand("INSERT INTO usuarios values(null,'" + tbxUsuarios.Text + "','" + contrasena + "','" + cbxPrivilegios.Text + "',null)", conectar);
                            }
                            conectar.Open();
                            if (!existe)
                            {
                                comando.ExecuteNonQuery();
                                MessageBox.Show("Usuario agregado con éxito.");
                            }
                            else
                            {
                                MessageBox.Show("El usuario ya existe.");
                            }
                            conectar.Close();
                       

                        }
                        else
                        {
                            MessageBox.Show("Las contraseñas no coinciden.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("La contraseña debe tener 5 o mas letras.");
                    }
                }
                else
                {
                    MessageBox.Show("El nombre de usuario debe contener 5 o mas letras.");
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void nuevoUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
