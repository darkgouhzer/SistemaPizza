namespace Punto_Venta
{
    partial class MesasPendientes
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
            this.dtgMesas = new System.Windows.Forms.DataGridView();
            this.colNumeroMesa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMesas)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgMesas
            // 
            this.dtgMesas.AllowUserToAddRows = false;
            this.dtgMesas.AllowUserToDeleteRows = false;
            this.dtgMesas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgMesas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNumeroMesa});
            this.dtgMesas.Location = new System.Drawing.Point(18, 18);
            this.dtgMesas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtgMesas.Name = "dtgMesas";
            this.dtgMesas.ReadOnly = true;
            this.dtgMesas.Size = new System.Drawing.Size(238, 231);
            this.dtgMesas.TabIndex = 0;
            // 
            // colNumeroMesa
            // 
            this.colNumeroMesa.HeaderText = "Mesas";
            this.colNumeroMesa.Name = "colNumeroMesa";
            this.colNumeroMesa.ReadOnly = true;
            this.colNumeroMesa.Width = 150;
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Location = new System.Drawing.Point(18, 257);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(238, 47);
            this.btnSeleccionar.TabIndex = 1;
            this.btnSeleccionar.Text = "Seleccionar mesa";
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // MesasPendientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 318);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.dtgMesas);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MesasPendientes";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mesas pendientes";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MesasPendientes_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dtgMesas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgMesas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumeroMesa;
        private System.Windows.Forms.Button btnSeleccionar;
    }
}