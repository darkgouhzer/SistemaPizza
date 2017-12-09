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
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace Punto_Venta
{
    public partial class modificarProducto : Form
    {
        conexion conn = new conexion();
        MySqlConnection conectar;
        MySqlCommand comando;
        MySqlDataReader lector;

        String sqlCMD = "";
        String CodigBar;
        string idusuario = "";
        string nombre = "";
       Boolean bImagenNueva = false;
        public modificarProducto(String cod, string iduser)
        {
            InitializeComponent();
            CodigBar = cod;
            obtenerDeptos();
            obtenerProovedor();
            RellenarDatos();
            idusuario = iduser;
            tbxDescripcion.MaxLength = 60;
        }
        public void RellenarDatos()
        {
            conectar = conn.ObtenerConexion();
            comando = new MySqlCommand("Select * from productos where Codigo_barras='" + CodigBar + "'", conectar);
            conectar.Open();
            lector = comando.ExecuteReader();
            while (lector.Read())
            {
                tbxCodigoBarras.Text = CodigBar;
                tbxDescripcion.Text = lector.GetString(2);
                tbxCantidad.Text = lector.GetString(3);
                tbxCosto.Text = lector.GetString(4);
                tbxPrecio.Text = lector.GetString(5);
                cbxProveedor.SelectedValue = lector.GetInt32(6);
                cbxDepto.SelectedValue = lector.GetInt32(7);
            }
                //if (!String.IsNullOrEmpty(lector.GetValue(9).ToString()))
                //{
                //    byte[] imgArr = (byte[])lector.GetValue(9);
                //    using (var stream = new MemoryStream(imgArr))
                //    {
                //        picBoxProducto.Image = Image.FromStream(stream);

                //    }
                //    bImagenNueva = false;
                //}
                 
            conectar.Close();
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (tbxCantidad.Text.Length > 0 && tbxCodigoBarras.Text.Length > 0 && tbxCosto.Text.Length > 0 && tbxDescripcion.Text.Length > 0 && tbxPrecio.Text.Length > 0)
                {
                        
                        sqlCMD = String.Format("UPDATE productos SET Descripcion='{0}', Cantidad='{1}', Precio_compra='{2}'," +
                        "Precio_venta='{3}', Proveedores_id='{4}',Departamentos_idDepartamentos='{5}'" +
                        "WHERE Codigo_barras='{6}';", tbxDescripcion.Text, tbxCantidad.Text,
                        tbxCosto.Text, tbxPrecio.Text, cbxProveedor.SelectedValue, cbxDepto.SelectedValue, tbxCodigoBarras.Text);
                    
                    
                    conectar = conn.ObtenerConexion();
                    comando = new MySqlCommand(sqlCMD, conectar);
                    conectar.Open();
                    comando.ExecuteNonQuery();
                    conectar.Close();
                    MessageBox.Show("Cambios guardados con éxito.");
                }
                else
                {
                    MessageBox.Show("Todos los campos son obligatorios");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
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

        //private void picBoxProducto_Click(object sender, EventArgs e)
        //{
        //    nombre = "";

        //    openImagen.Filter = "(*.BMP;*.JPG;*.GIF;*.PNG)|*.bmp;*.jpg;*.gif;*.png";
        //    openImagen.Title = "Select a Cursor File";

        //    if (openImagen.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //    {
        //        nombre = openImagen.FileName;
        //        picBoxProducto.Image = ResizeImage(Image.FromFile(nombre), 125, 125);
        //        //nombre = Path.GetFileName(tbxRuta.Text);

        //    }
        //}

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
        //    bImagenNueva = true;
        //    return destImage;
        //}

    }
}
