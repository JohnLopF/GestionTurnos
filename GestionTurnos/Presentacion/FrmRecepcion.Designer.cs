namespace SistemaTurnos.Presentacion
{
    partial class FrmRecepcion
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
            this.lblTituloRecepcion = new System.Windows.Forms.Label();
            this.gbRegistroCliente = new System.Windows.Forms.GroupBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnGenerarTurno = new System.Windows.Forms.Button();
            this.cmbTramite = new System.Windows.Forms.ComboBox();
            this.lblTramite = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.lblDocumento = new System.Windows.Forms.Label();
            this.dgvTurnosDelDia = new System.Windows.Forms.DataGridView();
            this.lblHistorial = new System.Windows.Forms.Label();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.gbRegistroCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnosDelDia)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTituloRecepcion
            // 
            this.lblTituloRecepcion.AutoSize = true;
            this.lblTituloRecepcion.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTituloRecepcion.Location = new System.Drawing.Point(12, 15);
            this.lblTituloRecepcion.Name = "lblTituloRecepcion";
            this.lblTituloRecepcion.Size = new System.Drawing.Size(288, 32);
            this.lblTituloRecepcion.TabIndex = 0;
            this.lblTituloRecepcion.Text = "RECEPCIÓN DE TURNOS";
            // 
            // gbRegistroCliente
            // 
            this.gbRegistroCliente.Controls.Add(this.btnLimpiar);
            this.gbRegistroCliente.Controls.Add(this.btnGenerarTurno);
            this.gbRegistroCliente.Controls.Add(this.cmbTramite);
            this.gbRegistroCliente.Controls.Add(this.lblTramite);
            this.gbRegistroCliente.Controls.Add(this.txtNombre);
            this.gbRegistroCliente.Controls.Add(this.lblNombre);
            this.gbRegistroCliente.Controls.Add(this.txtDocumento);
            this.gbRegistroCliente.Controls.Add(this.lblDocumento);
            this.gbRegistroCliente.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.gbRegistroCliente.Location = new System.Drawing.Point(18, 65);
            this.gbRegistroCliente.Name = "gbRegistroCliente";
            this.gbRegistroCliente.Size = new System.Drawing.Size(320, 355);
            this.gbRegistroCliente.TabIndex = 1;
            this.gbRegistroCliente.TabStop = false;
            this.gbRegistroCliente.Text = "Datos del Cliente";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(18, 300);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(280, 30);
            this.btnLimpiar.TabIndex = 4;
            this.btnLimpiar.Text = "Limpiar Campos";
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnGenerarTurno
            // 
            this.btnGenerarTurno.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnGenerarTurno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarTurno.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGenerarTurno.ForeColor = System.Drawing.Color.White;
            this.btnGenerarTurno.Location = new System.Drawing.Point(18, 240);
            this.btnGenerarTurno.Name = "btnGenerarTurno";
            this.btnGenerarTurno.Size = new System.Drawing.Size(280, 45);
            this.btnGenerarTurno.TabIndex = 3;
            this.btnGenerarTurno.Text = "GENERAR TICKETS";
            this.btnGenerarTurno.UseVisualStyleBackColor = false;
            this.btnGenerarTurno.Click += new System.EventHandler(this.btnGenerarTurno_Click);
            // 
            // cmbTramite
            // 
            this.cmbTramite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTramite.Location = new System.Drawing.Point(18, 188);
            this.cmbTramite.Name = "cmbTramite";
            this.cmbTramite.Size = new System.Drawing.Size(280, 25);
            this.cmbTramite.TabIndex = 2;
            // 
            // lblTramite
            // 
            this.lblTramite.Location = new System.Drawing.Point(15, 165);
            this.lblTramite.Name = "lblTramite";
            this.lblTramite.Size = new System.Drawing.Size(200, 20);
            this.lblTramite.TabIndex = 5;
            this.lblTramite.Text = "Seleccione Tipo Prioridad:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(18, 123);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(280, 25);
            this.txtNombre.TabIndex = 1;
            // 
            // lblNombre
            // 
            this.lblNombre.Location = new System.Drawing.Point(15, 100);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(200, 20);
            this.lblNombre.TabIndex = 6;
            this.lblNombre.Text = "Nombre Completo:";
            // 
            // txtDocumento
            // 
            this.txtDocumento.Location = new System.Drawing.Point(18, 58);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(280, 25);
            this.txtDocumento.TabIndex = 0;
            // 
            // lblDocumento
            // 
            this.lblDocumento.Location = new System.Drawing.Point(15, 35);
            this.lblDocumento.Name = "lblDocumento";
            this.lblDocumento.Size = new System.Drawing.Size(200, 20);
            this.lblDocumento.TabIndex = 7;
            this.lblDocumento.Text = "Documento de Identidad:";
            // 
            // dgvTurnosDelDia
            // 
            this.dgvTurnosDelDia.AllowUserToAddRows = false;
            this.dgvTurnosDelDia.AllowUserToDeleteRows = false;
            this.dgvTurnosDelDia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTurnosDelDia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTurnosDelDia.Location = new System.Drawing.Point(360, 90);
            this.dgvTurnosDelDia.Name = "dgvTurnosDelDia";
            this.dgvTurnosDelDia.ReadOnly = true;
            this.dgvTurnosDelDia.Size = new System.Drawing.Size(675, 330);
            this.dgvTurnosDelDia.TabIndex = 3;
            // 
            // lblHistorial
            // 
            this.lblHistorial.AutoSize = true;
            this.lblHistorial.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblHistorial.Location = new System.Drawing.Point(360, 65);
            this.lblHistorial.Name = "lblHistorial";
            this.lblHistorial.Size = new System.Drawing.Size(230, 19);
            this.lblHistorial.TabIndex = 2;
            this.lblHistorial.Text = "Últimos Turnos Generados (Hoy):";
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackColor = System.Drawing.Color.IndianRed;
            this.btnLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogOut.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLogOut.ForeColor = System.Drawing.Color.White;
            this.btnLogOut.Location = new System.Drawing.Point(680, 15);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(100, 30);
            this.btnLogOut.TabIndex = 4;
            this.btnLogOut.Text = "Cerrar Sesión";
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // FrmRecepcion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 450);
            this.Controls.Add(this.lblHistorial);
            this.Controls.Add(this.dgvTurnosDelDia);
            this.Controls.Add(this.gbRegistroCliente);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.lblTituloRecepcion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmRecepcion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Turnos - Recepción";
            this.Load += new System.EventHandler(this.FrmRecepcion_Load);
            this.gbRegistroCliente.ResumeLayout(false);
            this.gbRegistroCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnosDelDia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTituloRecepcion;
        private System.Windows.Forms.GroupBox gbRegistroCliente;
        private System.Windows.Forms.Label lblDocumento;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblTramite;
        private System.Windows.Forms.ComboBox cmbTramite;
        private System.Windows.Forms.Button btnGenerarTurno;
        private System.Windows.Forms.DataGridView dgvTurnosDelDia;
        private System.Windows.Forms.Label lblHistorial;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnLimpiar;
    }
}