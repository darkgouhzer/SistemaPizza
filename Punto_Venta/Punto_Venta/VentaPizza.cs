using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Punto_Venta
{
    public partial class VentaPizza : Form
    {
        conexion conn = new conexion();
        MySqlConnection conectar;
        MySqlCommand comando;
        MySqlDataReader lector;
        string idusuario = "";
        string ModoIngrediente = "";
        int iIngredientesMax = 0;
        int ligueIngExtra = 0;
        int iNumeroMesa = 0;
        int nMitad = 0;
        TableLayoutPanel tlpTipoPizzaUnidadExtra = new TableLayoutPanel();
        Label lblVacio = new Label();
        AgregarPizza objAgregarPizza =  new AgregarPizza();
        List<AgregarPizza> objIzquierdo = new List<AgregarPizza>();
        List<AgregarPizza> objDerecho = new List<AgregarPizza>();
        
        public VentaPizza(string iduser)
        {
            InitializeComponent();
            CargarComponentes();
            idusuario = iduser;
            
        }
        public void CargarIngredientes()
        {
            flpIngredientes.Controls.Clear();
            List<tipoPizzaLista> lista = new List<tipoPizzaLista>();
            conectar = conn.ObtenerConexion();
            comando = new MySqlCommand("SELECT idProductoPantallaP,descripcion,precio FROM " +
                                       "Productopantallap WHERE DepartamentosPP_idDepartamentosPP = 4;", conectar);
            conectar.Open();
            MySqlDataReader lector;
            lector = comando.ExecuteReader();
            while (lector.Read())
            {
                tipoPizzaLista datos = new tipoPizzaLista();
                datos.Codigo = lector.GetInt32(0);
                datos.Descripcion = lector.GetString(1);
                datos.PrecioVenta = lector.GetDouble(2);
                lista.Add(datos);


            }
            conectar.Close();

            Button[] boton = new Button[lista.Count];
            int j = 10, i = 0;
            foreach (tipoPizzaLista dato in lista)
            {

                boton[i] = new Button();
                boton[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                boton[i].Location = new System.Drawing.Point(12, 59 + j);
                boton[i].Name = dato.Codigo.ToString();
                boton[i].Size = new System.Drawing.Size(87, 87);
                boton[i].TabIndex = 0;
                boton[i].Text = dato.Descripcion;
                boton[i].UseVisualStyleBackColor = true;
                boton[i].Visible = true;
                boton[i].Click += new EventHandler(IngredientesBtn_Click);
                this.flpIngredientes.Controls.Add(boton[i]);
                i++;
            }
            
        }
        public void PrecioIngrediente(int codigo)
        {
            conectar = conn.ObtenerConexion();
            comando = new MySqlCommand("SELECT precio FROM " +
                                       "Productopantallap WHERE idProductoPantallaP = " + codigo + ";", 
                                       conectar);
            try
            {

                conectar.Open();
                MySqlDataReader lector;
                lector = comando.ExecuteReader();
                while (lector.Read())
                {                    
                    objAgregarPizza.PrecioIngExtra = lector.GetInt32(0);                    
                }
                conectar.Close();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void IngredientesBtn_Click(Object sender,
                          EventArgs e)
        {
            Button clickedButton = (Button)sender;
           
            if (clickedButton.BackColor != Color.Green)
            {
                
                if (ModoIngrediente == "extra")
                {
                    clickedButton.BackColor = Color.Green;                    
                    objAgregarPizza.IngredienteExtra.Add(clickedButton.Text);
                    PrecioIngrediente(Convert.ToInt32(clickedButton.Name));
                }
                else if (ModoIngrediente == "normal")
                {
                    if (iIngredientesMax < objAgregarPizza.NumeroIngredientes)
                    {
                        iIngredientesMax++;
                        clickedButton.BackColor = Color.Green;
                        objAgregarPizza.Ingredientes.Add(clickedButton.Text);
                    }
                    else
                    {
                        MessageBox.Show("Ha alcanzado número máximo de ingredientes.");
                    }
                }
                
            }
            else
            {
                if (ModoIngrediente == "extra")
                {
                    clickedButton.BackColor = System.Drawing.SystemColors.ControlLight;
                    objAgregarPizza.IngredienteExtra.Remove(clickedButton.Text);
                }
                else if (ModoIngrediente == "normal")
                {
                    clickedButton.BackColor = System.Drawing.SystemColors.ControlLight;
                    objAgregarPizza.Ingredientes.Remove(clickedButton.Text);
                    iIngredientesMax--;
                }
            }
            
        }
        public void CargarTiposPizza(int tamaño)
        {
            flpPizzaCasa.Controls.Clear();
           List<tipoPizzaLista> lista = new List<tipoPizzaLista>();
            conectar = conn.ObtenerConexion();
            comando = new MySqlCommand("select 	idProductoPantallaP,descripcion,precio, Imgen from " +
                                       "productopantallap where DepartamentosPP_idDepartamentosPP = 1 and tipopizza = 1 and "+
                                        " tamaño =" + tamaño + " ;", conectar);
            conectar.Open();
            MySqlDataReader lector;
            lector = comando.ExecuteReader();
            while (lector.Read())
            {
                tipoPizzaLista datos = new tipoPizzaLista();
                datos.Codigo = lector.GetInt32("idProductoPantallaP");
                datos.Descripcion = lector.GetString("descripcion");
                datos.PrecioVenta = lector.GetDouble("precio");

                if(!String.IsNullOrEmpty(lector.GetValue(3).ToString()))
                {
                    byte[] imgArr = (byte[])lector.GetValue(3);
                    using (var stream = new MemoryStream(imgArr))
                    {
                        datos.Imagen = Image.FromStream(stream);
                     }
                }
                
                lista.Add(datos);
                

            }
            conectar.Close();

            Button[] boton = new Button[lista.Count];
            Label[] lblBoton = new Label[lista.Count];
            TableLayoutPanel[] tlpTipoPizzaUnidad = new TableLayoutPanel[lista.Count];
            int j = 10,i = 0;
            foreach(tipoPizzaLista dato in lista)
            {
                
                boton[i] = new Button();
                boton[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                boton[i].Location = new System.Drawing.Point(12, 59 + j);
                boton[i].Name = dato.Codigo.ToString();
                //boton[i].ForeColor = Color.BlueViolet;
                boton[i].Size = new System.Drawing.Size(100, 100);
                boton[i].TabIndex = 0;
                //boton[i].Text = dato.Descripcion;
                boton[i].UseVisualStyleBackColor = true;
                boton[i].Visible = true;
                boton[i].BackgroundImage = dato.Imagen;
                boton[i].BackgroundImageLayout = ImageLayout.Stretch;
                boton[i].TextAlign = System.Drawing.ContentAlignment.BottomCenter;
                boton[i].Click += new EventHandler(TiposPizzaBtn_Click);     

                lblBoton[i] = new Label();
                lblBoton[i].Text = dato.Descripcion;
                lblBoton[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lblBoton[i].Location = new System.Drawing.Point(12, 59 + j);
                lblBoton[i].Visible = true;
                lblBoton[i].TextAlign = ContentAlignment.MiddleCenter;
                lblBoton[i].BackColor = Color.Silver;
                // 
                // tlpTipoPizzaUnidad
                // 
                tlpTipoPizzaUnidad[i] = new TableLayoutPanel();               
                tlpTipoPizzaUnidad[i].ColumnCount = 1;
                tlpTipoPizzaUnidad[i].ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 199F));
                tlpTipoPizzaUnidad[i].Location = new System.Drawing.Point(187, 135);
                tlpTipoPizzaUnidad[i].Name = "tlpTipoPizzaUnidad";
                tlpTipoPizzaUnidad[i].RowCount = 2;
                tlpTipoPizzaUnidad[i].RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
                tlpTipoPizzaUnidad[i].RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
                tlpTipoPizzaUnidad[i].Size = new System.Drawing.Size(110, 125);
                tlpTipoPizzaUnidad[i].TabIndex = 59;                           
                tlpTipoPizzaUnidad[i].Controls.Add(boton[i]);
                tlpTipoPizzaUnidad[i].Controls.Add(lblBoton[i]);
                flpPizzaCasa.Controls.Add(tlpTipoPizzaUnidad[i]);
                i++;
            }

            //btnIngredienteExtra.Location = new System.Drawing.Point(12, 69);
            //btnIngredienteExtra.Size = new System.Drawing.Size(100, 100);

            // tlpTipoPizzaUnidad[i].CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            tlpTipoPizzaUnidadExtra.ColumnCount = 1;
            tlpTipoPizzaUnidadExtra.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 199F));
            tlpTipoPizzaUnidadExtra.Location = new System.Drawing.Point(187, 135);
            tlpTipoPizzaUnidadExtra.Name = "tlpTipoPizzaUnidad";
            tlpTipoPizzaUnidadExtra.RowCount = 2;
            tlpTipoPizzaUnidadExtra.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            tlpTipoPizzaUnidadExtra.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            tlpTipoPizzaUnidadExtra.Size = new System.Drawing.Size(110, 125);
            tlpTipoPizzaUnidadExtra.TabIndex = 59;
            
        }
        public void CargarPizzaTradicional( int tamaño)
        {
            flpPizzaTradicional.Controls.Clear();
            List<tipoPizzaLista> lista = new List<tipoPizzaLista>();
            conectar = conn.ObtenerConexion();
            comando = new MySqlCommand("select 	idProductoPantallaP,descripcion,precio, Imgen from " +
                                       "productopantallap where DepartamentosPP_idDepartamentosPP = 1 and tipopizza = 2 and " +
                                        " tamaño ="+tamaño+" ;", conectar);
            conectar.Open();
            MySqlDataReader lector;
            lector = comando.ExecuteReader();
            while (lector.Read())
            {
                tipoPizzaLista datos = new tipoPizzaLista();
                datos.Codigo = lector.GetInt32("idProductoPantallaP");
                datos.Descripcion = lector.GetString("descripcion");
                datos.PrecioVenta = lector.GetDouble("precio");

                if (!String.IsNullOrEmpty(lector.GetValue(3).ToString()))
                {
                    byte[] imgArr = (byte[])lector.GetValue(3);
                    using (var stream = new MemoryStream(imgArr))
                    {
                        datos.Imagen = Image.FromStream(stream);
                    }
                }

                lista.Add(datos);


            }
            conectar.Close();

            Button[] boton = new Button[lista.Count];
            Label[] lblBoton = new Label[lista.Count];
            TableLayoutPanel[] tlpTipoPizzaUnidad = new TableLayoutPanel[lista.Count];
            int j = 10, i = 0;
            foreach (tipoPizzaLista dato in lista)
            {

                boton[i] = new Button();
                boton[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                boton[i].Location = new System.Drawing.Point(12, 59 + j);
                boton[i].Name = dato.Codigo.ToString();
                //boton[i].ForeColor = Color.BlueViolet;
                boton[i].Size = new System.Drawing.Size(100, 100);
                boton[i].TabIndex = 0;
                //boton[i].Text = dato.Descripcion;
                boton[i].UseVisualStyleBackColor = true;
                boton[i].Visible = true;
                boton[i].BackgroundImage = dato.Imagen;
                boton[i].BackgroundImageLayout = ImageLayout.Stretch;
                boton[i].TextAlign = System.Drawing.ContentAlignment.BottomCenter;
                boton[i].Click += new EventHandler(TiposPizzaBtn_Click);

                lblBoton[i] = new Label();
                lblBoton[i].Text = dato.Descripcion;
                lblBoton[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lblBoton[i].Location = new System.Drawing.Point(12, 59 + j);
                lblBoton[i].Visible = true;
                lblBoton[i].TextAlign = ContentAlignment.MiddleCenter;
                lblBoton[i].BackColor = Color.Silver;
                // 
                // tlpTipoPizzaUnidad
                // 
                tlpTipoPizzaUnidad[i] = new TableLayoutPanel();
                tlpTipoPizzaUnidad[i].ColumnCount = 1;
                tlpTipoPizzaUnidad[i].ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 199F));
                tlpTipoPizzaUnidad[i].Location = new System.Drawing.Point(187, 135);
                tlpTipoPizzaUnidad[i].Name = "tlpTipoPizzaUnidad";
                tlpTipoPizzaUnidad[i].RowCount = 2;
                tlpTipoPizzaUnidad[i].RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
                tlpTipoPizzaUnidad[i].RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
                tlpTipoPizzaUnidad[i].Size = new System.Drawing.Size(110, 125);
                tlpTipoPizzaUnidad[i].TabIndex = 59;
                tlpTipoPizzaUnidad[i].Controls.Add(boton[i]);
                tlpTipoPizzaUnidad[i].Controls.Add(lblBoton[i]);
                flpPizzaTradicional.Controls.Add(tlpTipoPizzaUnidad[i]);
                i++;
            }

            //btnIngredienteExtra.Location = new System.Drawing.Point(12, 69);
            //btnIngredienteExtra.Size = new System.Drawing.Size(100, 100);

            // tlpTipoPizzaUnidad[i].CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            tlpTipoPizzaUnidadExtra.ColumnCount = 1;
            tlpTipoPizzaUnidadExtra.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 199F));
            tlpTipoPizzaUnidadExtra.Location = new System.Drawing.Point(187, 135);
            tlpTipoPizzaUnidadExtra.Name = "tlpTipoPizzaUnidad";
            tlpTipoPizzaUnidadExtra.RowCount = 2;
            tlpTipoPizzaUnidadExtra.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            tlpTipoPizzaUnidadExtra.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            tlpTipoPizzaUnidadExtra.Size = new System.Drawing.Size(110, 125);
            tlpTipoPizzaUnidadExtra.TabIndex = 59;
        }
        public void CargarComponentes()
        {
            btnAgregarPizza.Visible = false;

            lblIngredientes.Visible = false;
            lblIngredientes.Location = new System.Drawing.Point(3, 210);
            flpIngredientes.Visible = false;
            flpIngredientes.Size = new System.Drawing.Size(870, 310);
            flpIngredientes.Location = new System.Drawing.Point(12, 250);
            flpIngredientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
| System.Windows.Forms.AnchorStyles.Left)
| System.Windows.Forms.AnchorStyles.Right)));

            flpPizzaTradicional.Visible = false;
            flpPizzaTradicional.Size = new System.Drawing.Size(870, 310);
            flpPizzaTradicional.Location = new System.Drawing.Point(12, 250);
            flpPizzaTradicional.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));

            lblTiposPizzas.Visible = false;
            //lblTiposPizzas.Location = new System.Drawing.Point(3, 210);
            flpPizzaCasa.Visible = false;
            //flpTipoPizza.Size = new System.Drawing.Size(700, 516);
            flpPizzaCasa.Location = new System.Drawing.Point(12, 250);

            btn35CM.Visible = false;
            btn35CM.Location = new System.Drawing.Point(30, 353);
            btn35CM.Size = new System.Drawing.Size(200, 200);

            btn25CM.Visible = false;
            btn25CM.Location = new System.Drawing.Point(325, 353);
            btn25CM.Size = new System.Drawing.Size(200, 200);

            int x = 170;
            btnMasaNormal.Visible = false;
            btnMasaNormal.Location = new System.Drawing.Point(-85, 353);
            btnMasaNormal.Size = new System.Drawing.Size(200, 200);

            btnMasaIntegral.Visible = false;
            btnMasaIntegral.Location = new System.Drawing.Point(175, 353);
            btnMasaIntegral.Size = new System.Drawing.Size(200, 200);

            btnMasaGluten.Visible = false;
            btnMasaGluten.Location = new System.Drawing.Point(430, 353);
            btnMasaGluten.Size = new System.Drawing.Size(200, 200);
            
            btnPizzaCasa.Visible = false;
            btnPizzaCasa.Location = new System.Drawing.Point(-85, 353);
            btnPizzaCasa.Size = new System.Drawing.Size(200, 200);

            btnTradicional.Visible = false;
            btnTradicional.Location = new System.Drawing.Point(175, 353);
            btnTradicional.Size = new System.Drawing.Size(200, 200);

            btnArmaTuPizza.Visible = false;
            btnArmaTuPizza.Location = new System.Drawing.Point(430, 353);
            btnArmaTuPizza.Size = new System.Drawing.Size(200, 200);

            btnDerecho.Visible = false;
            btnIzquierdo.Visible = false;
            btnRegresar.Visible = false;
            tbxSeguimiento.Visible = false;

            lblCalleTexto.Text = "";
            lblColoniaTexto.Text = "";
            lblNombreTexto.Text = "";
            lblNumeroExtTexto.Text = "";
            lblTelefonoTexto.Text = "";

        }
        public void TiposPizzaBtn_Click(Object sender,
                  EventArgs e)
        {
            // When the button is clicked,
            // change the button text, and disable it.
            objAgregarPizza.IngredienteExtra = new List<string>();
            Button clickedButton = (Button)sender;
            picBoxSeleccion.Image = clickedButton.BackgroundImage;
            panelSeleccion.Visible = true;
            ObtenerDatosPizza(Convert.ToInt32(clickedButton.Name));
        }
        public void ObtenerDatosPizza(int iCodigo)
        {
            conectar = conn.ObtenerConexion();
            comando = new MySqlCommand("select 	idProductoPantallaP, descripcion,precio, NumeroIngredientes from " +
                                       "productopantallap where idProductoPantallaP="+iCodigo+" ;", conectar);
            conectar.Open();
            MySqlDataReader lector;
            lector = comando.ExecuteReader();
            while (lector.Read())
            {
                tipoPizzaLista datos = new tipoPizzaLista();
                objAgregarPizza.Codigo = lector.GetInt32("idProductoPantallaP");
                objAgregarPizza.NombrePizza = lector.GetString("descripcion");
                objAgregarPizza.PrecioPizza= lector.GetDouble("precio");
                objAgregarPizza.NumeroIngredientes = lector.GetInt32("NumeroIngredientes");
                lblNombreSeleccion.Text = objAgregarPizza.NombrePizza;
            }
            conectar.Close();
            if(objAgregarPizza.NumeroIngredientes>0)
            {
                btnIngredientes.Visible = true;
                btnIngredienteExtra.Visible = false;
            }
            else
            {
                btnIngredienteExtra.Visible = true;
                btnIngredientes.Visible = false;
            }

        }
        public class myButtonObject : UserControl
        {
            // Draw the new button.
            protected override void OnPaint(PaintEventArgs e)
            {
                Graphics graphics = e.Graphics;
                Pen myPen = new Pen(Color.Black);
                // Draw the button in the form of a circle
                graphics.DrawEllipse(myPen, 0, 0, 100, 100);
                myPen.Dispose();
            }
        }
        // Handler for the click message.
        void myButton_Click(Object sender, System.EventArgs e)
        {
            MessageBox.Show("Click");
        }

        private void VentaPizza_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Close();
            }            
        }

        private void btnEspagueti_Click(object sender, EventArgs e)
        {
            Espagueti esp = new Espagueti("3");
            esp.ShowDialog();
            if (esp.objListDatosProductos.Count > 0)
            {
                foreach (DatosProductos objDatosProductos in esp.objListDatosProductos)
                {
                    ligueIngExtra++;
                    dtgTicket.Rows.Add(objDatosProductos.sCodigo, objDatosProductos.iCantidad, objDatosProductos.sDescripcion, objDatosProductos.dPrecio, objDatosProductos.dPrecio * objDatosProductos.iCantidad, "", ligueIngExtra, iNumeroMesa);
                }
            }            
        }
       
        private void btnPizza_Click(object sender, EventArgs e)
        {
            panelSeleccion.Visible = false;
            flpPizzaTradicional.Visible = false;
            btnArmaTuPizza.Visible = false;
            btnPizzaCasa.Visible = false;
            btnTradicional.Visible = false;
            btnMasaGluten.Visible = false;
            btnMasaIntegral.Visible = false;
            btnMasaNormal.Visible = false;
            btn35CM.Visible = true;
            btn25CM.Visible = true;
            lblTiposPizzas.Visible = false;
            flpPizzaCasa.Visible = false;
            flpIngredientes.Visible = false;
            btnAgregarPizza.Visible = false;
            btnIngredientes.Visible = false;
            btnIngredienteExtra.Visible = false;
            objAgregarPizza = new AgregarPizza();
            objAgregarPizza.Ingredientes = new List<string>();
            objAgregarPizza.IngredienteExtra = new List<string>();
            CargarIngredientes();
            iIngredientesMax = 0;
            nMitad = 0;
            btnIzquierdo.Enabled = true;
            btnDerecho.Enabled = true;
           
        }

        private void btn35CM_Click(object sender, EventArgs e)
        {
            btn35CM.Visible = false;
            btn25CM.Visible = false;
            btnArmaTuPizza.Visible = false;
            btnPizzaCasa.Visible = false;
            btnTradicional.Visible = false;
            btnMasaGluten.Visible = true;
            btnMasaIntegral.Visible = true;
            btnMasaNormal.Visible = true;
            lblTiposPizzas.Visible = false;
            flpPizzaCasa.Visible = false;
            flpIngredientes.Visible = false;
            objAgregarPizza.Tamaño = 38;
            CargarTiposPizza(38);
            CargarPizzaTradicional(38);
        }

        private void btn25CM_Click(object sender, EventArgs e)
        {
            btn35CM.Visible = false;
            btn25CM.Visible = false;
            btnArmaTuPizza.Visible = false;
            btnPizzaCasa.Visible = false;
            btnTradicional.Visible = false;
            btnMasaGluten.Visible = true;
            btnMasaIntegral.Visible = true;
            btnMasaNormal.Visible = true;
            lblTiposPizzas.Visible = false;
            flpPizzaCasa.Visible = false;
            flpIngredientes.Visible = false;
            objAgregarPizza.Tamaño = 25;
            CargarTiposPizza(25);
            CargarPizzaTradicional(25);
        }
        private void btnMasaNormal_Click(object sender, EventArgs e)
        {
            btnArmaTuPizza.Visible = true;
            btnPizzaCasa.Visible = true;
            btnTradicional.Visible = true;
            btnMasaGluten.Visible = false;
            btnMasaIntegral.Visible = false;
            btnMasaNormal.Visible = false;
            btn35CM.Visible = false;
            btn25CM.Visible = false;
            objAgregarPizza.TipoMasa = "normal";
        }

        private void btnMasaIntegral_Click(object sender, EventArgs e)
        {
            btnArmaTuPizza.Visible = true;
            btnPizzaCasa.Visible = true;
            btnTradicional.Visible = true;
            btnMasaGluten.Visible = false;
            btnMasaIntegral.Visible = false;
            btnMasaNormal.Visible = false;
            btn35CM.Visible = false;
            btn25CM.Visible = false;
            objAgregarPizza.TipoMasa = "integral";
        }

        private void btnMasaGluten_Click(object sender, EventArgs e)
        {
            btnArmaTuPizza.Visible = true;
            btnPizzaCasa.Visible = true;            
            btnTradicional.Visible = true;
            btnMasaGluten.Visible = false;
            btnMasaIntegral.Visible = false;
            btnMasaNormal.Visible = false;
            btn35CM.Visible = false;
            btn25CM.Visible = false;
            objAgregarPizza.TipoMasa = "sin gluten";
        }
        private void btnArmaTuPizza_Click(object sender, EventArgs e)
        {
            btnArmaTuPizza.Visible = false;
            btnPizzaCasa.Visible = false;
            btnTradicional.Visible = false;
            btnMasaGluten.Visible = false;
            btnMasaIntegral.Visible = false;
            btnMasaNormal.Visible = false;
            lblTiposPizzas.Visible = true;
            lblTiposPizzas.Text = "ARMA TU PIZZA";
            flpIngredientes.Visible = true;
            btnDerecho.Visible = true;
            btnIzquierdo.Visible = true;
            btnRegresar.Visible = true;
            tbxSeguimiento.Visible = true;
            if (objDerecho.Count == 0 && objIzquierdo.Count == 0)
            btnAgregarPizza.Visible = true;
            ModoIngrediente = "normal";
            CargarDatosArmaPizza();
        }

        public void CargarDatosArmaPizza()
        {
            conectar = conn.ObtenerConexion();
            comando = new MySqlCommand("select 	idProductoPantallaP, descripcion,precio, NumeroIngredientes from " +
                                       "productopantallap where tipopizza=3 and tamaño = "+objAgregarPizza.Tamaño+" ;", conectar);
            conectar.Open();
            MySqlDataReader lector;
            lector = comando.ExecuteReader();
            while (lector.Read())
            {
                tipoPizzaLista datos = new tipoPizzaLista();
                objAgregarPizza.Codigo = lector.GetInt32("idProductoPantallaP");
                objAgregarPizza.NombrePizza = lector.GetString("descripcion");
                objAgregarPizza.PrecioPizza = lector.GetDouble("precio");
                objAgregarPizza.NumeroIngredientes = lector.GetInt32("NumeroIngredientes");
                lblNombreSeleccion.Text = objAgregarPizza.NombrePizza;
            }
            conectar.Close();
            btnIngredienteExtra.Visible = true;
            btnIngredientes.Visible = false;            
        }
        private void btnTradicional_Click(object sender, EventArgs e)
        {
            btnArmaTuPizza.Visible = false;
            btnPizzaCasa.Visible = false;
            btnTradicional.Visible = false;
            lblTiposPizzas.Visible = true;
            lblTiposPizzas.Text = "PIZZA TRADICIONAL";
            flpPizzaTradicional.Visible = true;
            btnDerecho.Visible = true;
            btnIzquierdo.Visible = true;
            btnRegresar.Visible = true;
            tbxSeguimiento.Visible = true;

            if(objDerecho.Count==0 &&objIzquierdo.Count==0)
            btnAgregarPizza.Visible = true;
        }
        private void btnPizzaCasa_Click(object sender, EventArgs e)
        {
            btnArmaTuPizza.Visible = false;
            btnPizzaCasa.Visible = false;
            btnTradicional.Visible = false;
            btnMasaGluten.Visible = false;
            btnMasaIntegral.Visible = false;
            btnMasaNormal.Visible = false;
            lblTiposPizzas.Visible = true;
            lblTiposPizzas.Text = "PIZZA DE LA CASA";            
            flpPizzaCasa.Visible = true;
            btnDerecho.Visible = true;
            btnIzquierdo.Visible = true;
            btnRegresar.Visible = true;
            tbxSeguimiento.Visible = true;
            if (objDerecho.Count == 0 && objIzquierdo.Count == 0)
            btnAgregarPizza.Visible = true;           
        }

        private void btnEnsalada_Click(object sender, EventArgs e)
        {
            Espagueti esp = new Espagueti("2");
            esp.ShowDialog();
            if (esp.objListDatosProductos.Count > 0)
            {
                foreach (DatosProductos objDatosProductos in esp.objListDatosProductos)
                {
                    ligueIngExtra++;
                    dtgTicket.Rows.Add(objDatosProductos.sCodigo, objDatosProductos.iCantidad, objDatosProductos.sDescripcion, objDatosProductos.dPrecio, objDatosProductos.dPrecio * objDatosProductos.iCantidad, "", ligueIngExtra, iNumeroMesa);
                }
            }  
        }

        private void btnBebidas_Click(object sender, EventArgs e)
        {
            Bebidas objBebidas = new Bebidas();
            objBebidas.ShowDialog();
            
            if (objBebidas.objListDatosProductos.Count > 0)
            {
                foreach (DatosProductos objDatosProductos in objBebidas.objListDatosProductos)
                {
                    ligueIngExtra++;
                    dtgTicket.Rows.Add(objDatosProductos.sCodigo, objDatosProductos.iCantidad, objDatosProductos.sDescripcion, objDatosProductos.dPrecio, objDatosProductos.dPrecio * objDatosProductos.iCantidad, "P", ligueIngExtra, iNumeroMesa);
                }
            }
        }
        
        private void dtgTicket_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            obtenerTotales();
        }
        public void obtenerTotales()
        {
            try
            {
                Double dTotal = 0;
                if (dtgTicket.Rows.Count > 0)
                {
                    for (int i = 0; i < dtgTicket.Rows.Count; i++)
                    {
                        dTotal += Convert.ToDouble(dtgTicket[4, i].Value);
                        lblTotal.Text = "$ " + dTotal.ToString();
                        lblTotal.Tag = dTotal.ToString();
                    }
                }
                else
                {
                    lblTotal.Text = "$ 0.0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnAgregarPizza_Click(object sender, EventArgs e)
        {
            btnArmaTuPizza.Visible = false;
            btnPizzaCasa.Visible = false;
            btnTradicional.Visible = false;
            btnMasaGluten.Visible = false;
            btnMasaIntegral.Visible = false;
            btnMasaNormal.Visible = false;
            btn35CM.Visible = false;
            btn25CM.Visible = false;
            lblTiposPizzas.Visible = false;
            flpPizzaCasa.Visible = false;
            flpIngredientes.Visible = false;            
            btnAgregarPizza.Visible = false;
            btnIngredientes.Visible = false;
            btnIngredienteExtra.Visible = false;
            panelSeleccion.Visible = false;
            btnDerecho.Visible = false;
            btnIzquierdo.Visible = false;
            btnRegresar.Visible = false;
            tbxSeguimiento.Visible = false;
            tbxSeguimiento.Clear();

            String Ingrediente = "";
            ligueIngExtra++;
            if (objDerecho.Count == 0 && objIzquierdo.Count == 0)
            {
                if (objAgregarPizza.Ingredientes.Count > 0)
                {
                    foreach (String Nombre in objAgregarPizza.Ingredientes)
                    {
                        Ingrediente += Nombre + " ";
                    }
                }
                dtgTicket.Rows.Add(objAgregarPizza.Codigo, 1, objAgregarPizza.NombrePizza + " " + objAgregarPizza.Tamaño + " cm " + objAgregarPizza.TipoMasa + " " + Ingrediente, objAgregarPizza.PrecioPizza, objAgregarPizza.PrecioPizza, "", ligueIngExtra, iNumeroMesa);

                if (objAgregarPizza.IngredienteExtra.Count > 0)
                {
                    String Ingredientes = "Extra ";
                    foreach (String Nombre in objAgregarPizza.IngredienteExtra)
                    {
                        Ingredientes += Nombre + " ";
                    }
                    int fila = 0;
                    fila = dtgTicket.Rows.Add(0, objAgregarPizza.IngredienteExtra.Count, Ingredientes, objAgregarPizza.PrecioIngExtra,
                         objAgregarPizza.PrecioIngExtra * objAgregarPizza.IngredienteExtra.Count, "", ligueIngExtra, iNumeroMesa);
                    dtgTicket[1, fila].ReadOnly = true;
                }
            }
            else
            {
                String sIngredienteIzq , sIngredienteDer;
                sIngredienteIzq = "IZQUIERDA:" + objIzquierdo[0].NombrePizza + " " + objIzquierdo[0].Tamaño + " cm " 
                    + objIzquierdo[0].TipoMasa + " ";
                sIngredienteDer = " | DERECHA:" + objDerecho[0].NombrePizza + " " + objDerecho[0].Tamaño + " cm " 
                    + objDerecho[0].TipoMasa + " "; 
                if (objIzquierdo[0].Ingredientes.Count > 0)
                {
                    foreach (String Nombre in objIzquierdo[0].Ingredientes)
                    {
                        sIngredienteIzq += Nombre + " ";
                    }
                }

                if (objDerecho[0].Ingredientes.Count > 0)
                {
                    foreach (String Nombre in objDerecho[0].Ingredientes)
                    {
                        sIngredienteDer += Nombre + " ";
                    }
                }

                Ingrediente = sIngredienteIzq + sIngredienteDer;

                if(objIzquierdo[0].PrecioPizza > objDerecho[0].PrecioPizza)
                {
                    dtgTicket.Rows.Add(objIzquierdo[0].Codigo, 1, Ingrediente, objIzquierdo[0].PrecioPizza, objIzquierdo[0].PrecioPizza, "", ligueIngExtra, iNumeroMesa);
                }
                else
                {
                    dtgTicket.Rows.Add(objDerecho[0].Codigo, 1, Ingrediente, objDerecho[0].PrecioPizza, objDerecho[0].PrecioPizza, "", ligueIngExtra, iNumeroMesa);
                }
                
                if (objIzquierdo[0].IngredienteExtra.Count > 0)
                {
                    sIngredienteIzq = "Extra IZQ ";
                    foreach (String Nombre in objIzquierdo[0].IngredienteExtra)
                    {
                        sIngredienteIzq += Nombre + " ";
                    }
                    //int fila = 0;
                    //fila = dtgTicket.Rows.Add(0, objAgregarPizza.IngredienteExtra.Count, Ingredientes, objAgregarPizza.PrecioIngExtra,
                    //     objAgregarPizza.PrecioIngExtra * objAgregarPizza.IngredienteExtra.Count, "", ligueIngExtra, iNumeroMesa);
                    //dtgTicket[1, fila].ReadOnly = true;
                }
               
                if (objDerecho[0].IngredienteExtra.Count > 0)
                {
                    sIngredienteDer = "Extra DER "; 
                    foreach (String Nombre in objDerecho[0].IngredienteExtra)
                    {
                        sIngredienteDer += Nombre + " ";
                    }
                  
                }
                Ingrediente = sIngredienteIzq + sIngredienteDer;
                if(Ingrediente.Length>0)
                {
                    int fila = 0;
                    fila = dtgTicket.Rows.Add(0, objIzquierdo[0].IngredienteExtra.Count+objDerecho[0].IngredienteExtra.Count,
                        Ingrediente, objDerecho[0].PrecioIngExtra,
                         objDerecho[0].PrecioIngExtra * (objIzquierdo[0].IngredienteExtra.Count+objDerecho[0].IngredienteExtra.Count),
                         "", ligueIngExtra, iNumeroMesa);
                    dtgTicket[1, fila].ReadOnly = true;
                }

            }
            objIzquierdo = new List<AgregarPizza>();
            objDerecho = new List<AgregarPizza>();
            objAgregarPizza = new AgregarPizza();
        }

        private void btnIngredienteExtra_Click(object sender, EventArgs e)
        {
            
            //objAgregarPizza.IngredienteExtra = new List<string>(); 
            if(iIngredientesMax == objAgregarPizza.NumeroIngredientes)
            {
                CargarIngredientes();
                flpIngredientes.Visible = true;
                flpPizzaCasa.Visible = false;
                flpPizzaTradicional.Visible = false;
                ModoIngrediente = "extra";
                objAgregarPizza.IngredienteExtra = new List<string>();
            }
            else
            {
                MessageBox.Show("Aun quedan pendientes " + 
                    (objAgregarPizza.NumeroIngredientes - iIngredientesMax) + " ingredientes");
            }            
        }

        private void btnIngredientes_Click(object sender, EventArgs e)
        {
            btnIngredienteExtra.Visible = true;
            btnIngredientes.Visible = false;
            flpIngredientes.Visible = true;
            flpPizzaCasa.Visible = false;
            flpPizzaTradicional.Visible = false;
            ModoIngrediente = "normal";

        }

        double pagoEfectivo = 0, pagoTarjeta = 0, totalpagoefectivo = 0;
        int ticket = 0;
        public void realizarVenta()
        {
            conectar = conn.ObtenerConexion();
            MySqlTransaction trans;
            conectar.Open();
            trans = conectar.BeginTransaction();
            try
            {
                if (dtgTicket.Rows.Count > 0)
                {
                    totalpagoefectivo = Convert.ToDouble(lblTotal.Tag) - pagoTarjeta;
                    comando = new MySqlCommand("insert into generarticket values(null)", conectar);
                    comando.ExecuteNonQuery();

                    comando = new MySqlCommand("select Max(id) from generarticket", conectar);
                    ticket = (int)comando.ExecuteScalar();
                    comando = new MySqlCommand("INSERT INTO venta (No_ticket, status, Efectivo, Tarjeta, Total, fecha_venta) " +
                           " values(" + ticket + ",'1','" + totalpagoefectivo + "'," + pagoTarjeta +
                           ", " + (totalpagoefectivo + pagoTarjeta) + ", now())", conectar);                    
                    comando.ExecuteNonQuery();
                    for (int i = 0; i < dtgTicket.Rows.Count; i++)
                    {
                        if (dtgTicket[5, i].Value.ToString() != "P")
                        {
                            comando = new MySqlCommand("INSERT INTO ventadetalle (No_ticket, Descripcion, Cantidad, Precio, Total,CodigoProductosP) " +
                                " values(" + ticket + ",'" + dtgTicket[2, i].Value.ToString() +
                                "','" + Convert.ToDouble(dtgTicket[1, i].Value) + "'," + Convert.ToDouble(dtgTicket[3, i].Value) +
                                ", " + Convert.ToDouble(dtgTicket[4, i].Value) + "," + Convert.ToDouble(dtgTicket[0, i].Value) + ")", conectar);

                            comando.ExecuteNonQuery();

                        }
                        else
                        {
                            comando = new MySqlCommand("INSERT INTO ventadetalle (No_ticket, Descripcion, Cantidad, Precio, Total,CodigoProductos) " +
                                " values(" + ticket + ",'" + dtgTicket[2, i].Value.ToString() +
                                "','" + Convert.ToDouble(dtgTicket[1, i].Value) + "'," + Convert.ToDouble(dtgTicket[3, i].Value) +
                                ", " + Convert.ToDouble(dtgTicket[4, i].Value) + "," + Convert.ToDouble(dtgTicket[0, i].Value) + ")", conectar);

                            comando.ExecuteNonQuery();
                        }
                        if(dtgTicket[5,i].Value.ToString()=="P")
                        {
                            comando = new MySqlCommand("update productos set cantidad=cantidad-" + Convert.ToDouble(dtgTicket[1, i].Value) + " where id='" + dtgTicket[0, i].Value.ToString() + "'", conectar);
                            comando.ExecuteNonQuery();
                        }   
                                             
                        btnPizza.Visible = false;
                        btnEnsalada.Visible = false;
                        btnEspagueti.Visible = false;
                        btnBebidas.Visible = false;
                        label3.Visible = false;
                        label4.Visible = false;
                        label5.Visible = false;
                        label6.Visible = false;
                        lblComedor.Visible = false;                      
                        
                    }
                    trans.Commit();
                    conectar.Close();
                  
                }
                else
                {
                    MessageBox.Show("No puede registrar venta sin artículos seleccionados.");
                }

            }
            catch (Exception ex)
            {
                trans.Rollback();
                conectar.Close();
                
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Corte_de_Caja crt = new Corte_de_Caja(idusuario);
            crt.ShowDialog();
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            pagoEfectivo = 0;
            Cobrar cbr = new Cobrar(lblTotal.Text);
            DialogResult dr = cbr.ShowDialog();
            if (dr == DialogResult.OK)
            {
                pagoEfectivo = Convert.ToDouble(cbr.regresar.valXn);
                pagoTarjeta = Convert.ToDouble(cbr.regresar.valXnT);
                realizarVenta();
                printDocument1.Print();
                dtgTicket.Rows.Clear();
                iNumeroMesa = 0;
            }
        }
     
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font letraTi = new Font("Arial", 11, FontStyle.Bold);
            Font letra = new Font("Arial", 8);
            Image imagennueva = (Image)global::Punto_Venta.Properties.Resources.Imagen_logo_ConvertImage;
            
            Rectangle destRect1 = new Rectangle(40, 2, 200, 80);
            GraphicsUnit units = GraphicsUnit.Pixel;
            e.Graphics.DrawImage(imagennueva, destRect1, 0, 0, imagennueva.Width, imagennueva.Height, units);

            //e.Graphics.DrawString("                 VIA ROMA PIZZA", letraTi, Brushes.Black, new Rectangle(2, 2, 350, 80));
            e.Graphics.DrawString("                 Los Mochis, Sinaloa", letraTi, Brushes.Black, new Rectangle(2, 80, 350, 80));
            e.Graphics.DrawString("                 Tel- 688-59-59", letraTi, Brushes.Black, new Rectangle(2, 94, 350, 80));
            //e.Graphics.DrawString("RFC- MAZD 460503 8L9", letra, Brushes.Black, new Rectangle(2, 38, 200, 50));
            e.Graphics.DrawString("                 Ticket # " + ticket, letraTi, Brushes.Black, new Rectangle(2, 108, 350, 80));
            e.Graphics.DrawString(DateTime.Now.ToString("                 dd/MM/yyyy HH:mm:ss tt"), letraTi, Brushes.Black, new Rectangle(2, 122, 350, 80));
            e.Graphics.DrawString("============================", letraTi, Brushes.Black, new Rectangle(2, 136, 350, 80));
            e.Graphics.DrawString("CANT   DESCRIPCIÓN                    PRECIO U.      TOTAL", new Font("Arial", 7, FontStyle.Bold), Brushes.Black, new Rectangle(2, 150, 350, 80));
            e.Graphics.DrawString("============================", letraTi, Brushes.Black, new Rectangle(2, 164, 350, 80));
            int y =188;
            int yf = 20;
            for (int i = 0; i < dtgTicket.Rows.Count; i++)
            {
                if (dtgTicket.Rows[i].Cells[2].FormattedValue.ToString().Length>20)
                {
                    yf = dtgTicket.Rows[i].Cells[2].FormattedValue.ToString().Length / 15 * 13;
                }
                else
                {
                    yf = 20;
                }
                e.Graphics.DrawString(dtgTicket.Rows[i].Cells[1].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(2, y, 28, yf));
                e.Graphics.DrawString(dtgTicket.Rows[i].Cells[2].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(30, y, 125, yf));
                e.Graphics.DrawString(dtgTicket.Rows[i].Cells[3].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(160, y, 160, yf));
                e.Graphics.DrawString(dtgTicket.Rows[i].Cells[4].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(220, y, 220, yf));
                y += yf;
            }


            e.Graphics.DrawString("============================", letraTi, Brushes.Black, new Rectangle(2, y, 270, 80));

            y += 12;
            e.Graphics.DrawString("           TOTAL:", letra, Brushes.Black, new Rectangle(130, y, 100, 80));
            e.Graphics.DrawString(lblTotal.Text, letra, Brushes.Black, new Rectangle(220, y, 200, 80));
            
            y += 12;
            e.Graphics.DrawString("           TARJETA:", letra, Brushes.Black, new Rectangle(130, y, 100, 80));
            e.Graphics.DrawString(pagoTarjeta.ToString("C"), letra, Brushes.Black, new Rectangle(220, y, 200, 80));

            y += 12;
            e.Graphics.DrawString("           EFECTIVO:", letra, Brushes.Black, new Rectangle(130, y, 100, 80));
            e.Graphics.DrawString(pagoEfectivo.ToString("C"), letra, Brushes.Black, new Rectangle(220, y, 200, 80));

            y += 12;
            double cambio = pagoEfectivo - Convert.ToDouble(lblTotal.Text.Substring(1)) + pagoTarjeta;
            e.Graphics.DrawString("           CAMBIO:", letra, Brushes.Black, new Rectangle(130, y, 100, 15));
            e.Graphics.DrawString(cambio.ToString("C"), letra, Brushes.Black, new Rectangle(220, y, 200, 80));

            y += 30;

            e.Graphics.DrawString("LO ESPERAMOS PRONTO", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(65, y, 270, 80));

            y += 12;

            e.Graphics.DrawString("GRACIAS POR SU COMPRA", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Rectangle(65, y, 270, 80));
            
            if (lblTelefonoTexto.Text.Length > 0)
            {
                y += 20;

                e.Graphics.DrawString("DOMICILIO CLIENTE: ", new Font("Arial", 9, FontStyle.Bold), Brushes.Black, new Rectangle(2, y, 270, 80));
                y += 12;
                e.Graphics.DrawString("Nombre: " + lblNombreTexto.Text, new Font("Arial", 9, FontStyle.Bold), Brushes.Black, new Rectangle(2, y, 270, 80));

                y += 12;

                e.Graphics.DrawString("Telefono: " + lblTelefonoTexto.Text, new Font("Arial", 9, FontStyle.Bold), Brushes.Black, new Rectangle(2, y, 270, 80));

                y += 12;

                e.Graphics.DrawString("Calle: " + lblCalleTexto.Text, new Font("Arial", 9, FontStyle.Bold), Brushes.Black, new Rectangle(2, y, 270, 80));

                y += 12;

                e.Graphics.DrawString("Colonia: " + lblColoniaTexto.Text, new Font("Arial", 9, FontStyle.Bold), Brushes.Black, new Rectangle(2, y, 270, 80));

                y += 12;

                e.Graphics.DrawString("Número: " + lblNumeroExtTexto.Text, new Font("Arial", 9, FontStyle.Bold), Brushes.Black, new Rectangle(2, y, 270, 80));
            
            }
        }

        private void btnGrabarPreventa_Click(object sender, EventArgs e)
        {
            List<DatosProductos> lsDatosProductos = new List<DatosProductos>();
            DatosProductos objDatosProductos;
            for (int i = 0; i < dtgTicket.Rows.Count; i++)
            {
                objDatosProductos = new DatosProductos();
                objDatosProductos.sCodigo = dtgTicket[0, i].Value.ToString();
                objDatosProductos.iCantidad = Convert.ToInt32(dtgTicket[1, i].Value);
                objDatosProductos.sDescripcion = dtgTicket[2, i].Value.ToString();
                objDatosProductos.dPrecio = Convert.ToDouble(dtgTicket[3, i].Value);
                objDatosProductos.dTotal = Convert.ToDouble(dtgTicket[4, i].Value);
                objDatosProductos.sCodigoP = dtgTicket[5, i].Value.ToString();
                objDatosProductos.sLigueIngExtra = dtgTicket[6, i].Value.ToString();
                objDatosProductos.iNumeroMesa = iNumeroMesa;
                lsDatosProductos.Add(objDatosProductos);                
            }

            btnConsultarVenta objGuardarPreventa = new btnConsultarVenta(lsDatosProductos, iNumeroMesa);
            objGuardarPreventa.ShowDialog();
            iNumeroMesa = objGuardarPreventa.iNumeroMesa;
            string sAuxLigue = "";
            if (objGuardarPreventa.lsDatosProductos.Count > 0)
            {
                iNumeroMesa = objGuardarPreventa.lsDatosProductos[0].iNumeroMesa;
                dtgTicket.Rows.Clear();
                foreach (DatosProductos datos in objGuardarPreventa.lsDatosProductos)
                {
                    int fila = 0;
                    fila = dtgTicket.Rows.Add(datos.sCodigo, datos.iCantidad, datos.sDescripcion, datos.dPrecio, datos.dTotal,
                        datos.sCodigoP, datos.sLigueIngExtra, datos.iNumeroMesa);
                    if (sAuxLigue == datos.sLigueIngExtra)
                    {
                        dtgTicket[1, fila].ReadOnly = true;
                    }
                    sAuxLigue = datos.sLigueIngExtra;
                }
            }
            if (objGuardarPreventa.bImprimir)
            { 
                printDocument2.Print();
            }
        }

        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font letraTi = new Font("Arial", 11, FontStyle.Bold);
            Font letra = new Font("Arial", 8);
            Image imagennueva = (Image)global::Punto_Venta.Properties.Resources.Imagen_logo_ConvertImage;
            Rectangle destRect1 = new Rectangle(40, 0, 200, 80);
            GraphicsUnit units = GraphicsUnit.Pixel;
            e.Graphics.DrawImage(imagennueva, destRect1, 1, 1, imagennueva.Width, imagennueva.Height, units);

            //e.Graphics.DrawString("                 VIA ROMA PIZZA", letraTi, Brushes.Black, new Rectangle(2, 2, 350, 80));
            e.Graphics.DrawString("                 Los Mochis, Sinaloa", letraTi, Brushes.Black, new Rectangle(2, 80, 350, 80));
            e.Graphics.DrawString("                 Tel- 688-59-59", letraTi, Brushes.Black, new Rectangle(2, 94, 350, 80));
            //e.Graphics.DrawString("RFC- MAZD 460503 8L9", letra, Brushes.Black, new Rectangle(2, 38, 200, 50));
            e.Graphics.DrawString(DateTime.Now.ToString("                 dd/MM/yyyy HH:mm:ss tt"), letraTi, Brushes.Black, new Rectangle(2, 108, 350, 80));
            e.Graphics.DrawString("============================", letraTi, Brushes.Black, new Rectangle(2, 122, 350, 80));
            e.Graphics.DrawString("CANT   DESCRIPCIÓN                    PRECIO U.      TOTAL", new Font("Arial", 7, FontStyle.Bold), Brushes.Black, new Rectangle(2, 136, 350, 80));
            e.Graphics.DrawString("============================", letraTi, Brushes.Black, new Rectangle(2, 150, 350, 80));
            int y = 164;
            int yf = 20;
            for (int i = 0; i < dtgTicket.Rows.Count; i++)
            {
                if (dtgTicket.Rows[i].Cells[2].FormattedValue.ToString().Length > 20)
                {
                    yf = dtgTicket.Rows[i].Cells[2].FormattedValue.ToString().Length / 20 * 13;
                }
                else
                {
                    yf = 20;
                }
                e.Graphics.DrawString(dtgTicket.Rows[i].Cells[1].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(2, y, 28, yf));
                e.Graphics.DrawString(dtgTicket.Rows[i].Cells[2].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(30, y, 125, yf));
                e.Graphics.DrawString(dtgTicket.Rows[i].Cells[3].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(160, y, 160, yf));
                e.Graphics.DrawString(dtgTicket.Rows[i].Cells[4].FormattedValue.ToString(), letra, Brushes.Black, new Rectangle(220, y, 220, yf));

                y += yf;
            }


            e.Graphics.DrawString("============================", letraTi, Brushes.Black, new Rectangle(2, y, 270, 80));

            y += 12;
            e.Graphics.DrawString("             TOTAL:", letra, Brushes.Black, new Rectangle(130, y, 100, 80));
            e.Graphics.DrawString(lblTotal.Text, letra, Brushes.Black, new Rectangle(215, y, 200, 80));

        }

        private void btnServDomicilio_Click(object sender, EventArgs e)
        {
            lblComedor.Visible = false;
            btnPizza.Visible = true;
            btnEnsalada.Visible = true;
            btnEspagueti.Visible = true;
            btnBebidas.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;

            lblNombreTexto.Text = "";
            lblTelefonoTexto.Text = "";
            lblCalleTexto.Text = "";
            lblColoniaTexto.Text = "";
            lblNumeroExtTexto.Text = "";

            Clientes objClientes = new Clientes(idusuario);
            objClientes.ShowDialog();
            if (!String.IsNullOrEmpty(objClientes.objDatosCliente.Telefono))
            {
                lblNombreTexto.Text = objClientes.objDatosCliente.Nombre;
                lblTelefonoTexto.Text = objClientes.objDatosCliente.Telefono;
                lblCalleTexto.Text = objClientes.objDatosCliente.Calle;
                lblColoniaTexto.Text = objClientes.objDatosCliente.Colonia;
                lblNumeroExtTexto.Text = objClientes.objDatosCliente.NumeroExterior;
                panel2.Visible = true;
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            lblComedor.Visible = false;
            panel2.Visible = false;
            btnPizza.Visible = true;
            btnEnsalada.Visible = true;
            btnEspagueti.Visible = true;
            btnBebidas.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;

            lblNombreTexto.Text = "";
            lblTelefonoTexto.Text = "";
            lblCalleTexto.Text = "";
            lblColoniaTexto.Text = "";
            lblNumeroExtTexto.Text = "";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            EntradaSalidaEfectivo es = new EntradaSalidaEfectivo(idusuario);
            es.ShowDialog();
        }

        private void dtgTicket_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dtgTicket[4, e.RowIndex].Value = Convert.ToDouble(dtgTicket[1, e.RowIndex].Value) *
                   Convert.ToDouble(dtgTicket[3, e.RowIndex].Value);

                if (dtgTicket.Rows.Count> e.RowIndex + 1)
                {
                    if (Convert.ToInt32(dtgTicket[6, e.RowIndex].Value) == Convert.ToInt32(dtgTicket[6, e.RowIndex + 1].Value))
                    {
                        dtgTicket[4, e.RowIndex + 1].Value = Convert.ToDouble(dtgTicket[1, e.RowIndex].Value) *
                            Convert.ToDouble(dtgTicket[1, e.RowIndex + 1].Value) *
                            Convert.ToDouble(dtgTicket[3, e.RowIndex + 1].Value);
                    }
                }
                obtenerTotales();
            }catch(Exception ex)
            {
            }    
        }

        private void dtgTicket_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(dtgTicket_KeyPress);
        }

        private void dtgTicket_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dtgTicket.CurrentCell.ColumnIndex == 1)
            {
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != 46)
                {

                    e.Handled = true;

                }
            }
        }
       
      
        private void btnIzquierdo_Click(object sender, EventArgs e)
        {
            objIzquierdo = new List<AgregarPizza>();
            objIzquierdo.Add(objAgregarPizza);
            tbxSeguimiento.Text = "";
            String sIngredientes = "";
            
            foreach(String ing in objIzquierdo[0].Ingredientes)
            {
                sIngredientes += ", "+ing;
            }
            sIngredientes+=" Extra";
            foreach(String ing in  objIzquierdo[0].IngredienteExtra)
            {
                    sIngredientes += ", "+ing;
            }
            tbxSeguimiento.Text = "IZQUIERDA: " + objIzquierdo[0].NombrePizza + sIngredientes;
            sIngredientes = "";
            if (objDerecho.Count > 0)
            {
                foreach (String ing in objDerecho[0].Ingredientes)
                {
                    sIngredientes += ", " + ing;
                }
                sIngredientes += " Extra";
                foreach (String ing in objDerecho[0].IngredienteExtra)
                {
                    sIngredientes += ", " + ing;
                }
                tbxSeguimiento.Text += " | DERECHA: " + objDerecho[0].NombrePizza + sIngredientes;
            }
            //btnIzquierdo.Enabled = false;
            SiguienteMitad(objIzquierdo[0]);
        }

        private void btnDerecho_Click(object sender, EventArgs e)
        {
            objDerecho = new List<AgregarPizza>();
            objDerecho.Add(objAgregarPizza);
            tbxSeguimiento.Text = "";
            String sIngredientes = "";
            if (objIzquierdo.Count > 0)
            {
                foreach (String ing in objIzquierdo[0].Ingredientes)
                {
                    sIngredientes += ", " + ing;
                }
                sIngredientes += " Extra";
                foreach (String ing in objIzquierdo[0].IngredienteExtra)
                {
                    sIngredientes += ", " + ing;
                }
                tbxSeguimiento.Text = "IZQUIERDA " + objIzquierdo[0].NombrePizza + sIngredientes;
            }
                 sIngredientes = "";
           
            foreach (String ing in objDerecho[0].Ingredientes)
            {
                sIngredientes += ", " + ing;
            }
            sIngredientes += " Extra";
            foreach (String ing in objDerecho[0].IngredienteExtra)
            {
                sIngredientes += ", " + ing;
            }
            tbxSeguimiento.Text += " | DERECHA: " + objDerecho[0].NombrePizza + sIngredientes;
            //btnDerecho.Enabled = false;
            //if (nMitad > 0)
            {
                SiguienteMitad(objDerecho[0]);
            }
            
            nMitad++;
        }

        private void SiguienteMitad(AgregarPizza objMitad)
        {
            btnArmaTuPizza.Visible = true;
            btnPizzaCasa.Visible = true;
            btnTradicional.Visible = true;
            btnMasaGluten.Visible = false;
            btnMasaIntegral.Visible = false;
            btnMasaNormal.Visible = false;
            btn35CM.Visible = false;
            btn25CM.Visible = false;
           

            panelSeleccion.Visible = false;
            flpPizzaTradicional.Visible = false;                   
            lblTiposPizzas.Visible = false;
            flpPizzaCasa.Visible = false;
            flpIngredientes.Visible = false;
            btnAgregarPizza.Visible = false;
            btnIngredientes.Visible = false;
            btnIngredienteExtra.Visible = false;
           
            CargarIngredientes();

            objAgregarPizza = new AgregarPizza();
            objAgregarPizza.Ingredientes = new List<string>();
            objAgregarPizza.IngredienteExtra = new List<string>();
            objAgregarPizza.Tamaño = objMitad.Tamaño;
            objAgregarPizza.TipoMasa = objMitad.TipoMasa;
            iIngredientesMax = 0;
            if(objIzquierdo.Count>0 &&objDerecho.Count>0)
            {
                btnAgregarPizza.Visible = true;
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            SiguienteMitad(objAgregarPizza);
        }
    }
}


