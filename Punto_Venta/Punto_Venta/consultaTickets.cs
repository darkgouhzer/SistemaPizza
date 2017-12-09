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
    public partial class consultaTickets : Form
    {
        conexion conn = new conexion();
        MySqlConnection conectar;
        MySqlCommand comando;
        MySqlDataReader lector;
        public consultaTickets()
        {
            InitializeComponent();
        }
        public Boolean existeT()
        {
            Boolean exist = false;
            try
            {
                if (tbxTicket.Text.Length > 0)
                {              

                    conectar = conn.ObtenerConexion();
                    comando = new MySqlCommand("select count(*) from ventas where no_ticket=" + tbxTicket.Text, conectar);
                    conectar.Open();
                    lector = comando.ExecuteReader();
                    while (lector.Read())
                    {
                        if (lector.GetInt32(0) > 0)
                        {
                            exist = true;
                        }
                        else
                        {
                            MessageBox.Show("El número de ticket no existe.");
                            lblTotal.Text = "$ 0.00";
                            tbxTicket.Clear();
                        }
                    }
                    conectar.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return exist;
        }
        int estado = 0;
        double totalv = 0;
        public void busquedaTicket()
        {
            totalv = 0;
            if (existeT())
            {
                try
                {
                    dtgVenta.Rows.Clear();
                    conectar = conn.ObtenerConexion();

                    comando = new MySqlCommand("select descripcion, cantidad, Total, status, fecha_venta, productos_id from ventas where no_ticket=" + tbxTicket.Text, conectar);
                    conectar.Open();
                    lector = comando.ExecuteReader();
                    while (lector.Read())
                    {
                        estado = lector.GetInt32(3);
                        if (lector.GetInt32(3) == 0)
                        {
                            lblCancelacion.ForeColor = Color.Red;
                            lblCancelacion.Text = "CANCELADO";
                        }
                        else
                        {
                            lblCancelacion.ForeColor = Color.Green;
                            lblCancelacion.Text = "ACTIVO";

                        }
                        lblFecha.Text = lector.GetDateTime(4).ToString("dd/MM/yyyy hh:mm:ss tt");
                        dtgVenta.Rows.Add(lector.GetString(0), lector.GetDouble(1), lector.GetDouble(2), lector.GetString(5));
                        totalv += lector.GetDouble(2);
                    }
                    conectar.Close();
                    lblTotal.Text = totalv.ToString("C2");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                dtgVenta.Rows.Clear();
            }
        }
        private void tbxTicket_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!("\b0123456789".Contains(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void tbxTicket_KeyDown(object sender, KeyEventArgs e)
        {
                if (e.KeyCode == Keys.Enter)
                {
                    busquedaTicket();
                }   
        }

        private void btnCancelarTicket_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgVenta.Rows.Count > 0)
                {
                    if (existeT())
                    {
                        if (estado == 1)
                        {
                            DialogResult dr = MessageBox.Show("¿Está seguro de querer cancelar el ticket?", "Cancelando ticket", MessageBoxButtons.YesNo);
                            if (dr == DialogResult.Yes)
                            {
                                conectar = conn.ObtenerConexion();
                                for (int i = 0; i < dtgVenta.Rows.Count; i++)
                                {
                                    comando = new MySqlCommand("UPDATE productos SET cantidad=cantidad+" + Convert.ToDouble(dtgVenta[1, i].Value) + " where id=" + dtgVenta[3, i].Value, conectar);
                                    conectar.Open();
                                    comando.ExecuteNonQuery();
                                    conectar.Close();
                                }

                                comando = new MySqlCommand("UPDATE ventas SET status=0 where no_ticket=" + tbxTicket.Text, conectar);
                                conectar.Open();
                                comando.ExecuteNonQuery();
                                conectar.Close();
                                lblTotal.Text = "$ 0.00";
                                tbxTicket.Clear();
                                printDocument1.Print();
                                dtgVenta.Rows.Clear();
                                MessageBox.Show("Venta cancelada con éxito.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("No puede cancelar un ticket ya cancelado.");
                        }
                    }
                    else
                    {
                        dtgVenta.Rows.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnReimprimir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void consultaTickets_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }



    }
}
