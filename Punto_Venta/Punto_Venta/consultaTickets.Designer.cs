namespace Punto_Venta
{
    partial class consultaTickets
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxTicket = new System.Windows.Forms.TextBox();
            this.dtgVenta = new System.Windows.Forms.DataGridView();
            this.dtgDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.producto_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCancelarTicket = new System.Windows.Forms.Button();
            this.lblCancelacion = new System.Windows.Forms.Label();
            this.btnReimprimir = new System.Windows.Forms.Button();
            this.lblFecha = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.dtgVenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "No. Ticket";
            // 
            // tbxTicket
            // 
            this.tbxTicket.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxTicket.Location = new System.Drawing.Point(109, 22);
            this.tbxTicket.Name = "tbxTicket";
            this.tbxTicket.Size = new System.Drawing.Size(147, 25);
            this.tbxTicket.TabIndex = 1;
            this.tbxTicket.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxTicket_KeyDown);
            this.tbxTicket.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxTicket_KeyPress);
            // 
            // dtgVenta
            // 
            this.dtgVenta.AllowUserToAddRows = false;
            this.dtgVenta.AllowUserToDeleteRows = false;
            this.dtgVenta.BackgroundColor = System.Drawing.Color.White;
            this.dtgVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgVenta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtgDescripcion,
            this.dtgCantidad,
            this.dtgTotal,
            this.producto_id});
            this.dtgVenta.Location = new System.Drawing.Point(27, 53);
            this.dtgVenta.Name = "dtgVenta";
            this.dtgVenta.ReadOnly = true;
            this.dtgVenta.Size = new System.Drawing.Size(589, 302);
            this.dtgVenta.TabIndex = 3;
            // 
            // dtgDescripcion
            // 
            this.dtgDescripcion.HeaderText = "DESCRIPCIÓN";
            this.dtgDescripcion.Name = "dtgDescripcion";
            this.dtgDescripcion.ReadOnly = true;
            this.dtgDescripcion.Width = 300;
            // 
            // dtgCantidad
            // 
            dataGridViewCellStyle3.Format = "N3";
            dataGridViewCellStyle3.NullValue = null;
            this.dtgCantidad.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtgCantidad.HeaderText = "CANTIDAD";
            this.dtgCantidad.Name = "dtgCantidad";
            this.dtgCantidad.ReadOnly = true;
            // 
            // dtgTotal
            // 
            dataGridViewCellStyle4.Format = "C2";
            this.dtgTotal.DefaultCellStyle = dataGridViewCellStyle4;
            this.dtgTotal.HeaderText = "TOTAL";
            this.dtgTotal.Name = "dtgTotal";
            this.dtgTotal.ReadOnly = true;
            // 
            // producto_id
            // 
            this.producto_id.HeaderText = "id_producto";
            this.producto_id.Name = "producto_id";
            this.producto_id.ReadOnly = true;
            this.producto_id.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = global::Punto_Venta.Properties.Resources.search_32;
            this.pictureBox1.Location = new System.Drawing.Point(256, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(29, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // btnCancelarTicket
            // 
            this.btnCancelarTicket.BackColor = System.Drawing.Color.White;
            this.btnCancelarTicket.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelarTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarTicket.Image = global::Punto_Venta.Properties.Resources.tick_32;
            this.btnCancelarTicket.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelarTicket.Location = new System.Drawing.Point(295, 426);
            this.btnCancelarTicket.Name = "btnCancelarTicket";
            this.btnCancelarTicket.Size = new System.Drawing.Size(174, 48);
            this.btnCancelarTicket.TabIndex = 2;
            this.btnCancelarTicket.Text = "Cancelar ticket";
            this.btnCancelarTicket.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelarTicket.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelarTicket.UseVisualStyleBackColor = false;
            this.btnCancelarTicket.Click += new System.EventHandler(this.btnCancelarTicket_Click);
            // 
            // lblCancelacion
            // 
            this.lblCancelacion.AutoSize = true;
            this.lblCancelacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCancelacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCancelacion.ForeColor = System.Drawing.Color.Green;
            this.lblCancelacion.Location = new System.Drawing.Point(465, 23);
            this.lblCancelacion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCancelacion.Name = "lblCancelacion";
            this.lblCancelacion.Size = new System.Drawing.Size(106, 26);
            this.lblCancelacion.TabIndex = 36;
            this.lblCancelacion.Text = "ESTATUS";
            // 
            // btnReimprimir
            // 
            this.btnReimprimir.BackColor = System.Drawing.Color.White;
            this.btnReimprimir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReimprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReimprimir.Image = global::Punto_Venta.Properties.Resources.delete_32;
            this.btnReimprimir.Location = new System.Drawing.Point(498, 426);
            this.btnReimprimir.Name = "btnReimprimir";
            this.btnReimprimir.Size = new System.Drawing.Size(118, 48);
            this.btnReimprimir.TabIndex = 3;
            this.btnReimprimir.Text = "Cerrar";
            this.btnReimprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReimprimir.UseVisualStyleBackColor = false;
            this.btnReimprimir.Click += new System.EventHandler(this.btnReimprimir_Click);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblFecha.Location = new System.Drawing.Point(27, 373);
            this.lblFecha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(64, 20);
            this.lblFecha.TabIndex = 37;
            this.lblFecha.Text = "Fecha:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(399, 373);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 38;
            this.label2.Text = "Total:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTotal.Location = new System.Drawing.Point(461, 373);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(59, 20);
            this.lblTotal.TabIndex = 39;
            this.lblTotal.Text = "$ 0.00";
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // consultaTickets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(646, 486);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblCancelacion);
            this.Controls.Add(this.btnReimprimir);
            this.Controls.Add(this.btnCancelarTicket);
            this.Controls.Add(this.dtgVenta);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tbxTicket);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "consultaTickets";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "consultaTickets";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.consultaTickets_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dtgVenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxTicket;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dtgVenta;
        private System.Windows.Forms.Button btnCancelarTicket;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn producto_id;
        private System.Windows.Forms.Label lblCancelacion;
        private System.Windows.Forms.Button btnReimprimir;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotal;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}