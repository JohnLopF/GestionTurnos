namespace SistemaTurnos.Presentacion
{
    partial class FrmAdmin
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
            this.tabControlAdmin = new System.Windows.Forms.TabControl();
            this.tabUsuarios = new System.Windows.Forms.TabPage();
            this.lblTablasCrud = new System.Windows.Forms.Label();
            this.cmbTablasCrud = new System.Windows.Forms.ComboBox();
            this.lblRol = new System.Windows.Forms.Label();
            this.lblPass = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblNom = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.cmbRoles = new System.Windows.Forms.ComboBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtNombreCompleto = new System.Windows.Forms.TextBox();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.tabReportes = new System.Windows.Forms.TabPage();
            this.lblFiltroFechas = new System.Windows.Forms.Label();
            this.dgvReportes = new System.Windows.Forms.DataGridView();
            this.btnGenerarReporte = new System.Windows.Forms.Button();
            this.dtpFin = new System.Windows.Forms.DateTimePicker();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.tabControlAdmin.SuspendLayout();
            this.tabUsuarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.tabReportes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportes)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlAdmin
            // 
            this.tabControlAdmin.Controls.Add(this.tabUsuarios);
            this.tabControlAdmin.Controls.Add(this.tabReportes);
            this.tabControlAdmin.Location = new System.Drawing.Point(12, 60);
            this.tabControlAdmin.Name = "tabControlAdmin";
            this.tabControlAdmin.SelectedIndex = 0;
            this.tabControlAdmin.Size = new System.Drawing.Size(776, 378);
            this.tabControlAdmin.TabIndex = 0;
            // 
            // tabUsuarios
            // 
            this.tabUsuarios.Controls.Add(this.lblTablasCrud);
            this.tabUsuarios.Controls.Add(this.cmbTablasCrud);
            this.tabUsuarios.Controls.Add(this.lblRol);
            this.tabUsuarios.Controls.Add(this.lblPass);
            this.tabUsuarios.Controls.Add(this.lblUser);
            this.tabUsuarios.Controls.Add(this.lblNom);
            this.tabUsuarios.Controls.Add(this.btnEliminar);
            this.tabUsuarios.Controls.Add(this.btnGuardar);
            this.tabUsuarios.Controls.Add(this.cmbRoles);
            this.tabUsuarios.Controls.Add(this.txtPassword);
            this.tabUsuarios.Controls.Add(this.txtUsername);
            this.tabUsuarios.Controls.Add(this.txtNombreCompleto);
            this.tabUsuarios.Controls.Add(this.dgvUsuarios);
            this.tabUsuarios.Location = new System.Drawing.Point(4, 22);
            this.tabUsuarios.Name = "tabUsuarios";
            this.tabUsuarios.Size = new System.Drawing.Size(768, 352);
            this.tabUsuarios.TabIndex = 0;
            this.tabUsuarios.Text = "Configuración Global Entidades (CRUDs)";
            this.tabUsuarios.UseVisualStyleBackColor = true;
            // 
            // lblTablasCrud
            // 
            this.lblTablasCrud.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTablasCrud.Location = new System.Drawing.Point(20, 10);
            this.lblTablasCrud.Name = "lblTablasCrud";
            this.lblTablasCrud.Size = new System.Drawing.Size(205, 18);
            this.lblTablasCrud.TabIndex = 12;
            this.lblTablasCrud.Text = "Entidad a Administrar:";
            // 
            // cmbTablasCrud
            // 
            this.cmbTablasCrud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTablasCrud.FormattingEnabled = true;
            this.cmbTablasCrud.Location = new System.Drawing.Point(20, 28);
            this.cmbTablasCrud.Name = "cmbTablasCrud";
            this.cmbTablasCrud.Size = new System.Drawing.Size(205, 21);
            this.cmbTablasCrud.TabIndex = 11;
            // 
            // lblRol
            // 
            this.lblRol.Location = new System.Drawing.Point(20, 220);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(100, 18);
            this.lblRol.TabIndex = 0;
            this.lblRol.Text = "Rol / Propiedad:";
            // 
            // lblPass
            // 
            this.lblPass.Location = new System.Drawing.Point(20, 170);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(100, 18);
            this.lblPass.TabIndex = 1;
            this.lblPass.Text = "Contraseña / Token:";
            // 
            // lblUser
            // 
            this.lblUser.Location = new System.Drawing.Point(20, 118);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(100, 18);
            this.lblUser.TabIndex = 2;
            this.lblUser.Text = "Identificador / Código:";
            // 
            // lblNom
            // 
            this.lblNom.Location = new System.Drawing.Point(20, 65);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(120, 18);
            this.lblNom.TabIndex = 3;
            this.lblNom.Text = "Nombre descriptivo:";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(150, 290);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.Text = "Desactivar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(20, 290);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // cmbRoles
            // 
            this.cmbRoles.Location = new System.Drawing.Point(20, 238);
            this.cmbRoles.Name = "cmbRoles";
            this.cmbRoles.Size = new System.Drawing.Size(205, 21);
            this.cmbRoles.TabIndex = 6;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(20, 188);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(205, 20);
            this.txtPassword.TabIndex = 7;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(20, 136);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(205, 20);
            this.txtUsername.TabIndex = 8;
            // 
            // txtNombreCompleto
            // 
            this.txtNombreCompleto.Location = new System.Drawing.Point(20, 83);
            this.txtNombreCompleto.Name = "txtNombreCompleto";
            this.txtNombreCompleto.Size = new System.Drawing.Size(205, 20);
            this.txtNombreCompleto.TabIndex = 9;
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsuarios.Location = new System.Drawing.Point(250, 20);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.Size = new System.Drawing.Size(500, 310);
            this.dgvUsuarios.TabIndex = 10;
            this.dgvUsuarios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuarios_CellClick);
            // 
            // tabReportes
            // 
            this.tabReportes.Controls.Add(this.lblFiltroFechas);
            this.tabReportes.Controls.Add(this.dgvReportes);
            this.tabReportes.Controls.Add(this.btnGenerarReporte);
            this.tabReportes.Controls.Add(this.dtpFin);
            this.tabReportes.Controls.Add(this.dtpInicio);
            this.tabReportes.Location = new System.Drawing.Point(4, 22);
            this.tabReportes.Name = "tabReportes";
            this.tabReportes.Size = new System.Drawing.Size(768, 352);
            this.tabReportes.TabIndex = 1;
            this.tabReportes.Text = "Reportes Avanzados de Operación";
            this.tabReportes.UseVisualStyleBackColor = true;
            // 
            // lblFiltroFechas
            // 
            this.lblFiltroFechas.Location = new System.Drawing.Point(19, 6);
            this.lblFiltroFechas.Name = "lblFiltroFechas";
            this.lblFiltroFechas.Size = new System.Drawing.Size(100, 20);
            this.lblFiltroFechas.TabIndex = 6;
            this.lblFiltroFechas.Text = "Rango de Búsqueda:";
            // 
            // dgvReportes
            // 
            this.dgvReportes.AllowUserToAddRows = false;
            this.dgvReportes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReportes.Location = new System.Drawing.Point(19, 42);
            this.dgvReportes.Name = "dgvReportes";
            this.dgvReportes.ReadOnly = true;
            this.dgvReportes.Size = new System.Drawing.Size(730, 288);
            this.dgvReportes.TabIndex = 2;
            // 
            // btnGenerarReporte
            // 
            this.btnGenerarReporte.Location = new System.Drawing.Point(564, 3);
            this.btnGenerarReporte.Name = "btnGenerarReporte";
            this.btnGenerarReporte.Size = new System.Drawing.Size(110, 23);
            this.btnGenerarReporte.TabIndex = 3;
            this.btnGenerarReporte.Text = "Filtrar Flujo Diario";
            this.btnGenerarReporte.Click += new System.EventHandler(this.btnGenerarReporte_Click);
            // 
            // dtpFin
            // 
            this.dtpFin.Location = new System.Drawing.Point(345, 4);
            this.dtpFin.Name = "dtpFin";
            this.dtpFin.Size = new System.Drawing.Size(200, 20);
            this.dtpFin.TabIndex = 4;
            // 
            // dtpInicio
            // 
            this.dtpInicio.Location = new System.Drawing.Point(130, 4);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(200, 20);
            this.dtpInicio.TabIndex = 5;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(12, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(400, 35);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "PANEL DE CONTROL DIRECTIVO SOLID";
            // 
            // btnLogOut
            // 
            this.btnLogOut.Location = new System.Drawing.Point(680, 15);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(100, 23);
            this.btnLogOut.TabIndex = 0;
            this.btnLogOut.Text = "Salir del Sistema";
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // FrmAdmin
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.tabControlAdmin);
            this.Name = "FrmAdmin";
            this.Text = "Módulo de Administración General - Sistema de Turnos";
            this.Load += new System.EventHandler(this.FrmAdmin_Load);
            this.tabControlAdmin.ResumeLayout(false);
            this.tabUsuarios.ResumeLayout(false);
            this.tabUsuarios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.tabReportes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportes)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControlAdmin;
        private System.Windows.Forms.TabPage tabUsuarios;
        private System.Windows.Forms.TabPage tabReportes;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.TextBox txtNombreCompleto;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.ComboBox cmbRoles;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.DateTimePicker dtpFin;
        private System.Windows.Forms.Button btnGenerarReporte;
        private System.Windows.Forms.DataGridView dgvReportes;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.Label lblTablasCrud;
        private System.Windows.Forms.ComboBox cmbTablasCrud;
        private System.Windows.Forms.Label lblFiltroFechas;
    }
}