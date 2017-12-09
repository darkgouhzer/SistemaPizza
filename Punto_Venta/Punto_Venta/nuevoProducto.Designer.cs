namespace Punto_Venta
{
    partial class nuevoProducto
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
            this.tbxCodigoBarras = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxDescripcion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxCosto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxPrecio = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxCantidad = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxDepto = new System.Windows.Forms.ComboBox();
            this.btnDeptoMas = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnProv = new System.Windows.Forms.Button();
            this.cbxProveedor = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.openImagen = new System.Windows.Forms.OpenFileDialog();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbxCodigoBarras
            // 
            this.tbxCodigoBarras.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxCodigoBarras.Location = new System.Drawing.Point(152, 24);
            this.tbxCodigoBarras.Name = "tbxCodigoBarras";
            this.tbxCodigoBarras.Size = new System.Drawing.Size(230, 26);
            this.tbxCodigoBarras.TabIndex = 0;
            this.tbxCodigoBarras.Leave += new System.EventHandler(this.tbxCodigoBarras_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Codigo de barras:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(48, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Descripción:";
            // 
            // tbxDescripcion
            // 
            this.tbxDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxDescripcion.Location = new System.Drawing.Point(152, 53);
            this.tbxDescripcion.Name = "tbxDescripcion";
            this.tbxDescripcion.Size = new System.Drawing.Size(230, 26);
            this.tbxDescripcion.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Existencia inicial:";
            // 
            // tbxCosto
            // 
            this.tbxCosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxCosto.Location = new System.Drawing.Point(151, 148);
            this.tbxCosto.Name = "tbxCosto";
            this.tbxCosto.Size = new System.Drawing.Size(93, 26);
            this.tbxCosto.TabIndex = 4;
            this.tbxCosto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxCosto_KeyDown);
            this.tbxCosto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxCosto_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(88, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Costo:";
            // 
            // tbxPrecio
            // 
            this.tbxPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxPrecio.Location = new System.Drawing.Point(151, 177);
            this.tbxPrecio.Name = "tbxPrecio";
            this.tbxPrecio.Size = new System.Drawing.Size(94, 26);
            this.tbxPrecio.TabIndex = 5;
            this.tbxPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxPrecio_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(86, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Precio:";
            // 
            // tbxCantidad
            // 
            this.tbxCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxCantidad.Location = new System.Drawing.Point(151, 206);
            this.tbxCantidad.Name = "tbxCantidad";
            this.tbxCantidad.Size = new System.Drawing.Size(94, 26);
            this.tbxCantidad.TabIndex = 6;
            this.tbxCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxCantidad_KeyPress);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelar.Image = global::Punto_Venta.Properties.Resources.delete_16;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.Location = new System.Drawing.Point(258, 250);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 28);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cerrar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.White;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAceptar.Image = global::Punto_Venta.Properties.Resources.accept24;
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.Location = new System.Drawing.Point(150, 250);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(100, 28);
            this.btnAceptar.TabIndex = 7;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(28, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Departamento:";
            // 
            // cbxDepto
            // 
            this.cbxDepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDepto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxDepto.FormattingEnabled = true;
            this.cbxDepto.Location = new System.Drawing.Point(151, 82);
            this.cbxDepto.Name = "cbxDepto";
            this.cbxDepto.Size = new System.Drawing.Size(191, 28);
            this.cbxDepto.TabIndex = 2;
            // 
            // btnDeptoMas
            // 
            this.btnDeptoMas.BackColor = System.Drawing.Color.White;
            this.btnDeptoMas.BackgroundImage = global::Punto_Venta.Properties.Resources.add24;
            this.btnDeptoMas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDeptoMas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDeptoMas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeptoMas.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDeptoMas.Location = new System.Drawing.Point(349, 81);
            this.btnDeptoMas.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeptoMas.Name = "btnDeptoMas";
            this.btnDeptoMas.Size = new System.Drawing.Size(34, 28);
            this.btnDeptoMas.TabIndex = 15;
            this.btnDeptoMas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeptoMas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeptoMas.UseVisualStyleBackColor = false;
            this.btnDeptoMas.Click += new System.EventHandler(this.btnDeptoMas_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.btnProv);
            this.panel2.Controls.Add(this.cbxProveedor);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.tbxCantidad);
            this.panel2.Controls.Add(this.btnCancelar);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.btnAceptar);
            this.panel2.Controls.Add(this.tbxPrecio);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.tbxCosto);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.tbxCodigoBarras);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnDeptoMas);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cbxDepto);
            this.panel2.Controls.Add(this.tbxDescripcion);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(400, 290);
            this.panel2.TabIndex = 17;
            // 
            // btnProv
            // 
            this.btnProv.BackColor = System.Drawing.Color.White;
            this.btnProv.BackgroundImage = global::Punto_Venta.Properties.Resources.add24;
            this.btnProv.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProv.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnProv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProv.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProv.Location = new System.Drawing.Point(349, 117);
            this.btnProv.Margin = new System.Windows.Forms.Padding(4);
            this.btnProv.Name = "btnProv";
            this.btnProv.Size = new System.Drawing.Size(34, 28);
            this.btnProv.TabIndex = 18;
            this.btnProv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProv.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProv.UseVisualStyleBackColor = false;
            this.btnProv.Click += new System.EventHandler(this.btnProv_Click);
            // 
            // cbxProveedor
            // 
            this.cbxProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxProveedor.FormattingEnabled = true;
            this.cbxProveedor.Location = new System.Drawing.Point(151, 114);
            this.cbxProveedor.Name = "cbxProveedor";
            this.cbxProveedor.Size = new System.Drawing.Size(191, 28);
            this.cbxProveedor.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(59, 117);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 20);
            this.label7.TabIndex = 16;
            this.label7.Text = "Proveedor:";
            // 
            // openImagen
            // 
            this.openImagen.FileName = "openImagen";
            // 
            // nuevoProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(400, 290);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "nuevoProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nuevo producto";
            this.Activated += new System.EventHandler(this.nuevoProducto_Activated);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbxCodigoBarras;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxDescripcion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxCosto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxPrecio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxCantidad;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxDepto;
        private System.Windows.Forms.Button btnDeptoMas;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnProv;
        private System.Windows.Forms.ComboBox cbxProveedor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.OpenFileDialog openImagen;
    }
}