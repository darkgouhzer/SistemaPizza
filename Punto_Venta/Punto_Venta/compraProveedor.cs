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
    public partial class compraProveedor : Form
    {
        conexion conn = new conexion();
        MySqlConnection conectar;
        MySqlCommand comando;
        MySqlDataReader lector;
        string idusuario = "";
        string idproveedor = "";
        int existe = 0;
        public compraProveedor(string iduser, string idp)
        {
            InitializeComponent();
            idusuario = iduser;
            idproveedor = idp;
            obtenerProveedor();
            btnPagar.Enabled = false;
        }

        public void obtenerProveedor()
        {
            try
            {
                conectar = conn.ObtenerConexion();
                comando = new MySqlCommand("select Nombre from proveedores where id="+idproveedor+"", conectar);
                conectar.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    tbxNombreP.Text = lector.GetString(0);
                }
                conectar.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void tbxCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (tbxCodigo.Text.Length > 0)
                    {
                        conectar = conn.ObtenerConexion();
                        comando = new MySqlCommand("select count(*) from productos where codigo_barras='" + tbxCodigo.Text + "'", conectar);

                        conectar.Open();
                        lector = comando.ExecuteReader();
                        while (lector.Read())
                        {
                            existe = lector.GetInt32(0);
                        }
                        conectar.Close();
                        if (existe == 0)
                        {
                            DialogResult dr = MessageBox.Show("El producto no encontrado, ¿desea agregarlo?", "Producto no existe", MessageBoxButtons.YesNo);
                            if (dr == DialogResult.Yes)
                            {
                                nuevoProducto nvop = new nuevoProducto(idusuario);
                                nvop.ShowDialog();
                            }
                        }
                        else
                        {
                            tbxCantidad.Focus();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void tbxCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tbxCantidad.Text.Length > 0)
                {
                    tbxCosto.Focus();
                }
            }
        }

        private void tbxCosto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tbxCosto.Text.Length > 0)
                {
                    btnAgregar.Focus();
                }
            }
        }
        public Boolean existeproducto()
        {
            Boolean existeP = false;
            try
            {
                conectar = conn.ObtenerConexion();
                comando = new MySqlCommand("select count(*) from productos where codigo_barras='" + tbxCodigo.Text + "'", conectar);

                conectar.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    if (lector.GetInt32(0) > 0)
                    {
                        existeP = true;
                    }
                }
                conectar.Close();
                if (!existeP)
                {
                    DialogResult dr = MessageBox.Show("El producto no encontrado, ¿desea agregarlo?", "Producto no existe", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        nuevoProducto nvop = new nuevoProducto(idusuario);
                        nvop.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return existeP;
        }
        public Boolean contieneCodigo(string codigo)
        {

            if (dtgCompra.Rows.Count > 0)
            {
                for (int i = 0; i < dtgCompra.Rows.Count; i++)
                {
                    if (dtgCompra[0, i].Value.ToString() == codigo)
                    {
                        double total = 0;
                        dtgCompra[3, i].Value = tbxCosto.Text;
                        dtgCompra[2, i].Value = Convert.ToDouble(dtgCompra[2, i].Value) + Convert.ToDouble(tbxCantidad.Text);
                        total = Convert.ToDouble(dtgCompra[2, i].Value) * Convert.ToDouble(dtgCompra[3, i].Value);
                        dtgCompra[4, i].Value = total;
                        //TotalT();
                        return true;
                    }
                }
            }
            return false;
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbxCosto.Text.Length > 0 && tbxCodigo.Text.Length > 0 && tbxCantidad.Text.Length > 0)
                {
                    if (existeproducto())
                    {
                        if (!contieneCodigo(tbxCodigo.Text))
                        {
                            conectar = conn.ObtenerConexion();
                            comando = new MySqlCommand("select codigo_barras, descripcion, id from productos where codigo_barras='" + tbxCodigo.Text + "'", conectar);
                            conectar.Open();
                            lector = comando.ExecuteReader();
                            while (lector.Read())
                            {
                                double total = Convert.ToDouble(tbxCosto.Text) * Convert.ToDouble(tbxCantidad.Text);
                                dtgCompra.Rows.Add(lector.GetString(0), lector.GetString(1), tbxCantidad.Text, tbxCosto.Text, total, lector.GetString(2));
                                TotalT();
                            }
                            conectar.Close();
                            btnPagar.Enabled = true;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        double totalf = 0;
        public void TotalT()
        {
            totalf = 0;

            if (dtgCompra.Rows.Count > 0)
            {
                for (int i = 0; i < dtgCompra.Rows.Count; i++)
                {
                    lblTotal.Text = "";
                    totalf += Convert.ToDouble(dtgCompra[4, i].Value);
                }
                lblTotal.Text = totalf.ToString("C");
            }
            else
            {
                lblTotal.Text = "0";
            }
        }
        public void realizarCompra()
        {
            try
            {
                if (dtgCompra.Rows.Count > 0)
                {
                    for (int i = 0; i < dtgCompra.Rows.Count; i++)
                    {
                        comando = new MySqlCommand("INSERT INTO compras values(null,'" + dtgCompra[0, i].Value.ToString() +
                            "','" + dtgCompra[1, i].Value.ToString() + "'," + Convert.ToDouble(dtgCompra[2, i].Value) +
                            "," + Convert.ToDouble(dtgCompra[3, i].Value) + ","+ Convert.ToDouble(dtgCompra[4, i].Value) +" , now(), " + idproveedor + "," + idusuario + "," + Convert.ToInt32(dtgCompra[5, i].Value) + ")", conectar);
                        conectar.Open();
                        comando.ExecuteNonQuery();
                        conectar.Close();

                        comando = new MySqlCommand("update productos set cantidad=cantidad+" + Convert.ToDouble(dtgCompra[2, i].Value) + " where Codigo_barras=" + dtgCompra[0, i].Value.ToString() + " ", conectar);
                        conectar.Open();
                        comando.ExecuteNonQuery();
                        conectar.Close();
                    }
                    MessageBox.Show("Compra realizada con éxito.");
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
     
        double pago = 0;
        private void btnPagar_Click(object sender, EventArgs e)
        {
            pago = 0;
            Cobrar cbr = new Cobrar(lblTotal.Text,idproveedor);
            DialogResult dr = cbr.ShowDialog();
            if (dr == DialogResult.OK)
            {
                if (dtgCompra.Rows.Count > 0)
                {
                    btnPagar.Enabled = true;
                    pago = Convert.ToDouble(cbr.regresar.valXn);
                    realizarCompra();
                    dtgCompra.Rows.Clear();
                }
            }
            tbxCodigo.Focus();
        }

        private void dtgCompra_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            TotalT();
        }

        private void dtgCompra_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            TotalT();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbxCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!("\b0123456789.".Contains(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void compraProveedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

    }
}
