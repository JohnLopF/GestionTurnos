namespace GestionTurnos.UI
{
    partial class FrmLogin
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
            this.lblDocumento = new System.Windows.Forms.Label();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblTramite = new System.Windows.Forms.Label();
            this.cmbTramite = new System.Windows.Forms.ComboBox();
            this.btnGenerarTurno = new System.Windows.Forms.Button();
            this.dgvUltimosTurnos = new System.Windows.Forms.DataGridView();
            this.lblHistorial = new System.Windows.Forms.Label();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvUltimosTurnos)).BeginInit();
            this.gbRegistroCliente.SuspendLayout();
            this.SuspendLayout();

            // 
            // lblTituloRecepcion
            // 
            this.lblTituloRecepcion.AutoSize = true;
            this.lblTituloRecepcion.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTituloRecepcion.Location = new System.Drawing.Point(12, 15);
            this.lblTituloRecepcion.Name = "lblTituloRecepcion";
            this.lblTituloRecepcion.Size = new System.Drawing.Size(285, 32);
            this.lblTituloRecepcion.Text = "RECEPCIÓN DE TURNOS";

            // 
            // btnLogOut
            // 
            this.btnLogOut.Location = new System.Drawing.Point(680, 15);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(100, 30);
            this.btnLogOut.Text = "Cerrar Sesión";

            // GroupBox: Registro
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
            this.gbRegistroCliente.TabStop = false;
            this.gbRegistroCliente.Text = "Datos del Cliente";

            // Documento
            this.lblDocumento.Location = new System.Drawing.Point(15, 35);
            this.lblDocumento.Text = "Documento de Identidad:";
            this.lblDocumento.Size = new System.Drawing.Size(200, 20);

            this.txtDocumento.Location = new System.Drawing.Point(18, 58);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(280, 25);

            // Nombre
            this.lblNombre.Location = new System.Drawing.Point(15, 100);
            this.lblNombre.Text = "Nombre Completo:";
            this.lblNombre.Size = new System.Drawing.Size(200, 20);

            this.txtNombre.Location = new System.Drawing.Point(18, 123);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(280, 25);

            // Trámite
            this.lblTramite.Location = new System.Drawing.Point(15, 165);
            this.lblTramite.Text = "Seleccione el Trámite:";
            this.lblTramite.Size = new System.Drawing.Size(200, 20);

            this.cmbTramite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTramite.Location = new System.Drawing.Point(18, 188);
            this.cmbTramite.Name = "cmbTramite";
            this.cmbTramite.Size = new System.Drawing.Size(280, 25);

            // Botones
            this.btnGenerarTurno.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnGenerarTurno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarTurno.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGenerarTurno.ForeColor = System.Drawing.Color.White;
            this.btnGenerarTurno.Location = new System.Drawing.Point(18, 240);
            this.btnGenerarTurno.Name = "btnGenerarTurno";
            this.btnGenerarTurno.Size = new System.Drawing.Size(280, 45);
            this.btnGenerarTurno.Text = "GENERAR TURNO";
            this.btnGenerarTurno.UseVisualStyleBackColor = false;

            this.btnLimpiar.Location = new System.Drawing.Point(18, 300);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(280, 30);
            this.btnLimpiar.Text = "Limpiar Campos";

            // Historial de turnos generados
            this.lblHistorial.AutoSize = true;
            this.lblHistorial.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblHistorial.Location = new System.Drawing.Point(360, 65);
            this.lblHistorial.Text = "Últimos Turnos Generados (Hoy):";

            this.dgvUltimosTurnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUltimosTurnos.Location = new System.Drawing.Point(360, 90);
            this.dgvUltimosTurnos.Name = "dgvUltimosTurnos";
            this.dgvUltimosTurnos.ReadOnly = true;
            this.dgvUltimosTurnos.Size = new System.Drawing.Size(420, 330);

            // FrmRecepcion Config
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblHistorial);
            this.Controls.Add(this.dgvUltimosTurnos);
            this.Controls.Add(this.gbRegistroCliente);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.lblTituloRecepcion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmRecepcion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Turnos - Recepción";

            ((System.ComponentModel.ISupportInitialize)(this.dgvUltimosTurnos)).EndInit();
            this.gbRegistroCliente.ResumeLayout(false);
            this.gbRegistroCliente.PerformLayout();
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
        private System.Windows.Forms.DataGridView dgvUltimosTurnos;
        private System.Windows.Forms.Label lblHistorial;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnLimpiar;
    }
}