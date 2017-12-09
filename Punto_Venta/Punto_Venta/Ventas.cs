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
using System.IO.Ports;

namespace Punto_Venta
{
    public partial class Ventas : Form
    {
        string idusuario = "";
        public Ventas(string iduser)
        {
            InitializeComponent();
            tbxCodigo.MaxLength = 25;
            idusuario = iduser;
        }

        conexion conn = new conexion();
        MySqlConnection conectar;
        MySqlCommand comando;
        MySqlDataReader lector;
        int cont = 0;
        double total = 0, totalp = 0, totalf =0;

        private void Ventas_Load(object sender, EventArgs e)
        {
           
        }
        public void agregaVarios(string codigo, double cant)
        {
            cont = 0;
            Cantidad = cant;
            try
            {
                if (verificarExistencia(codigo))
                {
                    conectar = conn.ObtenerConexion();
                    comando = new MySqlCommand("select Codigo_barras, Descripcion,Precio_venta,Precio_compra, id,cantidad from productos where Codigo_barras = '" + codigo + "'", conectar);
                    conectar.Open();

                    lector = comando.ExecuteReader();
                    while (lector.Read())
                    {

                        if (BuscarCodigo(codigo) == false)
                        {
                            if (lector.GetDouble(5) >= Cantidad)
                            {
                                total = Cantidad * lector.GetDouble(2);
                                dtgVentas.Rows.Add(lector.GetString(0), lector.GetString(1), Cantidad, lector.GetDouble(2), total, lector.GetDouble(3), lector.GetInt32(4));
                                cont++;
                                totalp += total;
                                TotalT();
                            }
                            else
                            {
                                MessageBox.Show("Existencias insuficientes en el inventario.");
                            }

                        }

                        else
                        {
                            cont++;
                        }

                    }

                    conectar.Close();
                }
                else
                {
                    MessageBox.Show("Existencias insuficientes en el inventario.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (cont == 0)
            {
                resul = MessageBox.Show("El producto no esta registrado ¿Desea agregarlo?", "Agregar producto", MessageBoxButtons.YesNo);
                if (resul == DialogResult.Yes)
                {
                    nuevoProducto np = new nuevoProducto(idusuario);
                    np.ShowDialog();
                    tbxCodigo.Focus();
                }
            }
            Cantidad = 0;
        }
        private void btnVarios_Click(object sender, EventArgs e)
        {
            varios vr = new varios();
            DialogResult dr = vr.ShowDialog();

            if (dr == DialogResult.OK)
            {
                agregaVarios(vr.regresar.valXn,vr.regresar.valXn2); 
                tbxCodigo.Focus();
            }
          
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                Buscar bscr = new Buscar();
                DialogResult dr = bscr.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    tbxCodigo.Text = bscr.regresar.valXn;
                }
                tbxCodigo.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public Boolean BuscarCodigo(string codigo)
        {           
                if (dtgVentas.Rows.Count > 0)
                {
                    for (int i = 0; i < dtgVentas.Rows.Count;  i++)
                    {
                        if (dtgVentas[0, i].Value.ToString() == codigo)
                        {

                            if (existCant >= (Cantidad + Convert.ToDouble(dtgVentas[2, i].Value)))
                            {
                                dtgVentas[2, i].Value = Convert.ToDouble(dtgVentas[2, i].Value) + Cantidad;
                                total = Convert.ToDouble(dtgVentas[2, i].Value) * Convert.ToDouble(dtgVentas[3, i].Value);
                                dtgVentas[4, i].Value = total;
                                TotalT();
                            }
                            else
                            {
                                MessageBox.Show("Existencias insuficientes en el inventario.");
                            }
                            return true;
                        }
                    }
                }
                return false;       
        }

        double Cantidad = 0;
        public void TotalT()
        {
                totalf = 0;

                if (dtgVentas.Rows.Count > 0)
                {
                    for (int i = 0; i < dtgVentas.Rows.Count; i++)
                    {
                        lblTotal.Text = "";
                        totalf += Convert.ToDouble(dtgVentas[4, i].Value);
                    }
                    lblTotal.Text = totalf.ToString("C");
                }
                else
                {
                    lblTotal.Text = "0";
                }
        }

        DialogResult resul;
        public void agregar()
        {
            cont = 0;
                try
                {
                    if (verificarExistencia(tbxCodigo.Text))
                    {
                        Cantidad = 1;
                        conectar = conn.ObtenerConexion();
                        comando = new MySqlCommand("select Codigo_barras, Descripcion,Precio_venta,Precio_compra, id, cantidad, Tipo from productos where Codigo_barras = '" + tbxCodigo.Text + "'", conectar);
                        conectar.Open();

                        lector = comando.ExecuteReader();
                        while (lector.Read())
                        {
                            if (BuscarCodigo(tbxCodigo.Text) == false)
                            {
                                if (lector.GetDouble(5) >= Cantidad)
                                {
                                    if (lector.GetString(6) == "A granel")
                                    {
                                        Agranel ag = new Agranel(lector.GetString(0));
                                        DialogResult dr = ag.ShowDialog();
                                        if (dr == DialogResult.OK)
                                        {
                                            Cantidad = ag.regresar.valXn2;


                                            total = Cantidad * lector.GetDouble(2);
                                            dtgVentas.Rows.Add(lector.GetString(0), lector.GetString(1), Cantidad, lector.GetDouble(2), total, lector.GetDouble(3), lector.GetInt32(4));
                                            cont++;
                                            totalp += total;
                                            TotalT();
                                        }
                                        else
                                        {
                                            cont++;
                                        }
                                    }
                                    else
                                    {
                                        total = Cantidad * lector.GetDouble(2);
                                        dtgVentas.Rows.Add(lector.GetString(0), lector.GetString(1), Cantidad, lector.GetDouble(2), total, lector.GetDouble(3), lector.GetInt32(4));
                                        cont++;
                                        totalp += total;
                                        TotalT();
                                    }
                                }
                            }
                            else
                            {
                                cont++;
                            }
                        }

                        conectar.Close();
                    }
                    else
                    {
                        MessageBox.Show("Existencias insuficientes en el inventario.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                if (cont == 0)
                {
                    resul = MessageBox.Show("El producto no esta registrado ¿Desea agregarlo?", "Agregar producto", MessageBoxButtons.YesNo);
                    if (resul == DialogResult.Yes)
                    {
                        nuevoProducto np = new nuevoProducto(idusuario);
                        np.ShowDialog();
                    }
                }            
        }

        double existCant;
        public Boolean verificarExistencia(string codbar)
        {
            existCant = 0;
            Boolean existenacia = false;
            conectar = conn.ObtenerConexion();
            comando = new MySqlCommand("select cantidad from productos where codigo_barras='" + codbar + "'", conectar);
            conectar.Open();
            lector = comando.ExecuteReader();
            while (lector.Read())
            {
                existCant = lector.GetDouble(0);
     
            }
            conectar.Close();
            if (existCant> 0)
            {
                existenacia = true;
            }
            return existenacia;
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (tbxCodigo.Text.Length > 0)
            {
                agregar();
            }
            else
            {
                MessageBox.Show("Para continuar es necesario un código de producto.");
            }
        }

        private void tbxCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
          
                if (e.KeyChar == (char)13)
                {
                    if (tbxCodigo.Text.Length > 0)
                    {
                        agregar();

                        tbxCodigo.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Para continuar es necesario un código de producto.");
                    }
                }
           

        }

        private void btnEfectivo_Click(object sender, EventArgs e)
        {
            Efectivo efec = new Efectivo("");
            efec.ShowDialog();
            tbxCodigo.Focus();
        }

        private void btnCorte_Click(object sender, EventArgs e)
        {
            Corte_de_Caja crt = new Corte_de_Caja(idusuario);
            crt.ShowDialog();
            tbxCodigo.Focus();
        }
        double pago = 0;
        int ticket = 0;
        public void realizarVenta()
        {
            try
            {
                if (dtgVentas.Rows.Count > 0)
                {
                    conectar = conn.ObtenerConexion();
                    comando = new MySqlCommand("insert into generarticket values(null)", conectar);
                    conectar.Open();
                    comando.ExecuteNonQuery();
                    conectar.Close();

                    comando = new MySqlCommand("select Max(id) from generarticket", conectar);
                    conectar.Open();
                    lector = comando.ExecuteReader();
                    while (lector.Read())
                    {
                        ticket = lector.GetInt32(0);

                    }
                    conectar.Close();

                    for (int i = 0; i < dtgVentas.Rows.Count; i++)
                    {
                        comando = new MySqlCommand("INSERT INTO ventas values(null,'" + dtgVentas[0, i].Value.ToString() +
                            "','" + dtgVentas[1, i].Value.ToString() + "'," + Convert.ToDouble(dtgVentas[2, i].Value)+
                            ", " + Convert.ToDouble(dtgVentas[5, i].Value) + ", " + Convert.ToDouble(dtgVentas[3, i].Value) +
                            "," + Convert.ToDouble(dtgVentas[4, i].Value) + ", now()," + Convert.ToInt32(dtgVentas[6, i].Value) + 
                            ","+idusuario+","+ticket+",1)", conectar);
                        conectar.Open();
                        comando.ExecuteNonQuery();
                        conectar.Close();

                        comando = new MySqlCommand("update productos set cantidad=cantidad-" + Convert.ToDouble(dtgVentas[2, i].Value) + " where codigo_barras='" + dtgVentas[0, i].Value.ToString()+"'", conectar);
                        conectar.Open();
                        comando.ExecuteNonQuery();
                        conectar.Close();
                    }
                }
                else
                {
                    MessageBox.Show("No puede registrar venta sin artículos seleccionados.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            pago = 0;
            Cobrar cbr = new Cobrar(lblTotal.Text);
            DialogResult dr=cbr.ShowDialog();
            if (dr == DialogResult.OK)
            {
                 pago = Convert.ToDouble(cbr.regresar.valXn);
                 realizarVenta();
                printDocument1.Print();
                 dtgVentas.Rows.Clear();
            }
            tbxCodigo.Focus();
        }

        private void dtgVentas_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            TotalT();
        }

        private void dtgVentas_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            TotalT();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font letraTi = new Font("Arial", 9, FontStyle.Bold);
            Font letra = new Font("Arial", 6);

              e.Graphics.DrawString("Carniceria HM", letraTi, Brushes.Black, new Rectangle(2,2,200,50));
              e.Graphics.DrawString("Tamazula, Guasave, Sinaloa", letraTi, Brushes.Black, new Rectangle(2, 14, 200, 50));
              e.Graphics.DrawString("Tel- 687 88 1 50 50", letraTi, Brushes.Black, new Rectangle(2, 28, 200, 50));
              //e.Graphics.DrawString("RFC- MAZD 460503 8L9", letra, Brushes.Black, new Rectangle(2, 38, 200, 50));
              e.Graphics.DrawString("Ticket # "+ticket, letraTi, Brushes.Black, new Rectangle(2, 40, 200, 50));
              e.Graphics.DrawString(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt"), letraTi, Brushes.Black, new Rectangle(2, 52, 200, 50));
              e.Graphics.DrawString("=========================", letraTi, Brushes.Black, new Rectangle(2, 64, 200, 50));
              e.Graphics.DrawString("CANT      DESCRIPCIÓN     IMPORTE", new Font("Arial",7,FontStyle.Bold), Brushes.Black, new Rectangle(2, 76, 200, 50));
              e.Graphics.DrawString("=========================", letraTi, Brushes.Black, new Rectangle(2, 88, 200, 50));
              int y = 100;
              for (int i = 0; i < dtgVentas.Rows.Count; i++)
              {
                  e.Graphics.DrawString(dtgVentas.Rows[i].Cells[2].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(2, y, 28, 15));
                  e.Graphics.DrawString(dtgVentas.Rows[i].Cells[1].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(30, y, 145, 15));
                  e.Graphics.DrawString(dtgVentas.Rows[i].Cells[4].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(125, y, 200, 15));
                
                  y += 12;
              }


              e.Graphics.DrawString("=========================", letraTi, Brushes.Black, new Rectangle(2, y, 200, 50));

              y += 12;
              double iva = Convert.ToDouble(lblTotal.Text.Substring(1)) * 0.16;
              double subtotal=Convert.ToDouble(lblTotal.Text.Substring(1))-iva;
              e.Graphics.DrawString("Subtotal:", letra, Brushes.Black, new Rectangle(75, y, 100, 15));
              e.Graphics.DrawString(subtotal.ToString("C"), letra, Brushes.Black, new Rectangle(125, y, 200, 15));

              y += 12;
              e.Graphics.DrawString("Iva:", letra, Brushes.Black, new Rectangle(75, y, 100, 15));
              e.Graphics.DrawString(iva.ToString("C"), letra, Brushes.Black, new Rectangle(125, y, 200, 15));

              y += 12;
              e.Graphics.DrawString("Total:", letra, Brushes.Black, new Rectangle(75, y, 100, 15));
              e.Graphics.DrawString(lblTotal.Text, letra, Brushes.Black, new Rectangle(125, y, 200, 15));

              y += 12;
              e.Graphics.DrawString("Efectivo:", letra, Brushes.Black, new Rectangle(75, y, 100, 15));
              e.Graphics.DrawString(pago.ToString("C"), letra, Brushes.Black, new Rectangle(125, y, 200, 15));

              y += 12;
              double cambio = pago - Convert.ToDouble(lblTotal.Text.Substring(1));
              e.Graphics.DrawString("Cambio:", letra, Brushes.Black, new Rectangle(75, y, 100, 15));
              e.Graphics.DrawString(cambio.ToString("C"), letra, Brushes.Black, new Rectangle(125, y, 200, 15));

              y += 24;

              e.Graphics.DrawString("LO ESPERAMOS PRONTO", new Font("Arial",8,FontStyle.Bold), Brushes.Black, new Rectangle(20, y, 200, 50));

              y += 12;

              e.Graphics.DrawString("GRACIAS POR SU COMPRA", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(20, y, 200, 50));



        }

        private void btnEfectivo_Click_1(object sender, EventArgs e)
        {
            EntradaSalidaEfectivo ese = new EntradaSalidaEfectivo(idusuario);
            ese.ShowDialog();
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            Proveedores prv = new Proveedores(idusuario);
            prv.ShowDialog();
        }

        private void tbxCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                pago = 0;
                Cobrar cbr = new Cobrar(lblTotal.Text);
                DialogResult dr = cbr.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    pago = Convert.ToDouble(cbr.regresar.valXn);
                    realizarVenta();
                    printDocument1.Print();
                    dtgVentas.Rows.Clear();
                }
                tbxCodigo.Focus();

            }

            if (e.KeyCode == Keys.F2)
            {
                varios vr = new varios();
                DialogResult dr = vr.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    agregaVarios(vr.regresar.valXn, vr.regresar.valXn2);
                    tbxCodigo.Focus();
                }
          
            }

            if (e.KeyCode == Keys.F3)
            {
                try
                {
                    Buscar bscr = new Buscar();
                    DialogResult dr = bscr.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        tbxCodigo.Text = bscr.regresar.valXn;
                    }
                    tbxCodigo.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (e.KeyCode == Keys.F4)
            {
                EntradaSalidaEfectivo ese = new EntradaSalidaEfectivo(idusuario);
                ese.ShowDialog();
            }

            if (e.KeyCode == Keys.F5)
            {
                Proveedores pr = new Proveedores(idusuario);
                pr.ShowDialog();
            }

            if (e.KeyCode == Keys.F6)
            {
                Corte_de_Caja crt = new Corte_de_Caja(idusuario);
                crt.ShowDialog();
                tbxCodigo.Focus();
            }

            if (e.KeyCode == Keys.F7)
            {
                consultaTickets tk = new consultaTickets();
                tk.ShowDialog();
                tbxCodigo.Focus();
            }

            
        }

        private void Ventas_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F1)
            {
                pago = 0;
                Cobrar cbr = new Cobrar(lblTotal.Text);
                DialogResult dr = cbr.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    pago = Convert.ToDouble(cbr.regresar.valXn);
                    realizarVenta();
                    printDocument1.Print();
                    dtgVentas.Rows.Clear();
                }
                tbxCodigo.Focus();
            }

            if (e.KeyCode == Keys.F2)
            {
                varios vr = new varios();
                DialogResult dr = vr.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    agregaVarios(vr.regresar.valXn, vr.regresar.valXn2);
                    tbxCodigo.Focus();
                }
          
            }

            if (e.KeyCode == Keys.F3)
            {
                try
                {
                    Buscar bscr = new Buscar();
                    DialogResult dr = bscr.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        tbxCodigo.Text = bscr.regresar.valXn;
                    }
                    tbxCodigo.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (e.KeyCode == Keys.F4)
            {
                EntradaSalidaEfectivo ese = new EntradaSalidaEfectivo(idusuario);
                ese.ShowDialog();
            }

            if (e.KeyCode == Keys.F5)
            {
                Proveedores pr = new Proveedores(idusuario);
                pr.ShowDialog();
            }

            if (e.KeyCode == Keys.F6)
            {
                Corte_de_Caja crt = new Corte_de_Caja(idusuario);
                crt.ShowDialog();
                tbxCodigo.Focus();
            }
            
            if (e.KeyCode == Keys.F7)
            {
                consultaTickets tk = new consultaTickets();
                tk.ShowDialog();
                tbxCodigo.Focus();
            }
        }

        private void btnAgregar_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F1)
            {
                pago = 0;
                Cobrar cbr = new Cobrar(lblTotal.Text);
                DialogResult dr = cbr.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    pago = Convert.ToDouble(cbr.regresar.valXn);
                    realizarVenta();
                    printDocument1.Print();
                    dtgVentas.Rows.Clear();
                }
                tbxCodigo.Focus();

            }

            if (e.KeyCode == Keys.F2)
            {
                varios vr = new varios();
                DialogResult dr = vr.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    agregaVarios(vr.regresar.valXn, vr.regresar.valXn2);
                    tbxCodigo.Focus();
                }
          
            }

            if (e.KeyCode == Keys.F3)
            {
                try
                {
                    Buscar bscr = new Buscar();
                    DialogResult dr = bscr.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        tbxCodigo.Text = bscr.regresar.valXn;
                    }
                    tbxCodigo.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (e.KeyCode == Keys.F4)
            {
                EntradaSalidaEfectivo ese = new EntradaSalidaEfectivo(idusuario);
                ese.ShowDialog();
            }

            if (e.KeyCode == Keys.F5)
            {
                Proveedores pr = new Proveedores(idusuario);
                pr.ShowDialog();
            }

            if (e.KeyCode == Keys.F6)
            {
                Corte_de_Caja crt = new Corte_de_Caja(idusuario);
                crt.ShowDialog();
                tbxCodigo.Focus();
            }

            if (e.KeyCode == Keys.F7)
            {
                consultaTickets tk = new consultaTickets();
                tk.ShowDialog();
                tbxCodigo.Focus();
            }
            
        }

        private void tbxTicket_Click(object sender, EventArgs e)
        {
            consultaTickets tick = new consultaTickets();
            tick.ShowDialog();
        }

     

        private void btnBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                tbxCodigo.Focus();
            }
        }

        private void btnEfectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                tbxCodigo.Focus();
            }
        }

        private void btnProveedores_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                tbxCodigo.Focus();
            }
        }

        private void btnAgregar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                tbxCodigo.Focus();
            }
        }

        private void button3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                tbxCodigo.Focus();
            }
        }

        private void tbxTicket_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                tbxCodigo.Focus();
            }
        }

        private void btnCorte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                tbxCodigo.Focus();
            }
        }

        private void btnVarios_KeyDown(object sender, KeyEventArgs e)
        {
            
                varios vr = new varios();
                DialogResult dr = vr.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    agregaVarios(vr.regresar.valXn, vr.regresar.valXn2);
                    tbxCodigo.Focus();
                }
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}



