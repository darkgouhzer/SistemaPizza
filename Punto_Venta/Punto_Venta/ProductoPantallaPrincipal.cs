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
    public partial class ProductoPantallaPrincipal : Form
    {
        conexion conn = new conexion();
        MySqlConnection conectar;
        MySqlCommand comando;
        String sqlCMD = "";
        MySqlDataReader lector;
        Boolean bImagenNueva = false;
        string idusuario = "";
        string nombre = "";
        byte imagen;
        Int32 dpto = 0;
        Int32 tamaño = 0;

        public ProductoPantallaPrincipal(string iduser)
        {
            InitializeComponent();
            obtenerDeptos();
            sugerirID();
            idusuario = iduser;
            tbxIngredientes.Text = "0";
        }

        Int32 folio = 0;
       
         public void obtenerDeptos()
        {

            List<usuariosLista> lista = new List<usuariosLista>();
            conectar = conn.ObtenerConexion();
            comando = new MySqlCommand("select idTipoPizza, Descripcion from TipoPizza", conectar);
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

         private void picBoxProducto_Click(object sender, EventArgs e)
         {
             nombre = "";

             openImagen.Filter = "(*.BMP;*.JPG;*.GIF;*.PNG)|*.bmp;*.jpg;*.gif;*.png";
             openImagen.Title = "Select a Cursor File";

             if (openImagen.ShowDialog() == System.Windows.Forms.DialogResult.OK)
             {
                 nombre = openImagen.FileName;
                 picBoxProducto.Image = ResizeImage(Image.FromFile(nombre), 125, 125);
                 //nombre = Path.GetFileName(tbxRuta.Text);

             }
         }
         public Image ResizeImage(Image image, int width, int height)
         {
             var destRect = new Rectangle(0, 0, width, height);
             var destImage = new Bitmap(width, height);

             destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

             using (var graphics = Graphics.FromImage(destImage))
             {
                 graphics.CompositingMode = CompositingMode.SourceCopy;
                 graphics.CompositingQuality = CompositingQuality.HighQuality;
                 graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                 graphics.SmoothingMode = SmoothingMode.HighQuality;
                 graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                 using (var wrapMode = new ImageAttributes())
                 {
                     wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                     graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                 }
             }
             bImagenNueva = true;
             return destImage;
         }

         private void btnAceptar_Click(object sender, EventArgs e)
         {
             try
             {
                     if (tbxDescripcion.Text.Length > 0 && tbxPrecio.Text.Length > 0)
                     {
                         conectar = conn.ObtenerConexion();
                         byte[] imgArr = new byte[0]; 
                         if (bImagenNueva)
                         {                                                     
                             MemoryStream ms = new MemoryStream();
                             picBoxProducto.Image.Save(ms, ImageFormat.Jpeg);
                             imgArr = new byte[ms.Length];                        
                             imgArr = ms.ToArray();
                         }
                         

                         if(dpto == 1)
                         {
                             comando = new MySqlCommand("INSERT INTO ProductoPantallaP VALUES (" + tbxID.Text + ",'" + tbxDescripcion.Text + "','" + tbxPrecio.Text + "','" + lbl25.Text + "','" + dpto + "',@imagen," + cbxDepto.SelectedValue + "," + tbxIngredientes.Text + ")", conectar);
                             conectar.Open();
                             comando.Parameters.AddWithValue("@imagen", imgArr);
                             comando.ExecuteNonQuery();
                             conectar.Close();
                             sugerirID();
                             comando = new MySqlCommand("INSERT INTO ProductoPantallaP VALUES ("+tbxID.Text+",'" + tbxDescripcion.Text + "','" + tbxPrecio2.Text + "','" + lbl38.Text + "','" + dpto + "',@imagen,"+cbxDepto.SelectedValue+","+tbxIngredientes.Text+")", conectar);
                             conectar.Open();
                             comando.Parameters.AddWithValue("@imagen", imgArr);                         
                             comando.ExecuteNonQuery();
                             conectar.Close();
                         
                         }
                         else
                         {
                             comando = new MySqlCommand("INSERT INTO ProductoPantallaP VALUES ('" + tbxID.Text + "','" + tbxDescripcion.Text + "','" + tbxPrecio.Text + "',0 ,'" + dpto + "',@imagen,0," + tbxIngredientes.Text + ")", conectar);
                             conectar.Open();
                             comando.Parameters.AddWithValue("@imagen", imgArr);
                             comando.ExecuteNonQuery();
                             conectar.Close();

                         }
                         limpiar();         
                         MessageBox.Show("Producto agregado con éxito.");
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
             sugerirID();
             picBoxProducto.Image = null;
         }

         private void btnPizza_Click(object sender, EventArgs e)
         {
             btnPizza.BackColor = Color.DarkOrange;
             btnEnsalada.BackColor = SystemColors.ControlLight;
             btnEspagueti.BackColor = SystemColors.ControlLight;
             btnIngExtra.BackColor = SystemColors.ControlLight;
                 
             dpto = 1;
             lblTamaño.Visible = true;
             cbxDepto.Visible = true;
             label6.Visible = true;
             lblTamaño.Visible = true;
             lbl25.Visible = true;
             lbl38.Visible = true;
             tbxPrecio2.Visible = true;
             limpiar();
             tbxDescripcion.Visible=true;
             label1.Visible=true;
             label2.Visible=true;
             label5.Visible=true;
             tbxPrecio.Visible = true;
             sugerirID();
             tbxIngredientes.Visible = true;
             label3.Visible = true;


             
         }

         private void btnEnsalada_Click(object sender, EventArgs e)
         {
             btnEnsalada.BackColor = Color.DarkOrange;
             btnPizza.BackColor = SystemColors.ControlLight;
             btnEspagueti.BackColor = SystemColors.ControlLight;
             btnIngExtra.BackColor = SystemColors.ControlLight;
             dpto = 2;
             cbxDepto.SelectedIndex = -1;
             lblTamaño.Visible = false;
             cbxDepto.Visible = false;
             label6.Visible = false;
             lblTamaño.Visible = false;
             lbl25.Visible = false;
             lbl38.Visible = false;
             tbxPrecio2.Visible = false;
             label2.Visible = true;
             label5.Visible = true;
             tbxPrecio.Visible = true;
             tbxDescripcion.Visible = true;
             limpiar();
             tbxIngredientes.Visible = false;
             label3.Visible = false;
         }

         private void btnEspagueti_Click(object sender, EventArgs e)
         {
             btnEspagueti.BackColor = Color.DarkOrange;
             btnPizza.BackColor = SystemColors.ControlLight;
             btnEnsalada.BackColor = SystemColors.ControlLight;
             btnIngExtra.BackColor = SystemColors.ControlLight;

             dpto = 3;
             cbxDepto.SelectedIndex = -1;
             lblTamaño.Visible = false;
             cbxDepto.Visible = false;
             label6.Visible = false;
             lblTamaño.Visible = false;
             lbl25.Visible = false;
             lbl38.Visible = false;
             tbxPrecio2.Visible = false;
             label2.Visible = true;
             label5.Visible = true;
             tbxPrecio.Visible = true;
             tbxDescripcion.Visible = true;
             limpiar();
             tbxIngredientes.Visible = false;
             label3.Visible = false;
         }

         private void btnIngExtra_Click(object sender, EventArgs e)
         {
             btnIngExtra.BackColor = Color.DarkOrange;
             btnPizza.BackColor = SystemColors.ControlLight;
             btnEnsalada.BackColor = SystemColors.ControlLight;
             btnEspagueti.BackColor = SystemColors.ControlLight; 

             dpto = 4;
             cbxDepto.SelectedIndex = -1;
             lblTamaño.Visible = false;
             cbxDepto.Visible = false;
             label6.Visible = false;
             lblTamaño.Visible = false;
             lbl25.Visible = false;
             lbl38.Visible = false;
             tbxPrecio2.Visible = false;
             label2.Visible = true;
             label5.Visible = true;
             tbxPrecio.Visible = true;
             tbxDescripcion.Visible = true;
             limpiar();
             sugerirID();
             tbxIngredientes.Visible = false;
             label3.Visible = false;
            
         }

         public void limpiar()
         {
             tbxDescripcion.Clear();
             tbxIngredientes.Text = "0";
             tbxPrecio.Clear();
             tbxPrecio2.Clear();
             picBoxProducto.Image = null;
         }

         DialogResult result;
         private void btnEliminar_Click(object sender, EventArgs e)
         {
             try
             {
                 if (tbxID.Text != "")
                 {
                     result = MessageBox.Show("¿Esta seguro de querer eliminar el producto selecionado?", "Eliminar producto", MessageBoxButtons.OKCancel);
                     if (result == DialogResult.OK)
                     {
                         conectar = conn.ObtenerConexion();
                         comando = new MySqlCommand("Delete from productopantallap where idproductopantallap='" + tbxID.Text + "'", conectar);
                         conectar.Open();
                         comando.ExecuteNonQuery();
                         conectar.Close();
                         MessageBox.Show("Producto eliminado con éxito.");
                         limpiar();
                         sugerirID();

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

         private void btnModificar_Click(object sender, EventArgs e)
         {
             try
             {
                 if (tbxID.Text.Length > 0 && tbxDescripcion.Text.Length > 0 && tbxPrecio.Text.Length > 0)
                 {
                   
                     byte[] imgArr = new byte[0];
                     string imagen="" , sImagenColumnas="";
                     int existe = 0;
                         //Imagen a guardar
                     if (bImagenNueva)
                     {

                         MemoryStream ms = new MemoryStream();
                         picBoxProducto.Image.Save(ms, ImageFormat.Bmp);
                         imgArr = new byte[ms.Length];
                         imgArr = ms.ToArray();
                         imagen = "Imgen = @imagen,";
                     }
                     else
                     {
                         imagen = "";
                     }

                     sqlCMD = String.Format("SELECT COUNT(idproductopantallap) FROM productopantallap WHERE idproductopantallap = {0};", tbxID.Text);
                     conectar = conn.ObtenerConexion();
                     comando = new MySqlCommand(sqlCMD, conectar);
                     conectar.Open();
                     existe = Convert.ToInt32(comando.ExecuteScalar());
                     conectar.Close();

                     if(existe != 0)
                     {
                         if (tamaño == 25)
                         {
                             sqlCMD = String.Format("UPDATE productopantallap SET Descripcion='{0}',  Precio ='{1}'," +
                             "Tamaño ='{2}', DepartamentosPP_idDepartamentosPP='{3}', " +
                             imagen + " TipoPizza = '{4}', NumeroIngredientes ='{5}' WHERE idproductopantallap='{6}';", tbxDescripcion.Text, tbxPrecio.Text,
                             tamaño, dpto, cbxDepto.SelectedValue, tbxIngredientes.Text, tbxID.Text);
                         }
                         else if (tamaño == 38)
                         {

                             sqlCMD = String.Format("UPDATE productopantallap SET Descripcion='{0}',  Precio ='{1}'," +
                             "Tamaño ='{2}', DepartamentosPP_idDepartamentosPP='{3}', " +
                             imagen + " TipoPizza = '{4}', NumeroIngredientes ='{5}' WHERE idproductopantallap='{6}';", tbxDescripcion.Text, tbxPrecio2.Text,
                             tamaño, dpto, cbxDepto.SelectedValue, tbxIngredientes.Text, tbxID.Text);
                         }
                         else
                         {

                             sqlCMD = String.Format("UPDATE productopantallap SET Descripcion='{0}',  Precio ='{1}'," +
                             "Tamaño ='{2}', DepartamentosPP_idDepartamentosPP='{3}', " +
                              imagen + " TipoPizza = '{4}', NumeroIngredientes ='{5}' WHERE IdProductopantallap='{6}';", tbxDescripcion.Text, tbxPrecio.Text,
                             tamaño, dpto, cbxDepto.SelectedValue, tbxIngredientes.Text, tbxID.Text);
                         }
                     }
                     else
                     {

                         if (bImagenNueva)
                         {
                             sImagenColumnas = "";
                             imagen = "@imagen,";
                         }
                         else
                         {
                             sImagenColumnas = "(idProductoPantallaP,Descripcion,Precio,Tamaño,DepartamentosPP_idDepartamentosPP,TipoPizza,NumeroIngredientes)";
                             imagen = "";
                         }
                         if (dpto == 1)
                         {
                             if(tbxPrecio.Text.Length>0 && tbxPrecio2.Text.Length>0)
                             {
                                 comando = new MySqlCommand("INSERT INTO ProductoPantallaP " + sImagenColumnas + " VALUES (" + tbxID.Text + ",'" +
                                 tbxDescripcion.Text + "','" + tbxPrecio.Text + "','" + lbl25.Text + "','" + dpto +
                                 "'," + imagen + cbxDepto.SelectedValue + "," + tbxIngredientes.Text + ")", conectar);
                                 conectar.Open();
                                 if (bImagenNueva) { comando.Parameters.AddWithValue("@imagen", imgArr); }
                                 comando.ExecuteNonQuery();
                                 conectar.Close();
                                 sugerirID();
                                 comando = new MySqlCommand("INSERT INTO ProductoPantallaP " + sImagenColumnas + " VALUES (" + tbxID.Text + ",'"
                                     + tbxDescripcion.Text + "','" + tbxPrecio2.Text + "','" + lbl38.Text + "','" + dpto +
                                     "'," + imagen + cbxDepto.SelectedValue + "," + tbxIngredientes.Text + ")", conectar);
                                 conectar.Open();
                                 if (bImagenNueva) { comando.Parameters.AddWithValue("@imagen", imgArr); }
                                 comando.ExecuteNonQuery();
                                 conectar.Close();
                             }
                             else
                             {
                                 MessageBox.Show("Los campos precio son obligatorios.");
                             }

                         }
                         else
                         {
                             comando = new MySqlCommand("INSERT INTO ProductoPantallaP VALUES ('" + tbxID.Text + "','" +
                                 tbxDescripcion.Text + "','" + tbxPrecio.Text + "',0 ,'" + dpto + "'," + imagen + ",0," + tbxIngredientes.Text
                                 + ")", conectar);
                             conectar.Open();
                             comando.Parameters.AddWithValue("@imagen", imgArr);
                             comando.ExecuteNonQuery();
                             conectar.Close();

                         }
                     }
                     
                     conectar = conn.ObtenerConexion();
                     comando = new MySqlCommand(sqlCMD, conectar);
                     conectar.Open();
                     if (bImagenNueva) { comando.Parameters.AddWithValue("@imagen", imgArr); }
                     comando.ExecuteNonQuery();
                     conectar.Close();
                     MessageBox.Show("Cambios guardados con éxito.");
                     limpiar();
                     sugerirID();
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

         private void button1_Click(object sender, EventArgs e)
         {
             try
             {
                 if (dpto != 0)
                 {
                     BuscarProductoPP bpp = new BuscarProductoPP(dpto);
                     DialogResult dr = bpp.ShowDialog();
                     if (dr == DialogResult.OK)
                     {
                         tbxID.Text = bpp.regresar.valXn;
                         tbxDescripcion.Visible = true;
                         tbxPrecio.Visible = true;
                         label2.Visible = true;
                         label5.Visible = true;
                         tbxIngredientes.Visible = true;
                         label3.Visible = true;
                     }
                     tbxID_Leave(sender, e);
                 }
                 else
                 {
                     MessageBox.Show("Antes buscar seleccione un tipo de producto.");
                 }
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
         }
         public void sugerirID()
         {
             conectar = conn.ObtenerConexion();
             comando = new MySqlCommand("select MAX(Convert(idproductopantallap,UNSIGNED INTEGER)) from productopantallap", conectar);
             conectar.Open();
             lector = comando.ExecuteReader();
             while (lector.Read())
             {
                 folio = lector.GetInt32(0);
                 if(folio > 0)
                 {
                     folio++;
                     tbxID.Text = Convert.ToString(folio); 
                }
                 else
                 {
                     tbxID.Text = "1";
                 }
             }
             conectar.Close();

         }
        private void tbxID_Leave(object sender, EventArgs e)
        {
            conectar = conn.ObtenerConexion();
            comando = new MySqlCommand("Select * from productopantallap where idproductopantallap='" + tbxID.Text+ "'", conectar);
            conectar.Open();
            lector = comando.ExecuteReader();
            while (lector.Read())
            {

                tbxDescripcion.Text = lector.GetString(1);
                tbxPrecio.Text = lector.GetString(2);
                cbxDepto.TabIndex = lector.GetInt32(6);
                tamaño = lector.GetInt32(3);
                lblTamaño.Visible = false;
                lbl25.Visible = false;
                dpto = lector.GetInt32(4);
                lbl38.Visible = false;
                cbxDepto.Visible = false;
                label6.Visible = false;
                tbxIngredientes.Visible = false;
                label3.Visible = false;
                tbxPrecio2.Visible = false;

                if (cbxDepto.TabIndex > 0)
                {
                    label6.Visible = true;
                    cbxDepto.Visible = true;
                    if (tamaño == 38)
                    {
                        tbxPrecio2.Text = lector.GetString(2);
                        tbxPrecio2.Visible = true;
                        lblTamaño.Visible = true;
                        cbxDepto.SelectedValue = lector.GetInt32(6);
                        lbl25.Visible = false;
                        lbl38.Visible = true;
                        tbxPrecio.Visible = false;
                        tbxIngredientes.Text = lector.GetString(7);
                        tbxIngredientes.Visible = true;
                        label3.Visible = true;
                        
                    }
                    else
                    {
                        tbxPrecio.Text = lector.GetString(2);
                        tbxPrecio.Visible = true;
                        lblTamaño.Visible = true;
                        cbxDepto.SelectedValue = lector.GetInt32(6);
                        lbl25.Visible = true;
                        lbl38.Visible = false;
                        tbxPrecio2.Visible = false;
                        tbxPrecio2.Text = "0";
                        tbxIngredientes.Text = lector.GetString(7);
                        tbxIngredientes.Visible = true;
                        label3.Visible = true;       
                    }
                }
                if (!String.IsNullOrEmpty(lector.GetValue(5).ToString()))
                {
                    byte[] imgArr = (byte[])lector.GetValue(5);
                    using (var stream = new MemoryStream(imgArr))
                    {
                        picBoxProducto.Image = Image.FromStream(stream);

                    }
                    bImagenNueva = false;
                }

            }
            conectar.Close();
        }

        private void ProductoPantallaPrincipal_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode ==Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
