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
    public partial class Cobrar : Form
    {
        public Cobrar(string total2)
        {
            InitializeComponent();
            lblTotal2.Text = total2;
            tbxEfectivo.MaxLength = 6;
            btnCobrar.Enabled = false;
        }
        public Cobrar(string total2,string prov)
        {
            InitializeComponent();
            lblTotal2.Text = total2;
            tbxEfectivo.MaxLength = 6;
            btnCobrar.Enabled = false;
            btnCobrar.Text = "Realizar pago";
        }
        obtenerCodigo _ui = new obtenerCodigo();

        public obtenerCodigo regresar
        {
            get
            {
                return (_ui);
            }
        }
        
        double pago;
        double total;
        double menos;
        private void btCobrar_Click(object sender, EventArgs e)
        {
            if (Convert.ToDouble(tbxTarjeta.Text) >Convert.ToDouble(lblTotal2.Text.Substring(1)))
            {
                MessageBox.Show("Pago con tarjeta no permite cantidades mayores al total a pagar.");
            }
            else if (Convert.ToDouble(tbxEfectivo.Text) + Convert.ToDouble(tbxTarjeta.Text) >= Convert.ToDouble(lblTotal2.Text.Substring(1)))
            {
                this.DialogResult = DialogResult.OK;
                _ui.valXn = Convert.ToDouble(tbxEfectivo.Text).ToString();
                _ui.valXnT = tbxTarjeta.Text;
                this.Close();
            }
            else
            {
                MessageBox.Show("La cantidad a pagar debe ser igual o mayor que el total a pagar");
            }
        }

        private void tbxPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!("\b0123456789.".Contains(e.KeyChar)))
            {
                e.Handled = true;

                if (e.KeyChar == (char)13)
                {
                    pago = Convert.ToDouble(tbxEfectivo.Text);
                    pago = pago + Convert.ToDouble(tbxTarjeta.Text);
                    menos = Convert.ToDouble(lblTotal2.Text.Substring(1));

                    if (pago >= menos)
                    {
                        total = pago - menos;
                        btnCobrar.Enabled = true;

                        if (total >= 0)
                        {
                            lblCambio.Text = total.ToString("C2");
                        }

                    }

                }
                btnCobrar.Focus();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void tbxPago_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void Cobrar_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                if(!tbxEfectivo.Focused)
                {
                    tbxEfectivo.Focus();
                }
                else
                {
                    tbxTarjeta.Focus();
                }
            }
            else if (e.KeyCode == Keys.F10)
            {
                btCobrar_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void tbxTarjeta_KeyPress(object sender, KeyPressEventArgs e)
        {
            tbxPago_KeyPress(sender, e);
        }
    }
}
