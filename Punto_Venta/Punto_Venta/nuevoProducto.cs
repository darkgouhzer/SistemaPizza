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
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace Punto_Venta
{
    public partial class nuevoProducto : Form
    {
        conexion conn = new conexion();
        MySqlConnection conectar;
        MySqlCommand comando;
        MySqlDataReader lector;
        string idusuario = "";
        string nombre = "";
        public nuevoProducto(string iduser)
        {
            InitializeComponent();
            obtenerDeptos();
            obtenerProovedor();
            idusuario = iduser;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void obtenerProovedor()
        {

            List<usuariosLista> lista = new List<usuariosLista>();
            conectar = conn.ObtenerConexion();
            comando = new MySqlCommand("select id, Nombre from proveedores", conectar);
            conectar.Open();
            MySqlDataReader lector;
            lector = comando.ExecuteReader();
            while (lector.Read())
            {
                usuariosLista datos = new usuariosLista();
                datos.ID = lector.GetInt32(0);
                datos.nombre = lector.GetString(1);
                lista.Add(datos);

            }
            conectar.Close();
            cbxProveedor.DataSource = lista;
            cbxProveedor.DisplayMember = "nombre";
            cbxProveedor.ValueMember = "ID";
        }

        public void obtenerDeptos()
        {

            List<usuariosLista> lista = new List<usuariosLista>();
            conectar = conn.ObtenerConexion();
            comando = new MySqlCommand("select idDepartamentos, Descripcion from departamentos", conectar);
            conectar.Open();
            MySqlDataReader lector;
            lector = comando.ExecuteReader();
            while (lector.Read())
            {
                usuariosLista datos = new usuariosLista();
                datos.ID = lector.GetInt32(0);
                datos.nombre = lector.GetString(1);
                lista.Add(datos);

            }
            conectar.Close();
            cbxDepto.DataSource = lista;
            cbxDepto.DisplayMember = "nombre";
            cbxDepto.ValueMember = "ID";
        }
        private void btnDeptoMas_Click(object sender, EventArgs e)
        {
            Departamentos depto = new Departamentos();
            depto.ShowDialog();
        }

        private void nuevoProducto_Activated(object sender, EventArgs e)
        {
            obtenerDeptos();
            obtenerProovedor();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!existeproducto())
                {
                    if (tbxCantidad.Text.Length > 0 && tbxCodigoBarras.Text.Length > 0 && tbxCosto.Text.Length > 0 && tbxDescripcion.Text.Length > 0 && tbxPrecio.Text.Length > 0)
                    {
                        conectar = conn.ObtenerConexion();
                   
                      
                        
                        comando = new MySqlCommand("INSERT INTO productos VALUES(null,'" + tbxCodigoBarras.Text + "','" + tbxDescripcion.Text + "','" +
                                tbxCantidad.Text + "','" + tbxCosto.Text + "','" + tbxPrecio.Text + "','" + cbxProveedor.SelectedValue + "','" + cbxDepto.SelectedValue + "')", conectar);
                       
                        conectar.Open();
                        comando.ExecuteNonQuery();
                        conectar.Close();

                        tbxCodigoBarras.Clear();
                        tbxCantidad.Clear();
                        tbxCosto.Clear();
                        tbxPrecio.Clear();
                        tbxDescripcion.Clear();
                        
                        MessageBox.Show("Producto agregado con éxito.");
                    }
                    else
                    {
                        MessageBox.Show("Todos los campos son obligatorios");
                    }
                }
                else
                {
                    MessageBox.Show("El producto que quiere agregar ya existe.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnProv_Click(object sender, EventArgs e)
        {
            AltaProveedores alp = new AltaProveedores();
            alp.ShowDialog();
        }

        private void tbxCosto_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void tbxCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!("\b0123456789.".Contains(e.KeyChar)))
            {
                e.Handled = true;
                if (e.KeyChar == 46 && tbxCosto.Text.IndexOf('.') != -1)
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

        private void tbxPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!("\b0123456789.".Contains(e.KeyChar)))
            {
                e.Handled = true;
                if (e.KeyChar == 46 && tbxPrecio.Text.IndexOf('.') != -1)
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
        public Boolean existeproducto()
        {
            Boolean existe = false;
            try
            {
                int contador = 0;
                conectar = conn.ObtenerConexion();
                comando = new MySqlCommand("select Count(*) from productos where Codigo_barras='" + tbxCodigoBarras.Text + "'", conectar);
                conectar.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    contador = lector.GetInt32(0);
                }
                conectar.Close();
                if (contador > 0)
                {
                    existe = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return existe;
        }
        private void tbxCodigoBarras_Leave(object sender, EventArgs e)
        {
            if (existeproducto())
            {
                MessageBox.Show("El producto que quiere agregar ya existe.");
                tbxCodigoBarras.Focus();
            }
        }

        //public Image ResizeImage(Image image, int width, int height)
        //{
        //    var destRect = new Rectangle(0, 0, width, height);
        //    var destImage = new Bitmap(width, height);

        //    destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

        //    using (var graphics = Graphics.FromImage(destImage))
        //    {
        //        graphics.CompositingMode = CompositingMode.SourceCopy;
        //        graphics.CompositingQuality = CompositingQuality.HighQuality;
        //        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
        //        graphics.SmoothingMode = SmoothingMode.HighQuality;
        //        graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

        //        using (var wrapMode = new ImageAttributes())
        //        {
        //            wrapMode.SetWrapMode(WrapMode.TileFlipXY);
        //            graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
        //        }
        //    }

        //    return destImage;
        //}
    }
}
