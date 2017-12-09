namespace Punto_Venta
{
    partial class EntradaSalidaEfectivo
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
            this.rbnEntrada = new System.Windows.Forms.RadioButton();
            this.rbnSalida = new System.Windows.Forms.RadioButton();
            this.tbxCantidad = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxComentario = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbnEntrada
            // 
            this.rbnEntrada.AutoSize = true;
            this.rbnEntrada.Checked = true;
            this.rbnEntrada.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbnEntrada.Location = new System.Drawing.Point(22, 19);
            this.rbnEntrada.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbnEntrada.Name = "rbnEntrada";
            this.rbnEntrada.Size = new System.Drawing.Size(100, 28);
            this.rbnEntrada.TabIndex = 0;
            this.rbnEntrada.TabStop = true;
            this.rbnEntrada.Text = "Entrada";
            this.rbnEntrada.UseVisualStyleBackColor = true;
            // 
            // rbnSalida
            // 
            this.rbnSalida.AutoSize = true;
            this.rbnSalida.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbnSalida.Location = new System.Drawing.Point(22, 57);
            this.rbnSalida.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbnSalida.Name = "rbnSalida";
            this.rbnSalida.Size = new System.Drawing.Size(85, 28);
            this.rbnSalida.TabIndex = 1;
            this.rbnSalida.Text = "Salida";
            this.rbnSalida.UseVisualStyleBackColor = true;
            // 
            // tbxCantidad
            // 
            this.tbxCantidad.Location = new System.Drawing.Point(341, 56);
            this.tbxCantidad.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbxCantidad.MaxLength = 6;
            this.tbxCantidad.Name = "tbxCantidad";
            this.tbxCantidad.Size = new System.Drawing.Size(148, 29);
            this.tbxCantidad.TabIndex = 2;
            this.tbxCantidad.Text = "0.00";
            this.tbxCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxCantidad_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(228, 59);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "Cantidad:";
            // 
            // tbxComentario
            // 
            this.tbxComentario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxComentario.Location = new System.Drawing.Point(22, 149);
            this.tbxComentario.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbxComentario.MaxLength = 100;
            this.tbxComentario.Multiline = true;
            this.tbxComentario.Name = "tbxComentario";
            this.tbxComentario.Size = new System.Drawing.Size(514, 81);
            this.tbxComentario.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 119);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 24);
            this.label2.TabIndex = 7;
            this.label2.Text = "Comentarios:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.btnAceptar);
            this.panel1.Controls.Add(this.tbxComentario);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.rbnEntrada);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.rbnSalida);
            this.panel1.Controls.Add(this.tbxCantidad);
            this.panel1.Location = new System.Drawing.Point(-1, -2);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(591, 371);
            this.panel1.TabIndex = 6;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelar.Image = global::Punto_Venta.Properties.Resources.delete_32;
            this.btnCancelar.Location = new System.Drawing.Point(384, 245);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(7, 10, 7, 10);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(152, 55);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.White;
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAceptar.Image = global::Punto_Venta.Properties.Resources.tick_32;
            this.btnAceptar.Location = new System.Drawing.Point(218, 245);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(7, 10, 7, 10);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(152, 55);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // EntradaSalidaEfectivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(590, 367);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EntradaSalidaEfectivo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entrada y salida de efectivo";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EntradaSalidaEfectivo_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rbnEntrada;
        private System.Windows.Forms.RadioButton rbnSalida;
        private System.Windows.Forms.TextBox tbxCantidad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxComentario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}