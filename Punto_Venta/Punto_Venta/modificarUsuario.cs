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
    public partial class modificarUsuario : Form
    {
        conexion conn = new conexion();
        MySqlConnection conectar;
        MySqlCommand comando;
        MySqlDataReader lector;
        int idUsuario;
        public modificarUsuario(int id)
        {
            InitializeComponent();
            idUsuario = id;
            rellenarCampos(id);
            //cbxPrivilegios.SelectedIndex = 1;
        }
        public void rellenarCampos(int id)
        {
            try
            {
                conectar = conn.ObtenerConexion();
                comando = new MySqlCommand("select id,nombre,privilegio from usuarios where id='" + id + "'", conectar);
                conectar.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    tbxUsuarios.Text = lector.GetString("nombre");                    
                    cbxPrivilegios.Text = lector.GetString("privilegio");
                    if (lector.GetInt32("id") == 1)
                    {
                        cbxPrivilegios.Enabled = false;
                    }
                }
                conectar.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public Boolean existeUsuario()
        {
            conectar = conn.ObtenerConexion();
            comando = new MySqlCommand("select count(*) from usuarios where nombre='" + tbxUsuarios.Text + "' and id<>"+idUsuario+"", conectar);
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
        public Boolean verificarPwd()
        {
            string contrasena;
            int cont = 0;
            try
            {                
                    conectar = conn.ObtenerConexion();
                    MD5 hashm = MD5.Create();
                    contrasena = GetMd5Hash(hashm, tbxPwdanterior.Text);
                    comando = new MySqlCommand("Select Count(*) from usuarios where id="+idUsuario+" and contrasena='"+contrasena+"'", conectar);
                    conectar.Open(); 
                    lector = comando.ExecuteReader();
                    while (lector.Read())
                    {
                        cont=lector.GetInt32(0);
                    }
                    conectar.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (cont > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string contrasena = "";
            try
            {
                Boolean existe = existeUsuario();
                Boolean pwdCorrecto = verificarPwd();
                if (!existe)
                {
                    if (pwdCorrecto)
                    {
                        if (tbxUsuarios.Text.Length >= 5)
                        {
                            if (tbxPwd.Text.Length > 0)
                            {
                                if (tbxPwd.Text == tbxPwd2.Text)
                                {
                                    conectar = conn.ObtenerConexion();
                                    MD5 hashm = MD5.Create();
                                    contrasena = GetMd5Hash(hashm, tbxPwd.Text);
                                    comando = new MySqlCommand("UPDATE usuarios SET Nombre='" + tbxUsuarios.Text + "', contrasena='" + contrasena + "',privilegio ='" + cbxPrivilegios.Text + "' WHERE id=" + idUsuario + "", conectar);
                                    conectar.Open();
                                    comando.ExecuteNonQuery();
                                    conectar.Close();
                                    MessageBox.Show("Datos actualizados con éxito.");
                                }
                                else
                                {
                                    MessageBox.Show("Las contraseñas no coinciden.");
                                }
                            }
                            else
                            {
                                MessageBox.Show("La contraseña debe tener mas de 5 letras.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("El nombre de usuario debe contener 5 o mas letras.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Contraseña anterior incorrecta.");
                    }
                }
                else
                {
                    MessageBox.Show("El nombre de usuario ya existe.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
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

        private void modificarUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

    }
}
