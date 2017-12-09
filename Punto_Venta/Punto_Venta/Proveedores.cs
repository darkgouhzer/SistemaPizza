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
    public partial class Proveedores : Form
    {
        conexion conn = new conexion();
        MySqlConnection conectar;
        MySqlCommand comando;
        MySqlDataReader lector;
        int idP=0;
        string idusuario = "";
        public Proveedores(string iduser)
        {
            InitializeComponent();
            proveedoresRellenar();
            idusuario = iduser;

        }

        public void proveedoresRellenar()
        {
            try
            {
                dtgProveedores.Rows.Clear();
                conectar = conn.ObtenerConexion();
                comando = new MySqlCommand("select id, Nombre, direccion, telefono from proveedores where Nombre like '%"+tbxBuscar.Text+"%'", conectar);
                conectar.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    dtgProveedores.Rows.Add(lector.GetString(0),lector.GetString(1),lector.GetString(2),lector.GetString(3));
                }
                conectar.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            AltaProveedores alp = new AltaProveedores();
            alp.ShowDialog();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

            if (idP != 0)
            {
                modificarProveedor modp = new modificarProveedor(idP);
                modp.ShowDialog();
            }
            else
            {
                MessageBox.Show("Primero seleccione un proveedor");
            }
        }
        DialogResult result;
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (idP != 0)
                {
                    result = MessageBox.Show("¿Esta seguro de querer eliminar el proveedor selecionado?", "Eliminar proveedor", MessageBoxButtons.OKCancel);
                    if (result == DialogResult.OK)
                    {
                        conectar = conn.ObtenerConexion();
                        comando = new MySqlCommand("Delete from proveedores where id=" + idP + "", conectar);
                        conectar.Open();
                        comando.ExecuteNonQuery();
                        conectar.Close();
                        MessageBox.Show("Proveedor eliminado con éxito.");
                    }
                }
                else
                {
                    MessageBox.Show("Primero seleccione un proveedor");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            if (idP != 0)
            {
                compraProveedor compP = new compraProveedor(idusuario, idP.ToString());
                compP.ShowDialog();
            }
            else
            {
                MessageBox.Show("Primero seleccione un proveedor.");
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
                


                oSheet.Cells[1, 1] = dtgNombre.HeaderText;
                oSheet.Cells[1, 2] = Direccion.HeaderText;
                oSheet.Cells[1, 3] = Telefono.HeaderText;
                //Format A1:D1 as bold, vertical alignment = center.
                oSheet.get_Range("A1", "K1").Font.Bold = true;
                oSheet.get_Range("A1", "K1").VerticalAlignment =
                    Excel.XlVAlign.xlVAlignCenter;
                oSheet.get_Range("A1", "K1").HorizontalAlignment =
                    Excel.XlVAlign.xlVAlignJustify;

                // Create an array to multiple values at once.
                int fila = dtgProveedores.Rows.Count;
                int colum = dtgProveedores.Columns.Count;
                string[,] saNames = new string[fila, colum];

                for (int i = 0; i < fila; i++)
                {
                    for (int j = 1; j < colum; j++)
                    {
                        oSheet.Cells[i + 2, j] = dtgProveedores[j, i].Value.ToString();
                    }
                }
                //Fill A2:B6 with an array of values (First and Last Names).
                //oSheet.get_Range("A2", "D6").Value2 = saNames;
                //Fill C2:C6 with a relative formula (=A2 & " " & B2).
                // oRng = oSheet.get_Range("C2", "C6");
                //oRng.Formula = "=A2 & \" \" & B2";
                //Fill D2:D6 with a formula(=RAND()*100000) and apply format.
                oRng = oSheet.get_Range("F:F");
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
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Proveedores_Activated(object sender, EventArgs e)
        {
            proveedoresRellenar();
        }

        private void tbxBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            proveedoresRellenar();
        }

        private void dtgProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgProveedores.Rows.Count > 0 &&e.RowIndex<dtgProveedores.Rows.Count&&e.RowIndex>-1)
            {
                idP = Convert.ToInt32(dtgProveedores.Rows[e.RowIndex].Cells[0].Value);
            }
        }

        private void Proveedores_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
