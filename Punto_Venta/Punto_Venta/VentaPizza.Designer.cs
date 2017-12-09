namespace Punto_Venta
{
    partial class VentaPizza
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle43 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle44 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle46 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle47 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle48 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle45 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTotal = new System.Windows.Forms.Label();
            this.dtgTicket = new System.Windows.Forms.DataGridView();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecioUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecioTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductosInventario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLigueIngExtra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumeroMesa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGrabarPreventa = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDocument2 = new System.Drawing.Printing.PrintDocument();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblNumeroExtTexto = new System.Windows.Forms.Label();
            this.lblNumeroExt = new System.Windows.Forms.Label();
            this.lblColoniaTexto = new System.Windows.Forms.Label();
            this.lblColonia = new System.Windows.Forms.Label();
            this.lblCalleTexto = new System.Windows.Forms.Label();
            this.lblCalle = new System.Windows.Forms.Label();
            this.lblTelefonoTexto = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblNombreTexto = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblComedor = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.btnCobrar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.btnDerecho = new System.Windows.Forms.Button();
            this.btnIzquierdo = new System.Windows.Forms.Button();
            this.tbxSeguimiento = new System.Windows.Forms.TextBox();
            this.btnServDomicilio = new System.Windows.Forms.Button();
            this.btnComedor = new System.Windows.Forms.Button();
            this.btnIngredienteExtra = new System.Windows.Forms.Button();
            this.btnIngredientes = new System.Windows.Forms.Button();
            this.flpPizzaTradicional = new System.Windows.Forms.FlowLayoutPanel();
            this.panelSeleccion = new System.Windows.Forms.Panel();
            this.lblNombreSeleccion = new System.Windows.Forms.Label();
            this.picBoxSeleccion = new System.Windows.Forms.PictureBox();
            this.btnAgregarPizza = new System.Windows.Forms.Button();
            this.btnTradicional = new System.Windows.Forms.Button();
            this.btnPizzaCasa = new System.Windows.Forms.Button();
            this.btnArmaTuPizza = new System.Windows.Forms.Button();
            this.btnMasaGluten = new System.Windows.Forms.Button();
            this.btnMasaIntegral = new System.Windows.Forms.Button();
            this.btnMasaNormal = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.flpIngredientes = new System.Windows.Forms.FlowLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.flpPizzaCasa = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTiposPizzas = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnPizza = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblIngredientes = new System.Windows.Forms.Label();
            this.btnEspagueti = new System.Windows.Forms.Button();
            this.btnEnsalada = new System.Windows.Forms.Button();
            this.btn25CM = new System.Windows.Forms.Button();
            this.btnBebidas = new System.Windows.Forms.Button();
            this.btn35CM = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTicket)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelSeleccion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSeleccion)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.BackColor = System.Drawing.Color.Lime;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 23F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(887, 709);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(151, 54);
            this.lblTotal.TabIndex = 62;
            this.lblTotal.Text = "$ 0.0";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtgTicket
            // 
            this.dtgTicket.AllowUserToAddRows = false;
            dataGridViewCellStyle43.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dtgTicket.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle43;
            this.dtgTicket.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle44.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle44.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle44.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            dataGridViewCellStyle44.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle44.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle44.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle44.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgTicket.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle44;
            this.dtgTicket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgTicket.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodigo,
            this.colCantidad,
            this.colProducto,
            this.colPrecioUnit,
            this.colPrecioTotal,
            this.colProductosInventario,
            this.colLigueIngExtra,
            this.colNumeroMesa});
            dataGridViewCellStyle46.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle46.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle46.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle46.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle46.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle46.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle46.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgTicket.DefaultCellStyle = dataGridViewCellStyle46;
            this.dtgTicket.Location = new System.Drawing.Point(563, 118);
            this.dtgTicket.Name = "dtgTicket";
            dataGridViewCellStyle47.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle47.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle47.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle47.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle47.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle47.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle47.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgTicket.RowHeadersDefaultCellStyle = dataGridViewCellStyle47;
            dataGridViewCellStyle48.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgTicket.RowsDefaultCellStyle = dataGridViewCellStyle48;
            this.dtgTicket.Size = new System.Drawing.Size(475, 588);
            this.dtgTicket.TabIndex = 63;
            this.dtgTicket.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgTicket_CellEndEdit);
            this.dtgTicket.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgTicket_EditingControlShowing);
            this.dtgTicket.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dtgTicket_RowStateChanged);
            this.dtgTicket.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtgTicket_KeyPress);
            // 
            // colCodigo
            // 
            this.colCodigo.HeaderText = "Codigo";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.ReadOnly = true;
            this.colCodigo.Visible = false;
            // 
            // colCantidad
            // 
            dataGridViewCellStyle45.Format = "N0";
            dataGridViewCellStyle45.NullValue = null;
            this.colCantidad.DefaultCellStyle = dataGridViewCellStyle45;
            this.colCantidad.HeaderText = "Cant.";
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.Width = 50;
            // 
            // colProducto
            // 
            this.colProducto.HeaderText = "Producto";
            this.colProducto.Name = "colProducto";
            this.colProducto.ReadOnly = true;
            this.colProducto.Width = 230;
            // 
            // colPrecioUnit
            // 
            this.colPrecioUnit.HeaderText = "Precio Unitario";
            this.colPrecioUnit.Name = "colPrecioUnit";
            this.colPrecioUnit.ReadOnly = true;
            this.colPrecioUnit.Width = 60;
            // 
            // colPrecioTotal
            // 
            this.colPrecioTotal.HeaderText = "Total";
            this.colPrecioTotal.Name = "colPrecioTotal";
            this.colPrecioTotal.ReadOnly = true;
            this.colPrecioTotal.Width = 70;
            // 
            // colProductosInventario
            // 
            this.colProductosInventario.HeaderText = "colProductosInventario";
            this.colProductosInventario.Name = "colProductosInventario";
            this.colProductosInventario.ReadOnly = true;
            this.colProductosInventario.Visible = false;
            // 
            // colLigueIngExtra
            // 
            this.colLigueIngExtra.HeaderText = "colLigueIngExtra";
            this.colLigueIngExtra.Name = "colLigueIngExtra";
            this.colLigueIngExtra.ReadOnly = true;
            this.colLigueIngExtra.Visible = false;
            // 
            // colNumeroMesa
            // 
            this.colNumeroMesa.HeaderText = "Numero mesa";
            this.colNumeroMesa.Name = "colNumeroMesa";
            this.colNumeroMesa.ReadOnly = true;
            this.colNumeroMesa.Visible = false;
            // 
            // btnGrabarPreventa
            // 
            this.btnGrabarPreventa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGrabarPreventa.Location = new System.Drawing.Point(619, 709);
            this.btnGrabarPreventa.Name = "btnGrabarPreventa";
            this.btnGrabarPreventa.Size = new System.Drawing.Size(78, 53);
            this.btnGrabarPreventa.TabIndex = 66;
            this.btnGrabarPreventa.Text = "PREVENTA";
            this.btnGrabarPreventa.UseVisualStyleBackColor = true;
            this.btnGrabarPreventa.Click += new System.EventHandler(this.btnGrabarPreventa_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printDocument2
            // 
            this.printDocument2.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument2_PrintPage);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblNumeroExtTexto);
            this.panel2.Controls.Add(this.lblNumeroExt);
            this.panel2.Controls.Add(this.lblColoniaTexto);
            this.panel2.Controls.Add(this.lblColonia);
            this.panel2.Controls.Add(this.lblCalleTexto);
            this.panel2.Controls.Add(this.lblCalle);
            this.panel2.Controls.Add(this.lblTelefonoTexto);
            this.panel2.Controls.Add(this.lblTelefono);
            this.panel2.Controls.Add(this.lblNombreTexto);
            this.panel2.Controls.Add(this.lblNombre);
            this.panel2.Location = new System.Drawing.Point(564, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(474, 100);
            this.panel2.TabIndex = 67;
            this.panel2.Visible = false;
            // 
            // lblNumeroExtTexto
            // 
            this.lblNumeroExtTexto.AutoSize = true;
            this.lblNumeroExtTexto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroExtTexto.Location = new System.Drawing.Point(385, 51);
            this.lblNumeroExtTexto.Name = "lblNumeroExtTexto";
            this.lblNumeroExtTexto.Size = new System.Drawing.Size(91, 16);
            this.lblNumeroExtTexto.TabIndex = 9;
            this.lblNumeroExtTexto.Text = "Numero Casa";
            // 
            // lblNumeroExt
            // 
            this.lblNumeroExt.AutoSize = true;
            this.lblNumeroExt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroExt.Location = new System.Drawing.Point(272, 51);
            this.lblNumeroExt.Name = "lblNumeroExt";
            this.lblNumeroExt.Size = new System.Drawing.Size(104, 16);
            this.lblNumeroExt.TabIndex = 8;
            this.lblNumeroExt.Text = "Numero Exterior";
            // 
            // lblColoniaTexto
            // 
            this.lblColoniaTexto.AutoSize = true;
            this.lblColoniaTexto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColoniaTexto.Location = new System.Drawing.Point(385, 25);
            this.lblColoniaTexto.Name = "lblColoniaTexto";
            this.lblColoniaTexto.Size = new System.Drawing.Size(54, 16);
            this.lblColoniaTexto.TabIndex = 7;
            this.lblColoniaTexto.Text = "Colonia";
            // 
            // lblColonia
            // 
            this.lblColonia.AutoSize = true;
            this.lblColonia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColonia.Location = new System.Drawing.Point(272, 25);
            this.lblColonia.Name = "lblColonia";
            this.lblColonia.Size = new System.Drawing.Size(54, 16);
            this.lblColonia.TabIndex = 6;
            this.lblColonia.Text = "Colonia";
            // 
            // lblCalleTexto
            // 
            this.lblCalleTexto.AutoSize = true;
            this.lblCalleTexto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCalleTexto.Location = new System.Drawing.Point(75, 62);
            this.lblCalleTexto.Name = "lblCalleTexto";
            this.lblCalleTexto.Size = new System.Drawing.Size(39, 16);
            this.lblCalleTexto.TabIndex = 5;
            this.lblCalleTexto.Text = "Calle";
            // 
            // lblCalle
            // 
            this.lblCalle.AutoSize = true;
            this.lblCalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCalle.Location = new System.Drawing.Point(3, 62);
            this.lblCalle.Name = "lblCalle";
            this.lblCalle.Size = new System.Drawing.Size(65, 16);
            this.lblCalle.TabIndex = 4;
            this.lblCalle.Text = "Dirección";
            // 
            // lblTelefonoTexto
            // 
            this.lblTelefonoTexto.AutoSize = true;
            this.lblTelefonoTexto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelefonoTexto.Location = new System.Drawing.Point(75, 37);
            this.lblTelefonoTexto.Name = "lblTelefonoTexto";
            this.lblTelefonoTexto.Size = new System.Drawing.Size(62, 16);
            this.lblTelefonoTexto.TabIndex = 3;
            this.lblTelefonoTexto.Text = "Telefono";
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelefono.Location = new System.Drawing.Point(3, 37);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(62, 16);
            this.lblTelefono.TabIndex = 2;
            this.lblTelefono.Text = "Telefono";
            // 
            // lblNombreTexto
            // 
            this.lblNombreTexto.AutoSize = true;
            this.lblNombreTexto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreTexto.Location = new System.Drawing.Point(75, 13);
            this.lblNombreTexto.Name = "lblNombreTexto";
            this.lblNombreTexto.Size = new System.Drawing.Size(57, 16);
            this.lblNombreTexto.TabIndex = 1;
            this.lblNombreTexto.Text = "Nombre";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(3, 13);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(57, 16);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre";
            // 
            // lblComedor
            // 
            this.lblComedor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblComedor.AutoSize = true;
            this.lblComedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComedor.Location = new System.Drawing.Point(768, 52);
            this.lblComedor.Name = "lblComedor";
            this.lblComedor.Size = new System.Drawing.Size(115, 24);
            this.lblComedor.TabIndex = 68;
            this.lblComedor.Text = "COMEDOR";
            this.lblComedor.Visible = false;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(703, 709);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(73, 53);
            this.button2.TabIndex = 69;
            this.button2.Text = "EFECTIVO";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnCobrar
            // 
            this.btnCobrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCobrar.BackColor = System.Drawing.SystemColors.Control;
            this.btnCobrar.Image = global::Punto_Venta.Properties.Resources.simboloDineromini;
            this.btnCobrar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCobrar.Location = new System.Drawing.Point(782, 709);
            this.btnCobrar.Name = "btnCobrar";
            this.btnCobrar.Size = new System.Drawing.Size(99, 54);
            this.btnCobrar.TabIndex = 65;
            this.btnCobrar.Text = "COBRAR";
            this.btnCobrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCobrar.UseVisualStyleBackColor = false;
            this.btnCobrar.Click += new System.EventHandler(this.btnCobrar_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Image = global::Punto_Venta.Properties.Resources.edit_cut;
            this.button1.Location = new System.Drawing.Point(564, 709);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(49, 54);
            this.button1.TabIndex = 64;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.BackgroundImage = global::Punto_Venta.Properties.Resources.logopizza350x350;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.btnRegresar);
            this.panel1.Controls.Add(this.btnDerecho);
            this.panel1.Controls.Add(this.btnIzquierdo);
            this.panel1.Controls.Add(this.tbxSeguimiento);
            this.panel1.Controls.Add(this.btnServDomicilio);
            this.panel1.Controls.Add(this.btnComedor);
            this.panel1.Controls.Add(this.btnIngredienteExtra);
            this.panel1.Controls.Add(this.btnIngredientes);
            this.panel1.Controls.Add(this.flpPizzaTradicional);
            this.panel1.Controls.Add(this.panelSeleccion);
            this.panel1.Controls.Add(this.btnAgregarPizza);
            this.panel1.Controls.Add(this.btnTradicional);
            this.panel1.Controls.Add(this.btnPizzaCasa);
            this.panel1.Controls.Add(this.btnArmaTuPizza);
            this.panel1.Controls.Add(this.btnMasaGluten);
            this.panel1.Controls.Add(this.btnMasaIntegral);
            this.panel1.Controls.Add(this.btnMasaNormal);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.flpIngredientes);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.flpPizzaCasa);
            this.panel1.Controls.Add(this.lblTiposPizzas);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnPizza);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblIngredientes);
            this.panel1.Controls.Add(this.btnEspagueti);
            this.panel1.Controls.Add(this.btnEnsalada);
            this.panel1.Controls.Add(this.btn25CM);
            this.panel1.Controls.Add(this.btnBebidas);
            this.panel1.Controls.Add(this.btn35CM);
            this.panel1.Location = new System.Drawing.Point(7, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(550, 759);
            this.panel1.TabIndex = 61;
            // 
            // btnRegresar
            // 
            this.btnRegresar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRegresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegresar.Image = global::Punto_Venta.Properties.Resources.back48;
            this.btnRegresar.Location = new System.Drawing.Point(3, 617);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(136, 139);
            this.btnRegresar.TabIndex = 76;
            this.btnRegresar.Text = "Tipo pizza";
            this.btnRegresar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRegresar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRegresar.UseVisualStyleBackColor = true;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // btnDerecho
            // 
            this.btnDerecho.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDerecho.BackgroundImage = global::Punto_Venta.Properties.Resources.circulo_mitad300x300;
            this.btnDerecho.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDerecho.Location = new System.Drawing.Point(507, 571);
            this.btnDerecho.Name = "btnDerecho";
            this.btnDerecho.Size = new System.Drawing.Size(40, 40);
            this.btnDerecho.TabIndex = 75;
            this.btnDerecho.UseVisualStyleBackColor = true;
            this.btnDerecho.Click += new System.EventHandler(this.btnDerecho_Click);
            // 
            // btnIzquierdo
            // 
            this.btnIzquierdo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIzquierdo.BackgroundImage = global::Punto_Venta.Properties.Resources.circulo_mitad300x300I;
            this.btnIzquierdo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnIzquierdo.Location = new System.Drawing.Point(461, 571);
            this.btnIzquierdo.Name = "btnIzquierdo";
            this.btnIzquierdo.Size = new System.Drawing.Size(40, 40);
            this.btnIzquierdo.TabIndex = 74;
            this.btnIzquierdo.UseVisualStyleBackColor = true;
            this.btnIzquierdo.Click += new System.EventHandler(this.btnIzquierdo_Click);
            // 
            // tbxSeguimiento
            // 
            this.tbxSeguimiento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxSeguimiento.Location = new System.Drawing.Point(3, 571);
            this.tbxSeguimiento.Multiline = true;
            this.tbxSeguimiento.Name = "tbxSeguimiento";
            this.tbxSeguimiento.ReadOnly = true;
            this.tbxSeguimiento.Size = new System.Drawing.Size(452, 40);
            this.tbxSeguimiento.TabIndex = 0;
            // 
            // btnServDomicilio
            // 
            this.btnServDomicilio.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnServDomicilio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnServDomicilio.Location = new System.Drawing.Point(277, 3);
            this.btnServDomicilio.Name = "btnServDomicilio";
            this.btnServDomicilio.Size = new System.Drawing.Size(125, 39);
            this.btnServDomicilio.TabIndex = 72;
            this.btnServDomicilio.Text = "SERVICIO DOMICILIO";
            this.btnServDomicilio.UseVisualStyleBackColor = true;
            this.btnServDomicilio.Click += new System.EventHandler(this.btnServDomicilio_Click);
            // 
            // btnComedor
            // 
            this.btnComedor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnComedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComedor.Location = new System.Drawing.Point(146, 3);
            this.btnComedor.Name = "btnComedor";
            this.btnComedor.Size = new System.Drawing.Size(125, 39);
            this.btnComedor.TabIndex = 71;
            this.btnComedor.Text = "COMEDOR";
            this.btnComedor.UseVisualStyleBackColor = true;
            this.btnComedor.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnIngredienteExtra
            // 
            this.btnIngredienteExtra.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnIngredienteExtra.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngredienteExtra.Image = global::Punto_Venta.Properties.Resources.fondo_de_ingredientes_de_acuarela_para_pizza_23_2147566363;
            this.btnIngredienteExtra.Location = new System.Drawing.Point(129, 617);
            this.btnIngredienteExtra.Name = "btnIngredienteExtra";
            this.btnIngredienteExtra.Size = new System.Drawing.Size(138, 139);
            this.btnIngredienteExtra.TabIndex = 66;
            this.btnIngredienteExtra.Text = "Extra";
            this.btnIngredienteExtra.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnIngredienteExtra.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnIngredienteExtra.UseVisualStyleBackColor = true;
            this.btnIngredienteExtra.Visible = false;
            this.btnIngredienteExtra.Click += new System.EventHandler(this.btnIngredienteExtra_Click);
            // 
            // btnIngredientes
            // 
            this.btnIngredientes.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnIngredientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngredientes.Image = global::Punto_Venta.Properties.Resources.fondo_de_ingredientes_de_acuarela_para_pizza_23_2147566363;
            this.btnIngredientes.Location = new System.Drawing.Point(129, 617);
            this.btnIngredientes.Name = "btnIngredientes";
            this.btnIngredientes.Size = new System.Drawing.Size(138, 139);
            this.btnIngredientes.TabIndex = 70;
            this.btnIngredientes.Text = "Ingredientes";
            this.btnIngredientes.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnIngredientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnIngredientes.UseVisualStyleBackColor = true;
            this.btnIngredientes.Visible = false;
            this.btnIngredientes.Click += new System.EventHandler(this.btnIngredientes_Click);
            // 
            // flpPizzaTradicional
            // 
            this.flpPizzaTradicional.BackColor = System.Drawing.Color.Transparent;
            this.flpPizzaTradicional.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpPizzaTradicional.Location = new System.Drawing.Point(132, 270);
            this.flpPizzaTradicional.Name = "flpPizzaTradicional";
            this.flpPizzaTradicional.Size = new System.Drawing.Size(48, 47);
            this.flpPizzaTradicional.TabIndex = 68;
            this.flpPizzaTradicional.Visible = false;
            // 
            // panelSeleccion
            // 
            this.panelSeleccion.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panelSeleccion.BackColor = System.Drawing.Color.White;
            this.panelSeleccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSeleccion.Controls.Add(this.lblNombreSeleccion);
            this.panelSeleccion.Controls.Add(this.picBoxSeleccion);
            this.panelSeleccion.Location = new System.Drawing.Point(-12, 617);
            this.panelSeleccion.Name = "panelSeleccion";
            this.panelSeleccion.Size = new System.Drawing.Size(120, 139);
            this.panelSeleccion.TabIndex = 69;
            this.panelSeleccion.Visible = false;
            // 
            // lblNombreSeleccion
            // 
            this.lblNombreSeleccion.AutoSize = true;
            this.lblNombreSeleccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreSeleccion.Location = new System.Drawing.Point(15, 111);
            this.lblNombreSeleccion.Name = "lblNombreSeleccion";
            this.lblNombreSeleccion.Size = new System.Drawing.Size(0, 20);
            this.lblNombreSeleccion.TabIndex = 2;
            // 
            // picBoxSeleccion
            // 
            this.picBoxSeleccion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picBoxSeleccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBoxSeleccion.Location = new System.Drawing.Point(6, 3);
            this.picBoxSeleccion.Name = "picBoxSeleccion";
            this.picBoxSeleccion.Size = new System.Drawing.Size(106, 102);
            this.picBoxSeleccion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxSeleccion.TabIndex = 1;
            this.picBoxSeleccion.TabStop = false;
            // 
            // btnAgregarPizza
            // 
            this.btnAgregarPizza.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarPizza.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarPizza.Image = global::Punto_Venta.Properties.Resources.next48;
            this.btnAgregarPizza.Location = new System.Drawing.Point(401, 617);
            this.btnAgregarPizza.Name = "btnAgregarPizza";
            this.btnAgregarPizza.Size = new System.Drawing.Size(146, 139);
            this.btnAgregarPizza.TabIndex = 66;
            this.btnAgregarPizza.Text = "Agregar";
            this.btnAgregarPizza.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAgregarPizza.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAgregarPizza.UseVisualStyleBackColor = true;
            this.btnAgregarPizza.Click += new System.EventHandler(this.btnAgregarPizza_Click);
            // 
            // btnTradicional
            // 
            this.btnTradicional.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnTradicional.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTradicional.Location = new System.Drawing.Point(342, 613);
            this.btnTradicional.Name = "btnTradicional";
            this.btnTradicional.Size = new System.Drawing.Size(54, 57);
            this.btnTradicional.TabIndex = 67;
            this.btnTradicional.Text = "TRADICIONAL";
            this.btnTradicional.UseVisualStyleBackColor = true;
            this.btnTradicional.Click += new System.EventHandler(this.btnTradicional_Click);
            // 
            // btnPizzaCasa
            // 
            this.btnPizzaCasa.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnPizzaCasa.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPizzaCasa.Location = new System.Drawing.Point(482, 604);
            this.btnPizzaCasa.Name = "btnPizzaCasa";
            this.btnPizzaCasa.Size = new System.Drawing.Size(75, 75);
            this.btnPizzaCasa.TabIndex = 65;
            this.btnPizzaCasa.Text = "PIZZA DE LA CASA";
            this.btnPizzaCasa.UseVisualStyleBackColor = true;
            this.btnPizzaCasa.Click += new System.EventHandler(this.btnPizzaCasa_Click);
            // 
            // btnArmaTuPizza
            // 
            this.btnArmaTuPizza.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnArmaTuPizza.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArmaTuPizza.Location = new System.Drawing.Point(408, 645);
            this.btnArmaTuPizza.Name = "btnArmaTuPizza";
            this.btnArmaTuPizza.Size = new System.Drawing.Size(65, 57);
            this.btnArmaTuPizza.TabIndex = 64;
            this.btnArmaTuPizza.Text = "ARMA TU PIZZA";
            this.btnArmaTuPizza.UseVisualStyleBackColor = true;
            this.btnArmaTuPizza.Click += new System.EventHandler(this.btnArmaTuPizza_Click);
            // 
            // btnMasaGluten
            // 
            this.btnMasaGluten.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnMasaGluten.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMasaGluten.Location = new System.Drawing.Point(85, 494);
            this.btnMasaGluten.Name = "btnMasaGluten";
            this.btnMasaGluten.Size = new System.Drawing.Size(44, 36);
            this.btnMasaGluten.TabIndex = 63;
            this.btnMasaGluten.Text = "MASA SIN GLUTEN";
            this.btnMasaGluten.UseVisualStyleBackColor = true;
            this.btnMasaGluten.Click += new System.EventHandler(this.btnMasaGluten_Click);
            // 
            // btnMasaIntegral
            // 
            this.btnMasaIntegral.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnMasaIntegral.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMasaIntegral.Location = new System.Drawing.Point(38, 494);
            this.btnMasaIntegral.Name = "btnMasaIntegral";
            this.btnMasaIntegral.Size = new System.Drawing.Size(41, 36);
            this.btnMasaIntegral.TabIndex = 62;
            this.btnMasaIntegral.Text = "MASA INTEGRAL";
            this.btnMasaIntegral.UseVisualStyleBackColor = true;
            this.btnMasaIntegral.Click += new System.EventHandler(this.btnMasaIntegral_Click);
            // 
            // btnMasaNormal
            // 
            this.btnMasaNormal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnMasaNormal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMasaNormal.Location = new System.Drawing.Point(-8, 494);
            this.btnMasaNormal.Name = "btnMasaNormal";
            this.btnMasaNormal.Size = new System.Drawing.Size(40, 36);
            this.btnMasaNormal.TabIndex = 61;
            this.btnMasaNormal.Text = "MASA NORMAL";
            this.btnMasaNormal.UseVisualStyleBackColor = true;
            this.btnMasaNormal.Click += new System.EventHandler(this.btnMasaNormal_Click);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(48, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 24);
            this.label6.TabIndex = 60;
            this.label6.Text = "PIZZA";
            this.label6.Visible = false;
            // 
            // flpIngredientes
            // 
            this.flpIngredientes.AutoScroll = true;
            this.flpIngredientes.BackColor = System.Drawing.Color.Transparent;
            this.flpIngredientes.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpIngredientes.Location = new System.Drawing.Point(3, 353);
            this.flpIngredientes.Name = "flpIngredientes";
            this.flpIngredientes.Size = new System.Drawing.Size(51, 46);
            this.flpIngredientes.TabIndex = 53;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(285, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 24);
            this.label5.TabIndex = 58;
            this.label5.Text = "ENSALADA";
            this.label5.Visible = false;
            // 
            // flpPizzaCasa
            // 
            this.flpPizzaCasa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpPizzaCasa.AutoScroll = true;
            this.flpPizzaCasa.AutoSize = true;
            this.flpPizzaCasa.BackColor = System.Drawing.Color.Transparent;
            this.flpPizzaCasa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpPizzaCasa.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpPizzaCasa.Location = new System.Drawing.Point(3, 251);
            this.flpPizzaCasa.Name = "flpPizzaCasa";
            this.flpPizzaCasa.Size = new System.Drawing.Size(544, 314);
            this.flpPizzaCasa.TabIndex = 52;
            // 
            // lblTiposPizzas
            // 
            this.lblTiposPizzas.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTiposPizzas.AutoSize = true;
            this.lblTiposPizzas.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTiposPizzas.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblTiposPizzas.Location = new System.Drawing.Point(144, 217);
            this.lblTiposPizzas.Name = "lblTiposPizzas";
            this.lblTiposPizzas.Size = new System.Drawing.Size(274, 31);
            this.lblTiposPizzas.TabIndex = 38;
            this.lblTiposPizzas.Text = "PIZZA DE LA CASA";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(151, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 24);
            this.label4.TabIndex = 57;
            this.label4.Text = "ESPAGUETI";
            this.label4.Visible = false;
            // 
            // btnPizza
            // 
            this.btnPizza.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnPizza.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnPizza.BackgroundImage = global::Punto_Venta.Properties.Resources.pizzaVentanaPrincipal;
            this.btnPizza.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPizza.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPizza.Location = new System.Drawing.Point(15, 48);
            this.btnPizza.Name = "btnPizza";
            this.btnPizza.Size = new System.Drawing.Size(125, 125);
            this.btnPizza.TabIndex = 59;
            this.btnPizza.UseVisualStyleBackColor = false;
            this.btnPizza.Visible = false;
            this.btnPizza.Click += new System.EventHandler(this.btnPizza_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(427, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 24);
            this.label3.TabIndex = 56;
            this.label3.Text = "BEBIDAS";
            this.label3.Visible = false;
            // 
            // lblIngredientes
            // 
            this.lblIngredientes.AutoSize = true;
            this.lblIngredientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIngredientes.ForeColor = System.Drawing.SystemColors.Info;
            this.lblIngredientes.Location = new System.Drawing.Point(3, 200);
            this.lblIngredientes.Name = "lblIngredientes";
            this.lblIngredientes.Size = new System.Drawing.Size(232, 31);
            this.lblIngredientes.TabIndex = 6;
            this.lblIngredientes.Text = "INGREDIENTES";
            // 
            // btnEspagueti
            // 
            this.btnEspagueti.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnEspagueti.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnEspagueti.BackgroundImage = global::Punto_Venta.Properties.Resources.espagueti150;
            this.btnEspagueti.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEspagueti.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEspagueti.Location = new System.Drawing.Point(146, 48);
            this.btnEspagueti.Name = "btnEspagueti";
            this.btnEspagueti.Size = new System.Drawing.Size(125, 125);
            this.btnEspagueti.TabIndex = 15;
            this.btnEspagueti.UseVisualStyleBackColor = false;
            this.btnEspagueti.Visible = false;
            this.btnEspagueti.Click += new System.EventHandler(this.btnEspagueti_Click);
            // 
            // btnEnsalada
            // 
            this.btnEnsalada.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnEnsalada.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnEnsalada.BackgroundImage = global::Punto_Venta.Properties.Resources.ensalada150;
            this.btnEnsalada.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEnsalada.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnsalada.Location = new System.Drawing.Point(277, 48);
            this.btnEnsalada.Name = "btnEnsalada";
            this.btnEnsalada.Size = new System.Drawing.Size(125, 125);
            this.btnEnsalada.TabIndex = 16;
            this.btnEnsalada.UseVisualStyleBackColor = false;
            this.btnEnsalada.Visible = false;
            this.btnEnsalada.Click += new System.EventHandler(this.btnEnsalada_Click);
            // 
            // btn25CM
            // 
            this.btn25CM.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn25CM.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn25CM.Location = new System.Drawing.Point(57, 536);
            this.btn25CM.Name = "btn25CM";
            this.btn25CM.Size = new System.Drawing.Size(60, 56);
            this.btn25CM.TabIndex = 2;
            this.btn25CM.Text = "25 CM";
            this.btn25CM.UseVisualStyleBackColor = true;
            this.btn25CM.Click += new System.EventHandler(this.btn25CM_Click);
            // 
            // btnBebidas
            // 
            this.btnBebidas.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnBebidas.AutoSize = true;
            this.btnBebidas.BackgroundImage = global::Punto_Venta.Properties.Resources.refrescos_fríos_1250x150;
            this.btnBebidas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBebidas.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBebidas.Location = new System.Drawing.Point(408, 48);
            this.btnBebidas.Name = "btnBebidas";
            this.btnBebidas.Size = new System.Drawing.Size(125, 125);
            this.btnBebidas.TabIndex = 17;
            this.btnBebidas.UseVisualStyleBackColor = true;
            this.btnBebidas.Visible = false;
            this.btnBebidas.Click += new System.EventHandler(this.btnBebidas_Click);
            // 
            // btn35CM
            // 
            this.btn35CM.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn35CM.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btn35CM.FlatAppearance.BorderColor = System.Drawing.Color.Purple;
            this.btn35CM.FlatAppearance.BorderSize = 5;
            this.btn35CM.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn35CM.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lavender;
            this.btn35CM.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn35CM.Location = new System.Drawing.Point(-8, 536);
            this.btn35CM.Name = "btn35CM";
            this.btn35CM.Size = new System.Drawing.Size(60, 56);
            this.btn35CM.TabIndex = 0;
            this.btn35CM.Text = "38 CM";
            this.btn35CM.UseVisualStyleBackColor = false;
            this.btn35CM.Click += new System.EventHandler(this.btn35CM_Click);
            // 
            // VentaPizza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1050, 772);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lblComedor);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnGrabarPreventa);
            this.Controls.Add(this.btnCobrar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dtgTicket);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "VentaPizza";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Venta pizza";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.VentaPizza_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dtgTicket)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelSeleccion.ResumeLayout(false);
            this.panelSeleccion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSeleccion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn35CM;
        private System.Windows.Forms.Button btn25CM;
        private System.Windows.Forms.Label lblIngredientes;
        private System.Windows.Forms.Button btnEnsalada;
        private System.Windows.Forms.Button btnEspagueti;
        private System.Windows.Forms.Button btnBebidas;
        private System.Windows.Forms.Label lblTiposPizzas;
        private System.Windows.Forms.FlowLayoutPanel flpPizzaCasa;
        private System.Windows.Forms.FlowLayoutPanel flpIngredientes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnPizza;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnMasaGluten;
        private System.Windows.Forms.Button btnMasaIntegral;
        private System.Windows.Forms.Button btnMasaNormal;
        private System.Windows.Forms.Button btnArmaTuPizza;
        private System.Windows.Forms.Button btnPizzaCasa;
        private System.Windows.Forms.Button btnIngredienteExtra;
        private System.Windows.Forms.Button btnAgregarPizza;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnTradicional;
        private System.Windows.Forms.FlowLayoutPanel flpPizzaTradicional;
        private System.Windows.Forms.DataGridView dtgTicket;
        private System.Windows.Forms.Panel panelSeleccion;
        private System.Windows.Forms.Label lblNombreSeleccion;
        private System.Windows.Forms.PictureBox picBoxSeleccion;
        private System.Windows.Forms.Button btnIngredientes;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCobrar;
        private System.Windows.Forms.Button btnGrabarPreventa;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Drawing.Printing.PrintDocument printDocument2;
        private System.Windows.Forms.Button btnServDomicilio;
        private System.Windows.Forms.Button btnComedor;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblNumeroExtTexto;
        private System.Windows.Forms.Label lblNumeroExt;
        private System.Windows.Forms.Label lblColoniaTexto;
        private System.Windows.Forms.Label lblColonia;
        private System.Windows.Forms.Label lblCalleTexto;
        private System.Windows.Forms.Label lblCalle;
        private System.Windows.Forms.Label lblTelefonoTexto;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblNombreTexto;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblComedor;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecioUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecioTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductosInventario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLigueIngExtra;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumeroMesa;
        private System.Windows.Forms.TextBox tbxSeguimiento;
        private System.Windows.Forms.Button btnDerecho;
        private System.Windows.Forms.Button btnIzquierdo;
        private System.Windows.Forms.Button btnRegresar;
    }
}