namespace Punto_Venta
{
    partial class btnConsultarVenta
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tbxNumeroMesa = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnImprimirPreventa = new System.Windows.Forms.Button();
            this.btnCambiarMesa = new System.Windows.Forms.Button();
            this.btnTransferir = new System.Windows.Forms.Button();
            this.btnMesasPendientes = new System.Windows.Forms.Button();
            this.btnCargarVenta = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtgTicket = new System.Windows.Forms.DataGridView();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecioUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecioTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductosInventario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLigueIngExtra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnObtenerProductos = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTicket)).BeginInit();
            this.SuspendLayout();
            // 
            // tbxNumeroMesa
            // 
            this.tbxNumeroMesa.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxNumeroMesa.Location = new System.Drawing.Point(648, 12);
            this.tbxNumeroMesa.Name = "tbxNumeroMesa";
            this.tbxNumeroMesa.Size = new System.Drawing.Size(150, 62);
            this.tbxNumeroMesa.TabIndex = 0;
            this.tbxNumeroMesa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxNumeroMesa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxNumeroMesa_KeyPress);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(804, 197);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(150, 111);
            this.btnGuardar.TabIndex = 3;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnImprimirPreventa
            // 
            this.btnImprimirPreventa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnImprimirPreventa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimirPreventa.Location = new System.Drawing.Point(492, 197);
            this.btnImprimirPreventa.Name = "btnImprimirPreventa";
            this.btnImprimirPreventa.Size = new System.Drawing.Size(150, 111);
            this.btnImprimirPreventa.TabIndex = 4;
            this.btnImprimirPreventa.Text = "Imprimir preventa";
            this.btnImprimirPreventa.UseVisualStyleBackColor = true;
            this.btnImprimirPreventa.Click += new System.EventHandler(this.btnImprimirPreventa_Click);
            // 
            // btnCambiarMesa
            // 
            this.btnCambiarMesa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCambiarMesa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCambiarMesa.Location = new System.Drawing.Point(492, 80);
            this.btnCambiarMesa.Name = "btnCambiarMesa";
            this.btnCambiarMesa.Size = new System.Drawing.Size(150, 111);
            this.btnCambiarMesa.TabIndex = 2;
            this.btnCambiarMesa.Text = "Asignar mesa";
            this.btnCambiarMesa.UseVisualStyleBackColor = true;
            this.btnCambiarMesa.Click += new System.EventHandler(this.btnAsignarMesa_Click);
            // 
            // btnTransferir
            // 
            this.btnTransferir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTransferir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransferir.Location = new System.Drawing.Point(648, 80);
            this.btnTransferir.Name = "btnTransferir";
            this.btnTransferir.Size = new System.Drawing.Size(150, 111);
            this.btnTransferir.TabIndex = 5;
            this.btnTransferir.Text = "Transferir";
            this.btnTransferir.UseVisualStyleBackColor = true;
            this.btnTransferir.Click += new System.EventHandler(this.btnTransferir_Click);
            // 
            // btnMesasPendientes
            // 
            this.btnMesasPendientes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMesasPendientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMesasPendientes.Location = new System.Drawing.Point(648, 197);
            this.btnMesasPendientes.Name = "btnMesasPendientes";
            this.btnMesasPendientes.Size = new System.Drawing.Size(150, 111);
            this.btnMesasPendientes.TabIndex = 6;
            this.btnMesasPendientes.Text = "Mesas pendientes";
            this.btnMesasPendientes.UseVisualStyleBackColor = true;
            this.btnMesasPendientes.Click += new System.EventHandler(this.btnConsultarMesas_Click);
            // 
            // btnCargarVenta
            // 
            this.btnCargarVenta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCargarVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargarVenta.Location = new System.Drawing.Point(804, 80);
            this.btnCargarVenta.Name = "btnCargarVenta";
            this.btnCargarVenta.Size = new System.Drawing.Size(150, 111);
            this.btnCargarVenta.TabIndex = 7;
            this.btnCargarVenta.Text = "Cargar venta";
            this.btnCargarVenta.UseVisualStyleBackColor = true;
            this.btnCargarVenta.Click += new System.EventHandler(this.btnCargarVenta_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(500, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 55);
            this.label1.TabIndex = 8;
            this.label1.Text = "Mesa";
            // 
            // dtgTicket
            // 
            this.dtgTicket.AllowUserToAddRows = false;
            this.dtgTicket.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dtgTicket.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dtgTicket.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgTicket.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dtgTicket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgTicket.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodigo,
            this.colCantidad,
            this.colProducto,
            this.colPrecioUnit,
            this.colPrecioTotal,
            this.colProductosInventario,
            this.colLigueIngExtra});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgTicket.DefaultCellStyle = dataGridViewCellStyle10;
            this.dtgTicket.Location = new System.Drawing.Point(11, 12);
            this.dtgTicket.Name = "dtgTicket";
            this.dtgTicket.ReadOnly = true;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgTicket.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgTicket.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dtgTicket.Size = new System.Drawing.Size(475, 411);
            this.dtgTicket.TabIndex = 64;
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
            dataGridViewCellStyle9.Format = "N0";
            dataGridViewCellStyle9.NullValue = null;
            this.colCantidad.DefaultCellStyle = dataGridViewCellStyle9;
            this.colCantidad.HeaderText = "Cant.";
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.ReadOnly = true;
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
            // btnObtenerProductos
            // 
            this.btnObtenerProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnObtenerProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnObtenerProductos.Location = new System.Drawing.Point(804, 12);
            this.btnObtenerProductos.Name = "btnObtenerProductos";
            this.btnObtenerProductos.Size = new System.Drawing.Size(150, 62);
            this.btnObtenerProductos.TabIndex = 65;
            this.btnObtenerProductos.Text = "Consultar";
            this.btnObtenerProductos.UseVisualStyleBackColor = true;
            this.btnObtenerProductos.Click += new System.EventHandler(this.btnObtenerProductos_Click);
            // 
            // btnConsultarVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 435);
            this.Controls.Add(this.btnObtenerProductos);
            this.Controls.Add(this.dtgTicket);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCargarVenta);
            this.Controls.Add(this.btnMesasPendientes);
            this.Controls.Add(this.btnTransferir);
            this.Controls.Add(this.btnImprimirPreventa);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCambiarMesa);
            this.Controls.Add(this.tbxNumeroMesa);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "btnConsultarVenta";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Preventas";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnConsultarVenta_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dtgTicket)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxNumeroMesa;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnImprimirPreventa;
        private System.Windows.Forms.Button btnCambiarMesa;
        private System.Windows.Forms.Button btnTransferir;
        private System.Windows.Forms.Button btnMesasPendientes;
        private System.Windows.Forms.Button btnCargarVenta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtgTicket;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecioUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecioTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductosInventario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLigueIngExtra;
        private System.Windows.Forms.Button btnObtenerProductos;
    }
}