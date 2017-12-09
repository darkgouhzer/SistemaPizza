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
    public partial class EntradaSalidaEfectivo : Form
    {
        conexion conn = new conexion();
        MySqlConnection conectar;
        MySqlCommand comando;
        MySqlDataReader lector;
        string idusuario="";
        public EntradaSalidaEfectivo(string iduser)
        {
            InitializeComponent();
            idusuario = iduser;
            tbxComentario.MaxLength = 200;
        }

        private void tbxCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!("\b0123456789.".Contains(e.KeyChar)))
            {
                e.Handled = true;

                if (e.KeyChar == 46 && tbxCantidad.Text.IndexOf('.') != -1)
                {

                    e.Handled = true;
                    return;

                }
                if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != 46)
                {

                    e.Handled = true;

                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                double dinero = 0;
                if (tbxCantidad.Text.Length > 0)
                {
                    conectar = conn.ObtenerConexion();
                    comando = new MySqlCommand("select dinero from cortecaja", conectar);
                    conectar.Open();
                    lector = comando.ExecuteReader();
                    while (lector.Read())
                    {
                        dinero = lector.GetDouble(0);
                    }
                    conectar.Close();
                   
                        conectar = conn.ObtenerConexion();
                        if (rbnEntrada.Checked)
                        {
                            comando = new MySqlCommand("insert into entradaefectivo values(null," + tbxCantidad.Text +
                                ",'" + tbxComentario.Text + "',now()," + idusuario + ")", conectar);
                            conectar.Open();
                            comando.ExecuteNonQuery();
                            conectar.Close();

                            //comando = new MySqlCommand("update cortecaja set Dinero=Dinero+" + Convert.ToDouble(tbxCantidad.Text) + " where id=1 ", conectar);
                            //conectar.Open();
                            //comando.ExecuteNonQuery();
                            //conectar.Close();
                            printDocument1.Print();
                            MessageBox.Show("Entrada de dinero realizada con éxito.");
                        }
                        else if (rbnSalida.Checked && Convert.ToDouble(tbxCantidad.Text) <= dinero)
                        {
                            comando = new MySqlCommand("insert into salidaefectivo values(null," + tbxCantidad.Text +
                               ",'" + tbxComentario.Text + "',now()," + idusuario + ")", conectar);
                            conectar.Open();
                            comando.ExecuteNonQuery();
                            conectar.Close();

                            //comando = new MySqlCommand("update cortecaja set Dinero=Dinero-"+Convert.ToDouble(tbxCantidad.Text)+" where id=1 ", conectar);
                            //conectar.Open();
                            //comando.ExecuteNonQuery();
                            //conectar.Close();
                            printDocument1.Print();
                            MessageBox.Show("Salida de dinero realizada con éxito.");
                        }
                        else
                        {
                            MessageBox.Show("No puede salir mas dinero que el que hay en caja.");
                        }
                        
                    
                }
                else
                {
                    MessageBox.Show("Antes de aceptar es necesario ingresar una cantidad.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void EntradaSalidaEfectivo_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
