namespace GestionTurnos
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
            this.tabReportes = new System.Windows.Forms.TabPage();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.txtNombreCompleto = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.cmbRoles = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpFin = new System.Windows.Forms.DateTimePicker();
            this.btnGenerarReporte = new System.Windows.Forms.Button();
            this.dgvReportes = new System.Windows.Forms.DataGridView();
            this.lblNom = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblPass = new System.Windows.Forms.Label();
            this.lblRol = new System.Windows.Forms.Label();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.lblFechaFin = new System.Windows.Forms.Label();

            this.tabControlAdmin.SuspendLayout();
            this.tabUsuarios.SuspendLayout();
            this.tabReportes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
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
            this.tabUsuarios.Padding = new System.Windows.Forms.Padding(3);
            this.tabUsuarios.Size = new System.Drawing.Size(768, 352);
            this.tabUsuarios.TabIndex = 0;
            this.tabUsuarios.Text = "Gestión de Usuarios";
            this.tabUsuarios.UseVisualStyleBackColor = true;

            // Labels e Inputs de Usuarios
            this.lblNom.Location = new System.Drawing.Point(20, 20);
            this.lblNom.Text = "Nombre Completo:";
            this.lblNom.Size = new System.Drawing.Size(150, 15);

            this.txtNombreCompleto.Location = new System.Drawing.Point(20, 38);
            this.txtNombreCompleto.Name = "txtNombreCompleto";
            this.txtNombreCompleto.Size = new System.Drawing.Size(250, 25);

            this.lblUser.Location = new System.Drawing.Point(20, 75);
            this.lblUser.Text = "Usuario de Red:";
            this.lblUser.Size = new System.Drawing.Size(150, 15);

            this.txtUsername.Location = new System.Drawing.Point(20, 93);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(250, 25);

            this.lblPass.Location = new System.Drawing.Point(20, 130);
            this.lblPass.Text = "Contraseña:";
            this.lblPass.Size = new System.Drawing.Size(150, 15);

            this.txtPassword.Location = new System.Drawing.Point(20, 148);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(250, 25);

            this.lblRol.Location = new System.Drawing.Point(20, 185);
            this.lblRol.Text = "Rol Asignado:";
            this.lblRol.Size = new System.Drawing.Size(150, 15);

            this.cmbRoles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoles.Location = new System.Drawing.Point(20, 203);
            this.cmbRoles.Name = "cmbRoles";
            this.cmbRoles.Size = new System.Drawing.Size(250, 25);

            // Botones
            this.btnGuardar.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(20, 250);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(120, 40);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;


            this.btnEliminar.BackColor = System.Drawing.Color.Tomato;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(150, 250);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(120, 40);
            this.btnEliminar.Text = "Desactivar";
            this.btnEliminar.UseVisualStyleBackColor = false;


            // DataGridView Usuarios
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Location = new System.Drawing.Point(300, 20);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.Size = new System.Drawing.Size(450, 310);

            // 
            // tabReportes
            // 
            this.tabReportes.Controls.Add(this.lblFechaFin);
            this.tabReportes.Controls.Add(this.lblFechaInicio);
            this.tabReportes.Controls.Add(this.dgvReportes);
            this.tabReportes.Controls.Add(this.btnGenerarReporte);
            this.tabReportes.Controls.Add(this.dtpFin);
            this.tabReportes.Controls.Add(this.dtpInicio);
            this.tabReportes.Location = new System.Drawing.Point(4, 22);
            this.tabReportes.Name = "tabReportes";
            this.tabReportes.Padding = new System.Windows.Forms.Padding(3);
            this.tabReportes.Size = new System.Drawing.Size(768, 352);
            this.tabReportes.TabIndex = 1;
            this.tabReportes.Text = "Reportes y Trazabilidad";
            this.tabReportes.UseVisualStyleBackColor = true;

            this.lblFechaInicio.Location = new System.Drawing.Point(20, 10);
            this.lblFechaInicio.Text = "Desde:";

            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicio.Location = new System.Drawing.Point(20, 30);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(120, 20);

            this.lblFechaFin.Location = new System.Drawing.Point(160, 10);
            this.lblFechaFin.Text = "Hasta:";

            this.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFin.Location = new System.Drawing.Point(160, 30);
            this.dtpFin.Name = "dtpFin";
            this.dtpFin.Size = new System.Drawing.Size(120, 20);

            this.btnGenerarReporte.Location = new System.Drawing.Point(300, 25);
            this.btnGenerarReporte.Name = "btnGenerarReporte";
            this.btnGenerarReporte.Size = new System.Drawing.Size(130, 30);
            this.btnGenerarReporte.Text = "Generar Reporte";


            this.dgvReportes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReportes.Location = new System.Drawing.Point(20, 70);
            this.dgvReportes.Name = "dgvReportes";
            this.dgvReportes.Size = new System.Drawing.Size(730, 260);

            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(12, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(262, 30);
            this.lblTitulo.Text = "PANEL ADMINISTRATIVO";

            // 
            // btnLogOut
            // 
            this.btnLogOut.Location = new System.Drawing.Point(680, 15);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(100, 30);
            this.btnLogOut.Text = "Cerrar Sesión";


            // 
            // FrmAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.tabControlAdmin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administración del Sistema";
            this.tabControlAdmin.ResumeLayout(false);
            this.tabUsuarios.ResumeLayout(false);
            this.tabUsuarios.PerformLayout();
            this.tabReportes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
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
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.Label lblFechaFin;
    }
}

