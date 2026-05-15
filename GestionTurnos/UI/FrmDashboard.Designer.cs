namespace GestionTurnos.UI
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
            this.lblLlamadoPrincipal = new System.Windows.Forms.Label();
            this.lblTurnoGrande = new System.Windows.Forms.Label();
            this.lblModuloGrande = new System.Windows.Forms.Label();
            this.dgvHistorialTurnos = new System.Windows.Forms.DataGridView();
            this.lblHistorialTitulo = new System.Windows.Forms.Label();
            this.timerActualizar = new System.Windows.Forms.Timer(this.components);
            this.lblReloj = new System.Windows.Forms.Label();
            this.lblEmpresa = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialTurnos)).BeginInit();
            this.pnlUltimoTurno.SuspendLayout();
            this.SuspendLayout();

            // 
            // pnlUltimoTurno
            // 
            this.pnlUltimoTurno.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlUltimoTurno.Controls.Add(this.lblModuloGrande);
            this.pnlUltimoTurno.Controls.Add(this.lblTurnoGrande);
            this.pnlUltimoTurno.Controls.Add(this.lblLlamadoPrincipal);
            this.pnlUltimoTurno.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlUltimoTurno.Location = new System.Drawing.Point(0, 0);
            this.pnlUltimoTurno.Name = "pnlUltimoTurno";
            this.pnlUltimoTurno.Size = new System.Drawing.Size(450, 450);

            // lblLlamadoPrincipal
            this.lblLlamadoPrincipal.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblLlamadoPrincipal.ForeColor = System.Drawing.Color.White;
            this.lblLlamadoPrincipal.Location = new System.Drawing.Point(12, 50);
            this.lblLlamadoPrincipal.Size = new System.Drawing.Size(426, 45);
            this.lblLlamadoPrincipal.Text = "TURNO ACTUAL";
            this.lblLlamadoPrincipal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblTurnoGrande (El número del turno)
            this.lblTurnoGrande.Font = new System.Drawing.Font("Segoe UI", 110F, System.Drawing.FontStyle.Bold);
            this.lblTurnoGrande.ForeColor = System.Drawing.Color.Yellow;
            this.lblTurnoGrande.Location = new System.Drawing.Point(12, 110);
            this.lblTurnoGrande.Size = new System.Drawing.Size(426, 200);
            this.lblTurnoGrande.Text = "A01";
            this.lblTurnoGrande.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblModuloGrande (Caja/Asesor)
            this.lblModuloGrande.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold);
            this.lblModuloGrande.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.lblModuloGrande.Location = new System.Drawing.Point(12, 330);
            this.lblModuloGrande.Size = new System.Drawing.Size(426, 65);
            this.lblModuloGrande.Text = "MÓDULO 1";
            this.lblModuloGrande.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblHistorialTitulo
            this.lblHistorialTitulo.AutoSize = true;
            this.lblHistorialTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblHistorialTitulo.Location = new System.Drawing.Point(465, 70);
            this.lblHistorialTitulo.Name = "lblHistorialTitulo";
            this.lblHistorialTitulo.Size = new System.Drawing.Size(185, 25);
            this.lblHistorialTitulo.Text = "ÚLTIMOS LLAMADOS";

            // dgvHistorialTurnos (Lista de turnos anteriores)
            this.dgvHistorialTurnos.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvHistorialTurnos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHistorialTurnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorialTurnos.Location = new System.Drawing.Point(470, 110);
            this.dgvHistorialTurnos.Name = "dgvHistorialTurnos";
            this.dgvHistorialTurnos.ReadOnly = true;
            this.dgvHistorialTurnos.RowHeadersVisible = false;
            this.dgvHistorialTurnos.Size = new System.Drawing.Size(318, 300);

            // lblEmpresa
            this.lblEmpresa.AutoSize = true;
            this.lblEmpresa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic);
            this.lblEmpresa.Location = new System.Drawing.Point(466, 20);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(135, 21);
            this.lblEmpresa.Text = "Sistema de Turnos";

            // lblReloj
            this.lblReloj.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblReloj.Location = new System.Drawing.Point(650, 20);
            this.lblReloj.Size = new System.Drawing.Size(138, 23);
            this.lblReloj.Text = "00:00:00";
            this.lblReloj.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // timerActualizar (Cada 5-10 segundos para refrescar la DB)
            this.timerActualizar.Enabled = true;
            this.timerActualizar.Interval = 5000;

            // FrmDashboard
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblReloj);
            this.Controls.Add(this.lblEmpresa);
            this.Controls.Add(this.lblHistorialTitulo);
            this.Controls.Add(this.dgvHistorialTurnos);
            this.Controls.Add(this.pnlUltimoTurno);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; // Pantalla completa sugerida
            this.Name = "FrmDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Monitor de Turnos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialTurnos)).EndInit();
            this.pnlUltimoTurno.ResumeLayout(false);
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
    }
}