namespace SistemaTurnos.UI
{
    partial class FrmDashboard
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
            this.components = new System.ComponentModel.Container();
            this.pnlUltimoTurno = new System.Windows.Forms.Panel();
            this.lblTiempoEspera = new System.Windows.Forms.Label(); // NUEVA ETIQUETA
            this.lblModuloGrande = new System.Windows.Forms.Label();
            this.lblTurnoGrande = new System.Windows.Forms.Label();
            this.lblLlamadoPrincipal = new System.Windows.Forms.Label();
            this.dgvHistorialTurnos = new System.Windows.Forms.DataGridView();
            this.lblHistorialTitulo = new System.Windows.Forms.Label();
            this.timerActualizar = new System.Windows.Forms.Timer(this.components);
            this.lblReloj = new System.Windows.Forms.Label();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.pnlUltimoTurno.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialTurnos)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlUltimoTurno
            // 
            this.pnlUltimoTurno.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlUltimoTurno.Controls.Add(this.lblTiempoEspera); // Agregado al contenedor
            this.pnlUltimoTurno.Controls.Add(this.lblModuloGrande);
            this.pnlUltimoTurno.Controls.Add(this.lblTurnoGrande);
            this.pnlUltimoTurno.Controls.Add(this.lblLlamadoPrincipal);
            this.pnlUltimoTurno.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlUltimoTurno.Location = new System.Drawing.Point(0, 0);
            this.pnlUltimoTurno.Name = "pnlUltimoTurno";
            this.pnlUltimoTurno.Size = new System.Drawing.Size(450, 450);
            this.pnlUltimoTurno.TabIndex = 0;
            // 
            // lblTiempoEspera
            // 
            this.lblTiempoEspera.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Italic);
            this.lblTiempoEspera.ForeColor = System.Drawing.Color.DarkGray;
            this.lblTiempoEspera.Location = new System.Drawing.Point(12, 400);
            this.lblTiempoEspera.Name = "lblTiempoEspera";
            this.lblTiempoEspera.Size = new System.Drawing.Size(426, 35);
            this.lblTiempoEspera.TabIndex = 3;
            this.lblTiempoEspera.Text = "Espera aprox: -- min";
            this.lblTiempoEspera.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblModuloGrande
            // 
            this.lblModuloGrande.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold);
            this.lblModuloGrande.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.lblModuloGrande.Location = new System.Drawing.Point(12, 320);
            this.lblModuloGrande.Name = "lblModuloGrande";
            this.lblModuloGrande.Size = new System.Drawing.Size(426, 65);
            this.lblModuloGrande.TabIndex = 2;
            this.lblModuloGrande.Text = "MÓDULO 1";
            this.lblModuloGrande.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTurnoGrande
            // 
            this.lblTurnoGrande.Font = new System.Drawing.Font("Segoe UI", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTurnoGrande.ForeColor = System.Drawing.Color.Yellow;
            this.lblTurnoGrande.Location = new System.Drawing.Point(12, 110);
            this.lblTurnoGrande.Name = "lblTurnoGrande";
            this.lblTurnoGrande.Size = new System.Drawing.Size(426, 200);
            this.lblTurnoGrande.TabIndex = 1;
            this.lblTurnoGrande.Text = "--";
            this.lblTurnoGrande.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLlamadoPrincipal
            // 
            this.lblLlamadoPrincipal.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblLlamadoPrincipal.ForeColor = System.Drawing.Color.White;
            this.lblLlamadoPrincipal.Location = new System.Drawing.Point(12, 50);
            this.lblLlamadoPrincipal.Name = "lblLlamadoPrincipal";
            this.lblLlamadoPrincipal.Size = new System.Drawing.Size(426, 45);
            this.lblLlamadoPrincipal.TabIndex = 0;
            this.lblLlamadoPrincipal.Text = "TURNO ACTUAL";
            this.lblLlamadoPrincipal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvHistorialTurnos
            // 
            this.dgvHistorialTurnos.AllowUserToAddRows = false;
            this.dgvHistorialTurnos.AllowUserToDeleteRows = false;
            this.dgvHistorialTurnos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistorialTurnos.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvHistorialTurnos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHistorialTurnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorialTurnos.Location = new System.Drawing.Point(470, 110);
            this.dgvHistorialTurnos.Name = "dgvHistorialTurnos";
            this.dgvHistorialTurnos.ReadOnly = true;
            this.dgvHistorialTurnos.RowHeadersVisible = false;
            this.dgvHistorialTurnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistorialTurnos.Size = new System.Drawing.Size(318, 300);
            this.dgvHistorialTurnos.TabIndex = 1;
            // 
            // lblHistorialTitulo
            // 
            this.lblHistorialTitulo.AutoSize = true;
            this.lblHistorialTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblHistorialTitulo.Location = new System.Drawing.Point(465, 70);
            this.lblHistorialTitulo.Name = "lblHistorialTitulo";
            this.lblHistorialTitulo.Size = new System.Drawing.Size(203, 25);
            this.lblHistorialTitulo.TabIndex = 2;
            this.lblHistorialTitulo.Text = "ÚLTIMOS LLAMADOS";
            // 
            // timerActualizar
            // 
            this.timerActualizar.Enabled = true;
            this.timerActualizar.Interval = 5000;
            this.timerActualizar.Tick += new System.EventHandler(this.timerActualizar_Tick);
            // 
            // lblReloj
            // 
            this.lblReloj.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblReloj.Location = new System.Drawing.Point(650, 20);
            this.lblReloj.Name = "lblReloj";
            this.lblReloj.Size = new System.Drawing.Size(138, 23);
            this.lblReloj.TabIndex = 4;
            this.lblReloj.Text = "00:00:00";
            this.lblReloj.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.AutoSize = true;
            this.lblEmpresa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic);
            this.lblEmpresa.Location = new System.Drawing.Point(466, 20);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(136, 21);
            this.lblEmpresa.TabIndex = 3;
            this.lblEmpresa.Text = "Sistema de Turnos";
            // 
            // FrmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblReloj);
            this.Controls.Add(this.lblEmpresa);
            this.Controls.Add(this.lblHistorialTitulo);
            this.Controls.Add(this.dgvHistorialTurnos);
            this.Controls.Add(this.pnlUltimoTurno);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Monitor de Turnos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmDashboard_Load);
            this.pnlUltimoTurno.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialTurnos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlUltimoTurno;
        private System.Windows.Forms.Label lblLlamadoPrincipal;
        private System.Windows.Forms.Label lblTurnoGrande;
        private System.Windows.Forms.Label lblModuloGrande;
        private System.Windows.Forms.DataGridView dgvHistorialTurnos;
        private System.Windows.Forms.Label lblHistorialTitulo;
        private System.Windows.Forms.Timer timerActualizar;
        private System.Windows.Forms.Label lblReloj;
        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.Label lblTiempoEspera; // DECLARACIÓN DE LA NUEVA ETIQUETA
    }
}