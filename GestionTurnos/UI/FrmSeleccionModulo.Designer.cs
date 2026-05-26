namespace SistemaTurnos.Presentacion
{
    partial class FrmSeleccionModulo
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
            this.lblInstruccion = new System.Windows.Forms.Label();
            this.cmbModulos = new System.Windows.Forms.ComboBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblInstruccion
            this.lblInstruccion.AutoSize = true;
            this.lblInstruccion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular);
            this.lblInstruccion.Location = new System.Drawing.Point(30, 30);
            this.lblInstruccion.Text = "Seleccione su módulo de trabajo:";
            this.lblInstruccion.Size = new System.Drawing.Size(240, 21);

            // cmbModulos
            this.cmbModulos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModulos.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbModulos.FormattingEnabled = true;
            this.cmbModulos.Location = new System.Drawing.Point(34, 70);
            this.cmbModulos.Size = new System.Drawing.Size(250, 30);

            // btnConfirmar
            this.btnConfirmar.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.ForeColor = System.Drawing.Color.White;
            this.btnConfirmar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnConfirmar.Location = new System.Drawing.Point(34, 120);
            this.btnConfirmar.Size = new System.Drawing.Size(250, 40);
            this.btnConfirmar.Text = "INICIAR JORNADA";
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);

            // FrmSeleccionModulo
            this.ClientSize = new System.Drawing.Size(320, 190);
            this.Controls.Add(this.lblInstruccion);
            this.Controls.Add(this.cmbModulos);
            this.Controls.Add(this.btnConfirmar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selección de Puesto";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblInstruccion;
        private System.Windows.Forms.ComboBox cmbModulos;
        private System.Windows.Forms.Button btnConfirmar;

        #endregion
    }
}