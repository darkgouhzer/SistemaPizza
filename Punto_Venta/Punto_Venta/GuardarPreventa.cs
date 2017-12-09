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
    public partial class btnConsultarVenta : Form
    {
        public List<DatosProductos> lsDatosProductos;
        conexion conn = new conexion();
        MySqlConnection conectar;
        MySqlCommand comando;
        MySqlDataReader lector;
        String sSqlCmd = "";
        public int iNumeroMesa = 0;
        public Boolean bImprimir = false;
        public btnConsultarVenta(List<DatosProductos> lsDatosProductos, int iNumeroMesa)
        {
            InitializeComponent();
            this.lsDatosProductos = lsDatosProductos;
            llenarGrid();
            if (iNumeroMesa==0)
            {
                SugerirMesa();
            }
            else
            {
                tbxNumeroMesa.Text = iNumeroMesa.ToString();
            }
            
        }
        public void llenarGrid()
        {
            try
            {
                if (lsDatosProductos.Count > 0)
                {
                    dtgTicket.Rows.Clear();
                    foreach(DatosProductos objDatosProductos in lsDatosProductos)
                    {
                        dtgTicket.Rows.Add(objDatosProductos.sCodigo, objDatosProductos.iCantidad, objDatosProductos.sDescripcion,
                            objDatosProductos.dPrecio, objDatosProductos.dTotal, objDatosProductos.sCodigoP,
                            objDatosProductos.sLigueIngExtra);                        
                    }
                }
                else
                {
                    dtgTicket.Rows.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void SugerirMesa()
        {
            try
            {
                conectar = conn.ObtenerConexion();
                comando = new MySqlCommand("select coalesce(max(NumeroMesa),0)+1 as NumeroMesa from preventadetalle;", conectar);
                conectar.Open();
                MySqlDataReader lector;
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    tbxNumeroMesa.Text = lector.GetString("NumeroMesa");
                }
                conectar.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnConsultarVenta_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Escape)
            {
                this.Close();
            }
        }

        private void tbxNumeroMesa_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                sSqlCmd = String.Format("DELETE FROM preventadetalle WHERE NumeroMesa={0};",tbxNumeroMesa.Text);
                conectar = conn.ObtenerConexion();
                comando = new MySqlCommand(sSqlCmd, conectar);
                conectar.Open();
                
                foreach(DatosProductos objDatosProductos in lsDatosProductos )
                {
                    sSqlCmd += String.Format("INSERT INTO preventadetalle(NumeroMesa,Descripcion,Cantidad,Precio,"+
                    "Total,CodigoProductos,CodigoProductosP,LigueIngExtra) VALUES({0},'{1}',{2},{3},{4},{5},'{6}',{7});",
                    tbxNumeroMesa.Text, objDatosProductos.sDescripcion, objDatosProductos.iCantidad, objDatosProductos.dPrecio,
                    objDatosProductos.dTotal, objDatosProductos.sCodigo, objDatosProductos.sCodigoP, objDatosProductos.sLigueIngExtra);
                }
                comando = new MySqlCommand(sSqlCmd, conectar);
                comando.ExecuteNonQuery();
                conectar.Close();
                iNumeroMesa = Convert.ToInt32(tbxNumeroMesa.Text);
                MessageBox.Show("Mesa guardada con éxito.");
                this.Close();
                lsDatosProductos = new List<DatosProductos>();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        private void btnConsultarMesas_Click(object sender, EventArgs e)
        {
            MesasPendientes objConsultarMesas = new MesasPendientes();
            objConsultarMesas.ShowDialog();
            if(objConsultarMesas.NumeroMesa!="")
            {
                tbxNumeroMesa.Text = objConsultarMesas.NumeroMesa;
                btnObtenerProductos_Click(sender, e);
            }            
        }

        private void btnTransferir_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("¿Seguro que desea hacer la transferencia hacia la mesa "+
                                                    tbxNumeroMesa.Text+" ?","", MessageBoxButtons.YesNo);
                if (DialogResult.Yes == dr)
                {                   
                    conectar = conn.ObtenerConexion();
                    comando = new MySqlCommand(sSqlCmd, conectar);
                    conectar.Open();
                    sSqlCmd = String.Format("DELETE FROM preventadetalle WHERE NumeroMesa={0};",  lsDatosProductos[0].iNumeroMesa);
                    foreach (DatosProductos objDatosProductos in lsDatosProductos)
                    {
                        sSqlCmd += String.Format("INSERT INTO preventadetalle(NumeroMesa,Descripcion,Cantidad,Precio," +
                        "Total,CodigoProductos,CodigoProductosP,LigueIngExtra) VALUES({0},'{1}',{2},{3},{4},{5},'{6}',{7});",
                        tbxNumeroMesa.Text, objDatosProductos.sDescripcion, objDatosProductos.iCantidad, objDatosProductos.dPrecio,
                        objDatosProductos.dTotal, objDatosProductos.sCodigo, objDatosProductos.sCodigoP, objDatosProductos.sLigueIngExtra);
                    }
                    comando = new MySqlCommand(sSqlCmd, conectar);
                    comando.ExecuteNonQuery();
                    conectar.Close();
                    lsDatosProductos = new List<DatosProductos>();
                    dtgTicket.Rows.Clear();
                    iNumeroMesa = Convert.ToInt32(tbxNumeroMesa.Text);
                    MessageBox.Show("Transferencia realizada con éxito.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAsignarMesa_Click(object sender, EventArgs e)
        {
            try
            {
                int count = 0;
                sSqlCmd = String.Format("SELECT COUNT(NumeroMesa) FROM preventadetalle WHERE NumeroMesa={0};", tbxNumeroMesa.Text);
                conectar = conn.ObtenerConexion();
                comando = new MySqlCommand(sSqlCmd, conectar);
                conectar.Open();
                count = Convert.ToInt32(comando.ExecuteScalar());
                if (count == 0)
                {
                    sSqlCmd = String.Format("DELETE FROM preventadetalle WHERE NumeroMesa={0};", lsDatosProductos[0].iNumeroMesa);
                    foreach (DatosProductos objDatosProductos in lsDatosProductos)
                    {
                        sSqlCmd += String.Format("INSERT INTO preventadetalle(NumeroMesa,Descripcion,Cantidad,Precio," +
                        "Total,CodigoProductos,CodigoProductosP,LigueIngExtra) VALUES({0},'{1}',{2},{3},{4},{5},'{6}',{7});",
                        tbxNumeroMesa.Text, objDatosProductos.sDescripcion, objDatosProductos.iCantidad, objDatosProductos.dPrecio,
                        objDatosProductos.dTotal, objDatosProductos.sCodigo, objDatosProductos.sCodigoP, objDatosProductos.sLigueIngExtra);
                    }
                    comando = new MySqlCommand(sSqlCmd, conectar);
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Mesa asingada con éxito.");  
                }
                else
                {
                    MessageBox.Show("La mesa ya se encuentra ocupada.");
                }              
                conectar.Close();
                iNumeroMesa = Convert.ToInt32(tbxNumeroMesa.Text);             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCargarVenta_Click(object sender, EventArgs e)
        {
            try
            {
                lsDatosProductos = new List<DatosProductos>();
                DatosProductos objDatosProductos;
                conectar = conn.ObtenerConexion();
                sSqlCmd = String.Format("SELECT NumeroMesa,Descripcion,Cantidad,Precio,Total,CodigoProductos,"+
                    "CodigoProductosP, LigueIngExtra FROM preventadetalle WHERE NumeroMesa = {0};", tbxNumeroMesa.Text);
                comando = new MySqlCommand(sSqlCmd, conectar);
                conectar.Open();
                MySqlDataReader lector;
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    objDatosProductos = new DatosProductos();
                    objDatosProductos.iNumeroMesa = lector.GetInt32("NumeroMesa");
                    objDatosProductos.sDescripcion = lector.GetString("Descripcion");
                    objDatosProductos.iCantidad = lector.GetInt32("Cantidad");
                    objDatosProductos.dPrecio = lector.GetDouble("Precio");
                    objDatosProductos.dTotal = lector.GetDouble("Total");
                    objDatosProductos.sCodigo = lector.GetInt32("CodigoProductos").ToString();
                    objDatosProductos.sCodigoP = lector.GetString("CodigoProductosP");
                    objDatosProductos.sLigueIngExtra = lector.GetInt32("LigueIngExtra").ToString();
                    lsDatosProductos.Add(objDatosProductos);

                }
                conectar.Close();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnImprimirPreventa_Click(object sender, EventArgs e)
        {
            try
            {
                 DialogResult dr = MessageBox.Show("¿Seguro que desea imprimir el ticket?"+
                                                    tbxNumeroMesa.Text+" ?","", MessageBoxButtons.YesNo);
                 if (DialogResult.Yes == dr)
                 {
                     bImprimir = true;
                     this.Close();
                 }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnObtenerProductos_Click(object sender, EventArgs e)
        {
            try
            {
                lsDatosProductos = new List<DatosProductos>();
                DatosProductos objDatosProductos;
                conectar = conn.ObtenerConexion();
                sSqlCmd = String.Format("SELECT NumeroMesa,Descripcion,Cantidad,Precio,Total,CodigoProductos," +
                    "CodigoProductosP, LigueIngExtra FROM preventadetalle WHERE NumeroMesa = {0};", tbxNumeroMesa.Text);
                comando = new MySqlCommand(sSqlCmd, conectar);
                conectar.Open();
                MySqlDataReader lector;
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    objDatosProductos = new DatosProductos();
                    objDatosProductos.iNumeroMesa = lector.GetInt32("NumeroMesa");
                    objDatosProductos.sDescripcion = lector.GetString("Descripcion");
                    objDatosProductos.iCantidad = lector.GetInt32("Cantidad");
                    objDatosProductos.dPrecio = lector.GetDouble("Precio");
                    objDatosProductos.dTotal = lector.GetDouble("Total");
                    objDatosProductos.sCodigo = lector.GetInt32("CodigoProductos").ToString();
                    objDatosProductos.sCodigoP = lector.GetString("CodigoProductosP");
                    objDatosProductos.sLigueIngExtra = lector.GetInt32("LigueIngExtra").ToString();
                    lsDatosProductos.Add(objDatosProductos);

                }
                conectar.Close();
                llenarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
