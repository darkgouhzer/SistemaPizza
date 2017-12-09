namespace Punto_Venta
{
    partial class compraProveedor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtgCompra = new System.Windows.Forms.DataGridView();
            this.dtgCodigoBarras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgCosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxCodigo = new System.Windows.Forms.TextBox();
            this.btnPagar = new System.Windows.Forms.Button();
            this.tbxCosto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxCantidad = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxNombreP = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCompra)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgCompra
            // 
            this.dtgCompra.AllowUserToAddRows = false;
            this.dtgCompra.BackgroundColor = System.Drawing.Color.White;
            this.dtgCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCompra.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtgCodigoBarras,
            this.dtgDescripcion,
            this.dtgCantidad,
            this.dtgCosto,
            this.dtgTotal,
            this.id_producto});
            this.dtgCompra.Location = new System.Drawing.Point(3, 85);
            this.dtgCompra.Name = "dtgCompra";
            this.dtgCompra.ReadOnly = true;
            this.dtgCompra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCompra.Size = new System.Drawing.Size(993, 450);
            this.dtgCompra.TabIndex = 6;
            this.dtgCompra.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCompra_CellValueChanged);
            this.dtgCompra.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtgCompra_RowsRemoved);
            // 
            // dtgCodigoBarras
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.dtgCodigoBarras.DefaultCellStyle = dataGridViewCellStyle1;
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
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.dtgCantidad.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgCantidad.HeaderText = "CANTIDAD";
            this.dtgCantidad.Name = "dtgCantidad";
            this.dtgCantidad.ReadOnly = true;
            // 
            // dtgCosto
            // 
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.dtgCosto.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtgCosto.HeaderText = "COSTO";
            this.dtgCosto.Name = "dtgCosto";
            this.dtgCosto.ReadOnly = true;
            // 
            // dtgTotal
            // 
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.NullValue = null;
            this.dtgTotal.DefaultCellStyle = dataGridViewCellStyle4;
            this.dtgTotal.HeaderText = "TOTAL";
            this.dtgTotal.Name = "dtgTotal";
            this.dtgTotal.ReadOnly = true;
            // 
            // id_producto
            // 
            this.id_producto.HeaderText = "id producto";
            this.id_producto.Name = "id_producto";
            this.id_producto.ReadOnly = true;
            this.id_producto.Visible = false;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.White;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Image = global::Punto_Venta.Properties.Resources.add24;
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar.Location = new System.Drawing.Point(880, 49);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(116, 30);
            this.btnAgregar.TabIndex = 3;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.BackColor = System.Drawing.Color.Lime;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 23F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(756, 541);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(240, 83);
            this.lblTotal.TabIndex = 35;
            this.lblTotal.Text = "$ 0.0";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 51);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 24);
            this.label2.TabIndex = 33;
            this.label2.Text = "CODIGO";
            // 
            // tbxCodigo
            // 
            this.tbxCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxCodigo.Location = new System.Drawing.Point(97, 48);
            this.tbxCodigo.Margin = new System.Windows.Forms.Padding(4);
            this.tbxCodigo.Name = "tbxCodigo";
            this.tbxCodigo.Size = new System.Drawing.Size(353, 29);
            this.tbxCodigo.TabIndex = 0;
            this.tbxCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxCodigo_KeyDown);
            // 
            // btnPagar
            // 
            this.btnPagar.BackColor = System.Drawing.Color.White;
            this.btnPagar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPagar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPagar.Image = global::Punto_Venta.Properties.Resources.simboloDineromini;
            this.btnPagar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPagar.Location = new System.Drawing.Point(612, 541);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(138, 83);
            this.btnPagar.TabIndex = 4;
            this.btnPagar.Text = "PAGAR";
            this.btnPagar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPagar.UseVisualStyleBackColor = false;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // tbxCosto
            // 
            this.tbxCosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxCosto.Location = new System.Drawing.Point(756, 48);
            this.tbxCosto.Margin = new System.Windows.Forms.Padding(4);
            this.tbxCosto.Name = "tbxCosto";
            this.tbxCosto.Size = new System.Drawing.Size(117, 29);
            this.tbxCosto.TabIndex = 2;
            this.tbxCosto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxCosto_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(666, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 24);
            this.label1.TabIndex = 39;
            this.label1.Text = "COSTO:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(458, 51);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 24);
            this.label3.TabIndex = 41;
            this.label3.Text = "CANTIDAD:";
            // 
            // tbxCantidad
            // 
            this.tbxCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxCantidad.Location = new System.Drawing.Point(567, 48);
            this.tbxCantidad.Margin = new System.Windows.Forms.Padding(4);
            this.tbxCantidad.Name = "tbxCantidad";
            this.tbxCantidad.Size = new System.Drawing.Size(91, 29);
            this.tbxCantidad.TabIndex = 1;
            this.tbxCantidad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxCantidad_KeyDown);
            this.tbxCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxCantidad_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(254, 24);
            this.label4.TabIndex = 42;
            this.label4.Text = "NOMBRE DE PROVEEDOR:";
            // 
            // tbxNombreP
            // 
            this.tbxNombreP.BackColor = System.Drawing.Color.White;
            this.tbxNombreP.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxNombreP.Location = new System.Drawing.Point(270, 8);
            this.tbxNombreP.Margin = new System.Windows.Forms.Padding(4);
            this.tbxNombreP.Name = "tbxNombreP";
            this.tbxNombreP.ReadOnly = true;
            this.tbxNombreP.Size = new System.Drawing.Size(478, 29);
            this.tbxNombreP.TabIndex = 43;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = global::Punto_Venta.Properties.Resources.logout_icon21x21;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.Location = new System.Drawing.Point(12, 557);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(155, 60);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Salir";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.dtgCompra);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.tbxCodigo);
            this.panel1.Controls.Add(this.tbxNombreP);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnPagar);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblTotal);
            this.panel1.Controls.Add(this.tbxCantidad);
            this.panel1.Controls.Add(this.btnAgregar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tbxCosto);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 730);
            this.panel1.TabIndex = 44;
            // 
            // compraProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "compraProveedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Compra a proveedor";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.compraProveedor_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCompra)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgCompra;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxCodigo;
        private System.Windows.Forms.TextBox tbxCosto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxCantidad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxNombreP;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgCodigoBarras;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgCosto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_producto;
        private System.Windows.Forms.Panel panel1;
    }
}