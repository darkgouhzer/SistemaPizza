namespace Punto_Venta
{
    partial class Ventas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxCodigo = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.dtgVentas = new System.Windows.Forms.DataGridView();
            this.dtgCodigoBarras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.tbxTicket = new System.Windows.Forms.Button();
            this.btnEfectivo = new System.Windows.Forms.Button();
            this.btnCorte = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnProveedores = new System.Windows.Forms.Button();
            this.btnVarios = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dtgVentas)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(-162, 73);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 24);
            this.label2.TabIndex = 18;
            this.label2.Text = "CODIGO";
            // 
            // tbxCodigo
            // 
            this.tbxCodigo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbxCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxCodigo.Location = new System.Drawing.Point(108, 70);
            this.tbxCodigo.Margin = new System.Windows.Forms.Padding(4);
            this.tbxCodigo.Name = "tbxCodigo";
            this.tbxCodigo.Size = new System.Drawing.Size(635, 29);
            this.tbxCodigo.TabIndex = 0;
            this.tbxCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxCodigo_KeyDown);
            this.tbxCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxCodigo_KeyPress);
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTotal.BackColor = System.Drawing.Color.Lime;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 23F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(768, 626);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(240, 83);
            this.lblTotal.TabIndex = 29;
            this.lblTotal.Text = "$ 0.0";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAgregar.BackColor = System.Drawing.Color.White;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(750, 70);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(116, 30);
            this.btnAgregar.TabIndex = 1;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            this.btnAgregar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnAgregar_KeyDown);
            this.btnAgregar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnAgregar_KeyPress);
            // 
            // dtgVentas
            // 
            this.dtgVentas.AllowUserToAddRows = false;
            this.dtgVentas.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtgVentas.BackgroundColor = System.Drawing.Color.White;
            this.dtgVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgVentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtgCodigoBarras,
            this.dtgDescripcion,
            this.dtgCantidad,
            this.dtgPrecio,
            this.dtgTotal,
            this.costo,
            this.id_producto});
            this.dtgVentas.Location = new System.Drawing.Point(24, 106);
            this.dtgVentas.Name = "dtgVentas";
            this.dtgVentas.ReadOnly = true;
            this.dtgVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgVentas.Size = new System.Drawing.Size(984, 504);
            this.dtgVentas.TabIndex = 2;
            this.dtgVentas.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtgVentas_RowsRemoved);
            // 
            // dtgCodigoBarras
            // 
            this.dtgCodigoBarras.HeaderText = "CÓDIGO DE BARRAS";
            this.dtgCodigoBarras.Name = "dtgCodigoBarras";
            this.dtgCodigoBarras.ReadOnly = true;
            this.dtgCodigoBarras.Width = 250;
            // 
            // dtgDescripcion
            // 
            this.dtgDescripcion.HeaderText = "DESCRIPCIÓN";
            this.dtgDescripcion.Name = "dtgDescripcion";
            this.dtgDescripcion.ReadOnly = true;
            this.dtgDescripcion.Width = 350;
            // 
            // dtgCantidad
            // 
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.dtgCantidad.DefaultCellStyle = dataGridViewCellStyle1;
            this.dtgCantidad.HeaderText = "CANTIDAD";
            this.dtgCantidad.Name = "dtgCantidad";
            this.dtgCantidad.ReadOnly = true;
            // 
            // dtgPrecio
            // 
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.dtgPrecio.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgPrecio.HeaderText = "PRECIO";
            this.dtgPrecio.Name = "dtgPrecio";
            this.dtgPrecio.ReadOnly = true;
            // 
            // dtgTotal
            // 
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.dtgTotal.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtgTotal.HeaderText = "TOTAL";
            this.dtgTotal.Name = "dtgTotal";
            this.dtgTotal.ReadOnly = true;
            // 
            // costo
            // 
            this.costo.HeaderText = "costo";
            this.costo.Name = "costo";
            this.costo.ReadOnly = true;
            this.costo.Visible = false;
            // 
            // id_producto
            // 
            this.id_producto.HeaderText = "id producto";
            this.id_producto.Name = "id_producto";
            this.id_producto.ReadOnly = true;
            this.id_producto.Visible = false;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // tbxTicket
            // 
            this.tbxTicket.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbxTicket.BackColor = System.Drawing.Color.White;
            this.tbxTicket.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.tbxTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxTicket.Image = global::Punto_Venta.Properties.Resources.logout_icon21x21;
            this.tbxTicket.Location = new System.Drawing.Point(320, 643);
            this.tbxTicket.Name = "tbxTicket";
            this.tbxTicket.Size = new System.Drawing.Size(227, 48);
            this.tbxTicket.TabIndex = 9;
            this.tbxTicket.Text = "DEVOLUCIONES [F7]";
            this.tbxTicket.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.tbxTicket.UseVisualStyleBackColor = false;
            this.tbxTicket.Click += new System.EventHandler(this.tbxTicket_Click);
            this.tbxTicket.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxTicket_KeyPress);
            // 
            // btnEfectivo
            // 
            this.btnEfectivo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnEfectivo.BackColor = System.Drawing.Color.White;
            this.btnEfectivo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEfectivo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEfectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEfectivo.Image = global::Punto_Venta.Properties.Resources.simboloDineromini;
            this.btnEfectivo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEfectivo.Location = new System.Drawing.Point(469, 3);
            this.btnEfectivo.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.btnEfectivo.Name = "btnEfectivo";
            this.btnEfectivo.Size = new System.Drawing.Size(144, 53);
            this.btnEfectivo.TabIndex = 6;
            this.btnEfectivo.Text = "Efectivo [F4]";
            this.btnEfectivo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEfectivo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEfectivo.UseVisualStyleBackColor = false;
            this.btnEfectivo.Click += new System.EventHandler(this.btnEfectivo_Click_1);
            this.btnEfectivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnEfectivo_KeyPress);
            // 
            // btnCorte
            // 
            this.btnCorte.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCorte.BackColor = System.Drawing.Color.White;
            this.btnCorte.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCorte.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCorte.Image = global::Punto_Venta.Properties.Resources.edit_cut;
            this.btnCorte.Location = new System.Drawing.Point(24, 643);
            this.btnCorte.Name = "btnCorte";
            this.btnCorte.Size = new System.Drawing.Size(208, 48);
            this.btnCorte.TabIndex = 8;
            this.btnCorte.Text = "CORTE CAJA [F6]";
            this.btnCorte.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCorte.UseVisualStyleBackColor = false;
            this.btnCorte.Click += new System.EventHandler(this.btnCorte_Click);
            this.btnCorte.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnCorte_KeyPress);
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Image = global::Punto_Venta.Properties.Resources.simboloDineromini;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(624, 626);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(138, 83);
            this.button3.TabIndex = 3;
            this.button3.Text = "COBRAR [F1]";
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            this.button3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.button3_KeyPress);
            // 
            // btnProveedores
            // 
            this.btnProveedores.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnProveedores.BackColor = System.Drawing.Color.White;
            this.btnProveedores.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnProveedores.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProveedores.Image = global::Punto_Venta.Properties.Resources.Lorry_Green1;
            this.btnProveedores.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProveedores.Location = new System.Drawing.Point(646, 3);
            this.btnProveedores.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.btnProveedores.Name = "btnProveedores";
            this.btnProveedores.Size = new System.Drawing.Size(220, 53);
            this.btnProveedores.TabIndex = 7;
            this.btnProveedores.Text = "Proveedores [F5]";
            this.btnProveedores.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProveedores.UseVisualStyleBackColor = false;
            this.btnProveedores.Click += new System.EventHandler(this.btnProveedores_Click);
            this.btnProveedores.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnProveedores_KeyPress);
            // 
            // btnVarios
            // 
            this.btnVarios.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnVarios.BackColor = System.Drawing.Color.White;
            this.btnVarios.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVarios.Image = global::Punto_Venta.Properties.Resources.buy_32;
            this.btnVarios.Location = new System.Drawing.Point(108, 3);
            this.btnVarios.Name = "btnVarios";
            this.btnVarios.Size = new System.Drawing.Size(144, 53);
            this.btnVarios.TabIndex = 4;
            this.btnVarios.Text = "Varios [F2]";
            this.btnVarios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVarios.UseVisualStyleBackColor = false;
            this.btnVarios.Click += new System.EventHandler(this.btnVarios_Click);
            this.btnVarios.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnVarios_KeyDown);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnBuscar.BackColor = System.Drawing.Color.White;
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Image = global::Punto_Venta.Properties.Resources.search_32;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(285, 3);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(151, 53);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.Text = "Buscar [F3]";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            this.btnBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnBuscar_KeyPress);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.BackgroundImage = global::Punto_Venta.Properties.Resources.logout_28550;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(964, 57);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 40);
            this.button1.TabIndex = 30;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnVarios);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.tbxCodigo);
            this.panel1.Controls.Add(this.tbxTicket);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnEfectivo);
            this.panel1.Controls.Add(this.btnBuscar);
            this.panel1.Controls.Add(this.dtgVentas);
            this.panel1.Controls.Add(this.btnProveedores);
            this.panel1.Controls.Add(this.btnAgregar);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.lblTotal);
            this.panel1.Controls.Add(this.btnCorte);
            this.panel1.Location = new System.Drawing.Point(26, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1024, 768);
            this.panel1.TabIndex = 31;
            // 
            // Ventas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(1078, 725);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Ventas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ventas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Ventas_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ventas_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dtgVentas)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxCodigo;
        private System.Windows.Forms.Button btnVarios;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnCorte;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnProveedores;
        private System.Windows.Forms.DataGridView dtgVentas;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgCodigoBarras;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn costo;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_producto;
        private System.Windows.Forms.Button btnEfectivo;
        private System.Windows.Forms.Button tbxTicket;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
    }
}