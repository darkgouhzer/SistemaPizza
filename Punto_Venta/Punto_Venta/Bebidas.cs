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

namespace Punto_Venta
{
    public partial class Bebidas : Form
    {
        conexion conn = new conexion();
        MySqlConnection conectar;
        MySqlCommand comando;
        MySqlDataReader lector;
        string idusuario = "";
        string departamento = "";
        Label[] lblBebidas;
        Button[] botonMin;
        Button[] botonMax;
        TextBox[] txtCantidad;
        Double[] Precio;
        DatosProductos objDatosProductos;
        public List<DatosProductos> objListDatosProductos = new List<DatosProductos>();
        public Bebidas()
        {
            InitializeComponent(); 
            cargarBebidas();
        }
        public void RestarBtn_Click(Object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            int iIndiceCantidad = Convert.ToInt32(clickedButton.Name.Split('-')[0]);
            if (Convert.ToInt32(txtCantidad[iIndiceCantidad].Text) != 0)
                txtCantidad[iIndiceCantidad].Text = (Convert.ToInt32(txtCantidad[iIndiceCantidad].Text) - 1).ToString();
        }
        public void SumarBtn_Click(Object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            int iIndiceCantidad = Convert.ToInt32(clickedButton.Name.Split('-')[0]);
            txtCantidad[iIndiceCantidad].Text = (Convert.ToInt32(txtCantidad[iIndiceCantidad].Text) + 1).ToString();

        }
        public void cargarBebidas()
        {
            List<tipoPizzaLista> lista = new List<tipoPizzaLista>();
            conectar = conn.ObtenerConexion();
            comando = new MySqlCommand("select id,Descripcion,Precio_venta from " +
                                       "productos where Departamentos_idDepartamentos = 1;", conectar);
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

            lblBebidas = new Label[lista.Count];
            botonMin = new Button[lista.Count];
            botonMax = new Button[lista.Count];
            txtCantidad = new TextBox[lista.Count];
            Precio = new double[lista.Count];
            int j = 10, i = 0;
            foreach (tipoPizzaLista dato in lista)
            {
                Precio[i] = dato.PrecioVenta;
                lblBebidas[i] = new Label();
                lblBebidas[i].Text = dato.Descripcion;
                lblBebidas[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lblBebidas[i].Location = new System.Drawing.Point(12, 59 + j);
                lblBebidas[i].Visible = true;

                botonMin[i] = new Button();
                botonMin[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                botonMin[i].Location = new System.Drawing.Point(12 + 100, 59 + j);
                botonMin[i].Name = i + "-" + dato.Codigo.ToString();
                botonMin[i].Size = new System.Drawing.Size(35, 35);
                botonMin[i].TabIndex = 0;
                botonMin[i].Text = "-";
                botonMin[i].UseVisualStyleBackColor = true;
                botonMin[i].Visible = true;
                botonMin[i].BackgroundImage = dato.Imagen;
                botonMin[i].BackgroundImageLayout = ImageLayout.Stretch;
                botonMin[i].Click += new EventHandler(RestarBtn_Click);

                txtCantidad[i] = new TextBox();
                txtCantidad[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                txtCantidad[i].Location = new System.Drawing.Point(12 + 100, 59 + j);
                txtCantidad[i].Name = i + "-" + dato.Codigo.ToString();
                txtCantidad[i].Size = new System.Drawing.Size(35, 35);
                txtCantidad[i].TabIndex = 0;
                txtCantidad[i].Text = "0";
                txtCantidad[i].ReadOnly = true;
                txtCantidad[i].TextAlign = HorizontalAlignment.Center;
                txtCantidad[i].Visible = true;
                txtCantidad[i].BackgroundImage = dato.Imagen;
                txtCantidad[i].BackgroundImageLayout = ImageLayout.Stretch;


                botonMax[i] = new Button();
                botonMax[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                botonMax[i].Location = new System.Drawing.Point(12 + 100, 59 + j);
                botonMax[i].Name = i + "-" + dato.Codigo.ToString();
                botonMax[i].Size = new System.Drawing.Size(35, 35);
                botonMax[i].TabIndex = 0;
                botonMax[i].Text = "+";
                botonMax[i].UseVisualStyleBackColor = true;
                botonMax[i].Visible = true;
                botonMax[i].BackgroundImage = dato.Imagen;
                botonMax[i].BackgroundImageLayout = ImageLayout.Stretch;
                botonMax[i].Click += new EventHandler(SumarBtn_Click);

                //this.Controls.Add(boton[i]);
                this.flpBebidas.Controls.Add(lblBebidas[i]);
                this.flpBebidas.Controls.Add(botonMin[i]);
                this.flpBebidas.Controls.Add(txtCantidad[i]);
                this.flpBebidas.Controls.Add(botonMax[i]);

                tableLayoutPanel1.Controls.Add(lblBebidas[i]);
                this.tableLayoutPanel1.Controls.Add(botonMin[i]);
                this.tableLayoutPanel1.Controls.Add(txtCantidad[i]);
                this.tableLayoutPanel1.Controls.Add(botonMax[i]);
                i++;
            }
        }

        private void Bebidas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            objListDatosProductos = new List<DatosProductos>();
            for (int i = 0; i < txtCantidad.Length; i++)
            {
                if (Convert.ToInt32(txtCantidad[i].Text) > 0)
                {
                    objDatosProductos = new DatosProductos();
                    String[] dato = txtCantidad[i].Name.Split('-');
                    objDatosProductos.sCodigo = dato[1];
                    objDatosProductos.iCantidad = Convert.ToInt32(txtCantidad[i].Text);
                    objDatosProductos.sDescripcion = lblBebidas[i].Text;
                    objDatosProductos.dPrecio = Precio[i];
                    objListDatosProductos.Add(objDatosProductos);
                }
            }
            this.Close();
        }
    }
}
