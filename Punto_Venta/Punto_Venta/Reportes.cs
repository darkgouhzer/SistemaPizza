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
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;

namespace Punto_Venta
{
    public partial class Reportes : Form
    {
        conexion conn = new conexion();
        MySqlConnection conectar;
        MySqlCommand comando;
        MySqlDataReader lector;

        public Reportes()
        {
            InitializeComponent();
           // obtenerDeptos(); 
            //cbxDepto.SelectedIndex = 0;

            dtpInicio.Value = DateTime.Now;
            dtpFin.Value = DateTime.Now;
            dtpCompInicio.Value = DateTime.Now;
            dtpCompFin.Value = DateTime.Now;
        }

        private void btnSP_Click(object sender, EventArgs e)
        {
            Buscar bsp = new Buscar();
            DialogResult  dr= bsp.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tbxTicket.Text = bsp.regresar.valXn;
                tbxTicket.Focus();
            }
        }
        public void obtenerDeptos()
        {

            //List<usuariosLista> lista = new List<usuariosLista>();
            //conectar = conn.ObtenerConexion();
            //comando = new MySqlCommand("select idDepartamentos, Descripcion from departamentos", conectar);
            //conectar.Open();
            //usuariosLista datos1 = new usuariosLista();
            //datos1.ID = 0;
            //datos1.nombre ="Todos";
            //lista.Add(datos1);
            //MySqlDataReader lector;
            //lector = comando.ExecuteReader();
            //while (lector.Read())
            //{
            //    usuariosLista datos = new usuariosLista();
            //    datos.ID = lector.GetInt32(0);
            //    datos.nombre = lector.GetString(1);
            //    lista.Add(datos);

            //}
            //conectar.Close();
            //cbxDepto.DataSource = lista;
            //cbxDepto.DisplayMember = "nombre";
            //cbxDepto.ValueMember = "ID";
        }
      

        private void tbxProducto_Leave(object sender, EventArgs e)
        {
        }

        private void tbxProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
              
            }
        }
        double sumaTotal = 0;
        String ticket="";
        DateTime fechai;
        DateTime fechaf;
        private void btnReporte_Click(object sender, EventArgs e)
        {
            ticket="";

            sumaTotal = 0;
            //dtpInicio.Value.ToString("yyyyMMdd000000");
            //dtpFin.Value.ToString("yyyyMMdd235959");
            //fechai = Convert.ToDateTime(dtpInicio);
            //fechaf = Convert.ToDateTime(dtpFin);
            if (tbxTicket.Text != "")
            {
                ticket = "vd.No_ticket = " + tbxTicket.Text +" and ";
            }
            tblReporteV.Rows.Clear();
            conectar = conn.ObtenerConexion();

            comando = new MySqlCommand("select vd.No_ticket, vd.descripcion, vd.Cantidad, vd.Precio, vd.Total, v.fecha_venta from venta v "+
            " inner join ventadetalle vd on v.no_ticket = vd.no_ticket "+
            " where  " + ticket + " v.fecha_venta between '" + dtpInicio.Value.ToString("yyyyMMdd000000") + 
            "' and '"+dtpFin.Value.ToString("yyyyMMdd235959")+"'", conectar);
            //comando = new MySqlCommand("SELECT v.id, v.descripcion, sum(v.cantidad), sum(v.Total) " +
            //"FROM ventas v, productopantallap p WHERE v.status=1 and" +
            //" v.id=p.idproductopantallap and v.fecha_venta BETWEEN '" + dtpInicio.Value.ToString("yyyyMMdd000000") + "' AND '" + dtpFin.Value.ToString("yyyyMMdd235959") + "' " + productos + " GROUP BY v.id ORDER BY v.fecha_venta ASC", conectar);
            conectar.Open();
            lector = comando.ExecuteReader();
            while (lector.Read())
            {
                tblReporteV.Rows.Add(lector.GetString(0), lector.GetString(1), lector.GetDouble(2), lector.GetDouble(3), lector.GetDouble(4),
                    lector.GetDateTime(5));
                sumaTotal += Convert.ToDouble(lector.GetString(4));

            }
            conectar.Close();
            lblTotal.Text = sumaTotal.ToString("C2");
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            AbrirConsultaExcel(tblReporteV);
        }
        public void AbrirConsultaExcel(DataGridView dgvConsulta)
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

                oSheet.Cells[1, 1] = dgvConsulta.Columns[0].HeaderText;
                oSheet.Cells[1, 2] = dgvConsulta.Columns[1].HeaderText;
                oSheet.Cells[1, 3] = dgvConsulta.Columns[2].HeaderText;
                oSheet.Cells[1, 4] = dgvConsulta.Columns[3].HeaderText;
                oSheet.Cells[1, 5] = dgvConsulta.Columns[4].HeaderText;
                oSheet.Cells[1, 6] = dgvConsulta.Columns[5].HeaderText;
                //Format A1:D1 as bold, vertical alignment = center.
                oSheet.get_Range("A1", "I1").Font.Bold = true;
                oSheet.get_Range("A1", "I1").VerticalAlignment =
                    Excel.XlVAlign.xlVAlignCenter;
                oSheet.get_Range("A1", "I1").HorizontalAlignment =
                    Excel.XlVAlign.xlVAlignJustify;
                // Create an array to multiple values at once.
                int fila = dgvConsulta.Rows.Count;
                int colum = dgvConsulta.Columns.Count;
                string[,] saNames = new string[fila, colum];

                for (int i = 0; i < fila; i++)
                {
                    for (int j = 0; j < colum; j++)
                    {
                        oSheet.Cells[i + 2, j + 1] = dgvConsulta[j, i].Value.ToString();
                    }
                }
                //Fill A2:B6 with an array of values (First and Last Names).
                //oSheet.get_Range("A2", "D6").Value2 = saNames;
                //Fill C2:C6 with a relative formula (=A2 & " " & B2).
                // oRng = oSheet.get_Range("C2", "C6");
                //oRng.Formula = "=A2 & \" \" & B2";
                //Fill D2:D6 with a formula(=RAND()*100000) and apply format.
                oRng = oSheet.get_Range("D:D");
                oRng.NumberFormat = "_-$* #,##0.00_-;-$* #,##0.00_-;_-$* \" - \"??_-;_-@_-";
                //oRng.Formula = "=RAND()*100000";
                oRng = oSheet.get_Range("A1", "I1");
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

        private void btnBuscarP_Click(object sender, EventArgs e)
        {
            buscarProveedor bpro = new buscarProveedor();

            DialogResult dr = bpro.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tbxProveedor.Text = bpro.regresar.valXn;
                tbxProveedor.Focus();
            }
        }
        string proveedor="";
        public void obtenerProveedor()
        {
            try
            {               
                conectar = conn.ObtenerConexion();
                comando = new MySqlCommand("select Nombre from proveedores where id='" + tbxProveedor.Text + "'", conectar);
                conectar.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    tbxNProveedor.Text = lector.GetString(0);
                }
                conectar.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbxProveedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                obtenerProveedor();
            }
        }

        private void tbxProveedor_Leave(object sender, EventArgs e)
        {
            obtenerProveedor();
        }

        private void btnRepComp_Click(object sender, EventArgs e)
        {
            try
            {
                sumaTotal = 0;

                if (tbxProveedor.Text.Length > 0)
                {
                    proveedor = " c.proveedores_id=" + tbxProveedor.Text+" and";
                }
                else
                {
                    proveedor = "";
                }
                dtgCompra.Rows.Clear();
                conectar = conn.ObtenerConexion();

                comando = new MySqlCommand("SELECT c.codigo_barras, c.descripcion, sum(c.cantidad), sum(c.importe) " +
                "FROM compras c, productos p WHERE " + proveedor +
                " c.codigo_barras= p.codigo_barras and c.fecha_compra BETWEEN '" + dtpCompInicio.Value.ToString("yyyyMMdd000000") + "' AND '" + dtpCompFin.Value.ToString("yyyyMMdd235959") + "' GROUP BY c.codigo_barras ORDER BY c.fecha_compra ASC", conectar);
                conectar.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    dtgCompra.Rows.Add(lector.GetString(0), lector.GetString(1), lector.GetDouble(2), lector.GetDouble(3));
                    sumaTotal += Convert.ToDouble(lector.GetString(3));

                }
                conectar.Close();
                lblTotalC.Text = sumaTotal.ToString("C2");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExpComp_Click(object sender, EventArgs e)
        {
            AbrirConsultaExcel(dtgCompra);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Reportes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

    }
}
