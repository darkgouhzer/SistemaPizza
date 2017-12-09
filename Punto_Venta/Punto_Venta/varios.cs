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
    public partial class varios : Form
    {
        public varios()
        {
            InitializeComponent();
            tbxCodigo.MaxLength = 25;
            tbxCodigo.MaxLength = 10;
        }

        obtenerCodigo _ui = new obtenerCodigo();

        public obtenerCodigo regresar
        {
            get
            {
                return (_ui);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Buscar bscr = new Buscar();
            DialogResult dr = bscr.ShowDialog();
                        
            if (dr == DialogResult.OK)
            {
                tbxCodigo.Text = bscr.regresar.valXn;
            }
            tbxCodigo.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            if (tbxCodigo.Text.Length > 0 && tbxCantidad.Text.Length>0)
            {
                this.DialogResult = DialogResult.OK;
                _ui.valXn = tbxCodigo.Text;
                _ui.valXn2 = Convert.ToDouble(tbxCantidad.Text);
                this.Close();

            }
            else
            {
                MessageBox.Show("No hay datos para seleccionar");
            }
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

        private void btnInicio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tbxCodigo.Text.Length > 0 && tbxCantidad.Text.Length > 0)
                {
                    this.DialogResult = DialogResult.OK;
                    _ui.valXn = tbxCodigo.Text;
                    _ui.valXn2 = Convert.ToDouble(tbxCantidad.Text);
                    this.Close();

                }
                else
                {
                    MessageBox.Show("No hay datos para seleccionar");
                }
            }
        }

        private void tbxCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tbxCodigo.Text.Length > 0)
                {
                    tbxCantidad.Focus();
                }
            }
        }

        private void tbxCantidad_KeyDown(object sender, KeyEventArgs e)
        {


            if (e.KeyCode==Keys.Enter)
            {
                if (tbxCantidad.Text.Length > 0)
                {
                    btnInicio.Focus();
                }
            }
        }

    }
}
