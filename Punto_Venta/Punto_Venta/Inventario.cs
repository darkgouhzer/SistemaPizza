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
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;

namespace Punto_Venta
{
    public partial class Inventario : Form
    {
        conexion conn = new conexion();
        MySqlConnection conectar;
        MySqlCommand comando;
        MySqlDataReader lector;
        string idusuario = "";
        public Inventario(string iduser)
        {
            InitializeComponent();
            llenarDatagrid();
            idusuario = iduser;
        }


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            nuevoProducto nvoProd = new nuevoProducto(idusuario);
            nvoProd.ShowDialog();
        }
        public void llenarDatagrid()
        {
            try
            {
                double Total = 0, totalP = 0;
                dataGridView1.Rows.Clear();
                conectar = conn.ObtenerConexion();
                if (rbtnNombre.Checked)
                {
                    comando = new MySqlCommand("select id,Codigo_barras,Descripcion,Cantidad,Precio_compra,Precio_venta from productos where Descripcion like '%" + tbxBuscar.Text + "%'", conectar);
                }
                else if (rbtnCodBar.Checked)
                {
                    comando = new MySqlCommand("select id,Codigo_barras,Descripcion,Cantidad,Precio_compra,Precio_venta from productos where Codigo_barras like '%" + tbxBuscar.Text + "%'", conectar);
                }
                conectar.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Total = lector.GetDouble(3) * lector.GetDouble(5);
                    dataGridView1.Rows.Add(lector.GetString(0), lector.GetString(1), lector.GetString(2), lector.GetDouble(3), lector.GetDouble(4), lector.GetDouble(5), Total);
                    totalP += Total;
                }
                conectar.Close();
                lblTotal.Text = totalP.ToString("C2");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (codbar != "")
            {
                modificarProducto modp = new modificarProducto(codbar,idusuario);
                modp.ShowDialog();
                codbar = "";
            }
            else
            {
                MessageBox.Show("Primero seleccione un producto a modificar.");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tbxBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            llenarDatagrid();  
        }

        private void rbtnNombre_CheckedChanged(object sender, EventArgs e)
        {
            tbxBuscar.Focus();
        }

        private void rbtnCodBar_CheckedChanged(object sender, EventArgs e)
        {
            tbxBuscar.Focus();
        }
        String codbar="";
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0&&e.RowIndex<dataGridView1.Rows.Count&&e.RowIndex>-1)
            {
                codbar = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }

        private void Inventario_Activated(object sender, EventArgs e)
        {
            llenarDatagrid();
        }
        DialogResult result;
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (codbar != "")
                {
                    result = MessageBox.Show("¿Esta seguro de querer eliminar el producto selecionado?", "Eliminar producto", MessageBoxButtons.OKCancel);
                    if (result == DialogResult.OK)
                    {
                        conectar = conn.ObtenerConexion();
                        comando = new MySqlCommand("Delete from productos where Codigo_barras='" + codbar + "'", conectar);
                        conectar.Open();
                        comando.ExecuteNonQuery();
                        conectar.Close();
                        MessageBox.Show("Producto eliminado con éxito.");
                        codbar = "";
                    }
                }
                else
                {
                    MessageBox.Show("Primero seleccione un producto");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbxBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (rbtnCodBar.Checked)
            {
                if (!Char.IsNumber(e.KeyChar)&&!Char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (codbar != "")
            {
                entradaInventario entI = new entradaInventario(codbar,idusuario);
                entI.ShowDialog();
            }
            else
            {
                entradaInventario entI = new entradaInventario(codbar, idusuario);
                entI.ShowDialog();
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            AbrirConsultaExcel();
        }
        public void AbrirConsultaExcel()
        {
            Excel.Application oXL;
            Excel._Workbook oWB;
            Excel._Worksheet oSheet;
            Excel.Range oRng;
            try
            {
                //Start Excel and get Application object.
                oXL = new Excel.Application();
                oXL.Visible = true;
                //Get a new workbook.
                oWB = (Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));
                oSheet = (Excel._Worksheet)oWB.ActiveSheet;
                //Add table headers going cell by cell.

                oSheet.Cells[1, 1] = Codigo_barras.HeaderText;
                oSheet.Cells[1, 2] = Descripcion.HeaderText;
                oSheet.Cells[1, 3] = Existencias.HeaderText;
                oSheet.Cells[1, 4] = Costo.HeaderText;
                oSheet.Cells[1, 5] = Precio.HeaderText;
                oSheet.Cells[1, 6] = ColTotal.HeaderText;
                //Format A1:D1 as bold, vertical alignment = center.
                oSheet.get_Range("A1", "K1").Font.Bold = true;
                oSheet.get_Range("A1", "K1").VerticalAlignment =
                    Excel.XlVAlign.xlVAlignCenter;
                oSheet.get_Range("A1", "K1").HorizontalAlignment =
                    Excel.XlVAlign.xlVAlignJustify;

                // Create an array to multiple values at once.
                int fila = dataGridView1.Rows.Count;
                int colum = dataGridView1.Columns.Count;
                string[,] saNames = new string[fila, colum];

                for (int i = 0; i < fila; i++)
                {
                    for (int j = 1; j < colum; j++)
                    {
                        oSheet.Cells[i + 2, j] = dataGridView1[j, i].Value.ToString();
                    }
                }
                //Fill A2:B6 with an array of values (First and Last Names).
                //oSheet.get_Range("A2", "D6").Value2 = saNames;
                //Fill C2:C6 with a relative formula (=A2 & " " & B2).
                // oRng = oSheet.get_Range("C2", "C6");
                //oRng.Formula = "=A2 & \" \" & B2";
                //Fill D2:D6 with a formula(=RAND()*100000) and apply format.
                oRng = oSheet.get_Range("D:F");
                oRng.NumberFormat = "_-$* #,##0.00_-;-$* #,##0.00_-;_-$* \" - \"??_-;_-@_-";
                //oRng.Formula = "=RAND()*100000";
                //oRng = oSheet.get_Range("D2", "D6");
                //oRng.Formula = "=RAND()*100000";
                //oRng.NumberFormat = "$0.00";
                //AutoFit columns A:D.
                oRng = oSheet.get_Range("A1", "L1");
                oRng.EntireColumn.AutoFit();
                oXL.Visible = true;
                oXL.UserControl = true;
            }
            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, theException.Source);
                // MessageBox.Show(errorMessage, "Error");
            }
        }

        private void Inventario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
      

    }
}
