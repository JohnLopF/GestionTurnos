namespace SistemaTurnos.Presentacion
{
    partial class FrmAsesor
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTituloAsesor = new System.Windows.Forms.Label();
            this.lblTurnoActual = new System.Windows.Forms.Label();
            this.lblNumTurno = new System.Windows.Forms.Label();
            this.lblInfoCliente = new System.Windows.Forms.Label();
            this.dgvColaEspera = new System.Windows.Forms.DataGridView();
            this.btnLlamarSiguiente = new System.Windows.Forms.Button();
            this.btnFinalizarTurno = new System.Windows.Forms.Button();
            this.btnNoSePresento = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.lblColaEspera = new System.Windows.Forms.Label();
            this.pnlTurnoActual = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColaEspera)).BeginInit();
            this.pnlTurnoActual.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTituloAsesor
            // 
            this.lblTituloAsesor.AutoSize = true;
            this.lblTituloAsesor.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTituloAsesor.Location = new System.Drawing.Point(12, 15);
            this.lblTituloAsesor.Name = "lblTituloAsesor";
            this.lblTituloAsesor.Size = new System.Drawing.Size(255, 32);
            this.lblTituloAsesor.TabIndex = 0;
            this.lblTituloAsesor.Text = "PANEL DE ATENCIÓN";
            // 
            // lblTurnoActual
            // 
            this.lblTurnoActual.AutoSize = true;
            this.lblTurnoActual.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTurnoActual.Location = new System.Drawing.Point(15, 15);
            this.lblTurnoActual.Name = "lblTurnoActual";
            this.lblTurnoActual.Size = new System.Drawing.Size(140, 21);
            this.lblTurnoActual.TabIndex = 0;
            this.lblTurnoActual.Text = "Turno en Atención:";
            // 
            // lblNumTurno
            // 
            this.lblNumTurno.Font = new System.Drawing.Font("Segoe UI", 42F, System.Drawing.FontStyle.Bold);
            this.lblNumTurno.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblNumTurno.Location = new System.Drawing.Point(15, 45);
            this.lblNumTurno.Name = "lblNumTurno";
            this.lblNumTurno.Size = new System.Drawing.Size(320, 75);
            this.lblNumTurno.TabIndex = 1;
            this.lblNumTurno.Text = "--";
            this.lblNumTurno.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInfoCliente
            // 
            this.lblInfoCliente.AutoSize = true;
            this.lblInfoCliente.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            this.lblInfoCliente.Location = new System.Drawing.Point(15, 140);
            this.lblInfoCliente.Name = "lblInfoCliente";
            this.lblInfoCliente.Size = new System.Drawing.Size(130, 19);
            this.lblInfoCliente.TabIndex = 2;
            this.lblInfoCliente.Text = "Cliente: Sin asignar";
            // 
            // dgvColaEspera
            // 
            this.dgvColaEspera.AllowUserToAddRows = false;
            this.dgvColaEspera.AllowUserToDeleteRows = false;
            this.dgvColaEspera.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvColaEspera.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvColaEspera.Location = new System.Drawing.Point(400, 95);
            this.dgvColaEspera.MultiSelect = false;
            this.dgvColaEspera.Name = "dgvColaEspera";
            this.dgvColaEspera.ReadOnly = true;
            this.dgvColaEspera.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvColaEspera.Size = new System.Drawing.Size(727, 325);
            this.dgvColaEspera.TabIndex = 7;
            // 
            // btnLlamarSiguiente
            // 
            this.btnLlamarSiguiente.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnLlamarSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLlamarSiguiente.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLlamarSiguiente.ForeColor = System.Drawing.Color.White;
            this.btnLlamarSiguiente.Location = new System.Drawing.Point(18, 270);
            this.btnLlamarSiguiente.Name = "btnLlamarSiguiente";
            this.btnLlamarSiguiente.Size = new System.Drawing.Size(350, 45);
            this.btnLlamarSiguiente.TabIndex = 1;
            this.btnLlamarSiguiente.Text = "LLAMAR SIGUIENTE TURNO";
            this.btnLlamarSiguiente.UseVisualStyleBackColor = false;
            this.btnLlamarSiguiente.Click += new System.EventHandler(this.btnLlamarSiguiente_Click);
            // 
            // btnFinalizarTurno
            // 
            this.btnFinalizarTurno.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnFinalizarTurno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinalizarTurno.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnFinalizarTurno.ForeColor = System.Drawing.Color.White;
            this.btnFinalizarTurno.Location = new System.Drawing.Point(18, 325);
            this.btnFinalizarTurno.Name = "btnFinalizarTurno";
            this.btnFinalizarTurno.Size = new System.Drawing.Size(170, 40);
            this.btnFinalizarTurno.TabIndex = 2;
            this.btnFinalizarTurno.Text = "Finalizar Atención";
            this.btnFinalizarTurno.UseVisualStyleBackColor = false;
            this.btnFinalizarTurno.Click += new System.EventHandler(this.btnFinalizarTurno_Click);
            // 
            // btnNoSePresento
            // 
            this.btnNoSePresento.BackColor = System.Drawing.Color.Tomato;
            this.btnNoSePresento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNoSePresento.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnNoSePresento.ForeColor = System.Drawing.Color.White;
            this.btnNoSePresento.Location = new System.Drawing.Point(198, 325);
            this.btnNoSePresento.Name = "btnNoSePresento";
            this.btnNoSePresento.Size = new System.Drawing.Size(170, 40);
            this.btnNoSePresento.TabIndex = 3;
            this.btnNoSePresento.Text = "No se presentó";
            this.btnNoSePresento.UseVisualStyleBackColor = false;
            this.btnNoSePresento.Click += new System.EventHandler(this.btnNoSePresento_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackColor = System.Drawing.Color.LightGray;
            this.btnLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogOut.Location = new System.Drawing.Point(680, 15);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(100, 30);
            this.btnLogOut.TabIndex = 4;
            this.btnLogOut.Text = "Cerrar Sesión";
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // lblColaEspera
            // 
            this.lblColaEspera.AutoSize = true;
            this.lblColaEspera.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblColaEspera.Location = new System.Drawing.Point(400, 70);
            this.lblColaEspera.Name = "lblColaEspera";
            this.lblColaEspera.Size = new System.Drawing.Size(194, 19);
            this.lblColaEspera.TabIndex = 6;
            this.lblColaEspera.Text = "Cola de Espera (Siguientes):";
            // 
            // pnlTurnoActual
            // 
            this.pnlTurnoActual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTurnoActual.Controls.Add(this.lblNumTurno);
            this.pnlTurnoActual.Controls.Add(this.lblTurnoActual);
            this.pnlTurnoActual.Controls.Add(this.lblInfoCliente);
            this.pnlTurnoActual.Location = new System.Drawing.Point(18, 70);
            this.pnlTurnoActual.Name = "pnlTurnoActual";
            this.pnlTurnoActual.Size = new System.Drawing.Size(350, 180);
            this.pnlTurnoActual.TabIndex = 5;
            // 
            // FrmAsesor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 450);
            this.Controls.Add(this.lblColaEspera);
            this.Controls.Add(this.dgvColaEspera);
            this.Controls.Add(this.btnNoSePresento);
            this.Controls.Add(this.btnFinalizarTurno);
            this.Controls.Add(this.btnLlamarSiguiente);
            this.Controls.Add(this.pnlTurnoActual);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.lblTituloAsesor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmAsesor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Turnos - Panel del Asesor";
            this.Load += new System.EventHandler(this.FrmAsesor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvColaEspera)).EndInit();
            this.pnlTurnoActual.ResumeLayout(false);
            this.pnlTurnoActual.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTituloAsesor;
        private System.Windows.Forms.Label lblTurnoActual;
        private System.Windows.Forms.Label lblNumTurno;
        private System.Windows.Forms.Label lblInfoCliente;
        private System.Windows.Forms.DataGridView dgvColaEspera;
        private System.Windows.Forms.Button btnLlamarSiguiente;
        private System.Windows.Forms.Button btnFinalizarTurno;
        private System.Windows.Forms.Button btnNoSePresento;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Label lblColaEspera;
        private System.Windows.Forms.Panel pnlTurnoActual;
    }
}