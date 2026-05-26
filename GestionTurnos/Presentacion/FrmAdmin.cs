using System;
using System.Data;
using System.Windows.Forms;
using SistemaTurnos.Entidades;
using SistemaTurnos.AccesoDatos.Repositorios;
using SistemaTurnos.LogicaNegocio;

namespace SistemaTurnos.Presentacion
{
    public partial class FrmAdmin : Form
    {
        private readonly UsuarioRepository _usuarioRepo = new UsuarioRepository();
        private readonly TurnoRepository _turnoRepo = new TurnoRepository();
        private int _idSeleccionadoGlobal = 0;

        public FrmAdmin()
        {
            InitializeComponent();
        }

        private void FrmAdmin_Load(object sender, EventArgs e)
        {
            SessionManager.GlobalEvents.OnTurnoChanged += GlobalEvents_OnTurnoChanged;

            cmbTablasCrud.Items.Clear();
            cmbTablasCrud.Items.Add("PERSONAL (USUARIOS)");
            cmbTablasCrud.Items.Add("MÓDULOS DE ATENCIÓN");
            cmbTablasCrud.Items.Add("PRIORIDADES Y TIPOS");
            cmbTablasCrud.SelectedIndex = 0;

            cmbTablasCrud.SelectedIndexChanged += CmbTablasCrud_SelectedIndexChanged;

            CargarListaPrincipal();
            CargarComboRoles();

            dtpFin.Value = DateTime.Now;
            dtpInicio.Value = DateTime.Now.AddDays(-7);

            txtUsername.KeyPress += TxtUsername_KeyPress;
            txtNombreCompleto.MaxLength = 100;
            txtUsername.MaxLength = 50;
            txtPassword.MaxLength = 255;
        }

        private void GlobalEvents_OnTurnoChanged()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(CargarListaPrincipal));
            }
            else
            {
                CargarListaPrincipal();
            }
        }

        private void CmbTablasCrud_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarFormularioCRUD();
            CargarListaPrincipal();

            if (cmbTablasCrud.SelectedIndex == 0)
            {
                lblNom.Text = "Nombre Completo:";
                lblUser.Text = "Usuario de Red:";
                lblPass.Text = "Contraseña:";
                lblRol.Text = "Rol Asignado:";
                txtUsername.Enabled = true;
                txtPassword.Enabled = true;
                cmbRoles.Enabled = true;
            }
            else if (cmbTablasCrud.SelectedIndex == 1) // Módulos
            {
                lblNom.Text = "Nombre del Módulo:";
                lblUser.Text = "No Requerido:";
                lblPass.Text = "No Requerido:";
                lblRol.Text = "No Requerido:";
                txtUsername.Enabled = false;
                txtPassword.Enabled = false;
                cmbRoles.Enabled = false;
            }
            else // Prioridades
            {
                lblNom.Text = "Nombre Prioridad:";
                lblUser.Text = "Prefijo Código:";
                lblPass.Text = "Peso / Prioridad:";
                lblRol.Text = "No Requerido:";
                txtUsername.Enabled = true;
                txtPassword.Enabled = true;
                cmbRoles.Enabled = false;
            }
        }

        private void TxtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar) && cmbTablasCrud.SelectedIndex == 0)
            {
                e.Handled = true;
            }
        }

        private void CargarListaPrincipal()
        {
            try
            {
                if (cmbTablasCrud.SelectedIndex == 0)
                {
                    dgvUsuarios.DataSource = _usuarioRepo.ObtenerTodos();
                }
                else if (cmbTablasCrud.SelectedIndex == 1)
                {
                    dgvUsuarios.DataSource = _turnoRepo.ObtenerModulosConfiguracion();
                }
                else
                {
                    dgvUsuarios.DataSource = _turnoRepo.ObtenerPrioridadesConfiguracion();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falla al recuperar los datos remotos: " + ex.Message, "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarComboRoles()
        {
            var rolesDisponibles = new[]
            {
                new { Text = "Administrador", Value = 4 },
                new { Text = "Recepcionista", Value = 5 },
                new { Text = "Asesor Operativo", Value = 6 },
                new { Text = "Dashboard (Monitor)", Value = 7 }
            };

            cmbRoles.DataSource = rolesDisponibles;
            cmbRoles.DisplayMember = "Text";
            cmbRoles.ValueMember = "Value";
            cmbRoles.SelectedIndex = 0;
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = dgvUsuarios.Rows[e.RowIndex];

            if (cmbTablasCrud.SelectedIndex == 0) // Usuarios
            {
                _idSeleccionadoGlobal = ObtenerValorCelda(fila, new[] { "id_usuario" }, 0);
                txtNombreCompleto.Text = ObtenerValorCelda(fila, new[] { "nombre_completo" }, "").ToString();
                txtUsername.Text = ObtenerValorCelda(fila, new[] { "username" }, "").ToString().Replace(" ", "");
                txtPassword.Text = "";

                if (dgvUsuarios.Columns.Contains("id_rol") && fila.Cells["id_rol"].Value != null && fila.Cells["id_rol"].Value != DBNull.Value)
                {
                    cmbRoles.SelectedValue = Convert.ToInt32(fila.Cells["id_rol"].Value);
                }
            }
            else if (cmbTablasCrud.SelectedIndex == 1) // Módulos
            {
                _idSeleccionadoGlobal = ObtenerValorCelda(fila, new[] { "id_modulo" }, 0);
                txtNombreCompleto.Text = ObtenerValorCelda(fila, new[] { "nombre_modulo" }, "").ToString();
                txtUsername.Text = "";
                txtPassword.Text = "";
            }
            else // Prioridades
            {
                _idSeleccionadoGlobal = ObtenerValorCelda(fila, new[] { "id_prioridad" }, 0);
                txtNombreCompleto.Text = ObtenerValorCelda(fila, new[] { "nombre_prioridad" }, "").ToString();
                txtUsername.Text = ObtenerValorCelda(fila, new[] { "prefijo_codigo" }, "").ToString();
                txtPassword.Text = ObtenerValorCelda(fila, new[] { "peso_prioridad" }, "").ToString();
            }
        }

        private dynamic ObtenerValorCelda(DataGridViewRow fila, string[] nombresPosibles, dynamic valorPorDefecto)
        {
            foreach (string nombre in nombresPosibles)
            {
                if (fila.DataGridView.Columns.Contains(nombre))
                {
                    object valor = fila.Cells[nombre].Value;
                    return (valor != null && valor != DBNull.Value) ? valor : valorPorDefecto;
                }
            }
            return valorPorDefecto;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombreCompleto.Text))
                {
                    MessageBox.Show("Por favor, rellene el campo de nombre obligatorio.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool exito = false;
                string tipoEntidad = "";

                if (cmbTablasCrud.SelectedIndex == 0) // Usuarios
                {
                    tipoEntidad = "USUARIO";
                    if (string.IsNullOrWhiteSpace(txtUsername.Text))
                    {
                        MessageBox.Show("El usuario de red es requerido.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (_idSeleccionadoGlobal == 0 && string.IsNullOrWhiteSpace(txtPassword.Text))
                    {
                        MessageBox.Show("Debe asignar una contraseña obligatoria para los usuarios nuevos.", "Contraseña Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    int idRolSeleccionado = cmbRoles.SelectedValue != null ? (int)cmbRoles.SelectedValue : 4;

                    Usuario usuarioA_Procesar = new Usuario
                    {
                        Id = _idSeleccionadoGlobal,
                        Nombre = txtNombreCompleto.Text.Trim(),
                        Username = txtUsername.Text.Trim().Replace(" ", ""),
                        Password = txtPassword.Text.Trim(),
                        IdRol = idRolSeleccionado,
                        Activo = true
                    };

                    exito = (_idSeleccionadoGlobal == 0) ? _usuarioRepo.Insertar(usuarioA_Procesar) : _usuarioRepo.Actualizar(usuarioA_Procesar);
                }
                else // Módulos (Index 1) o Prioridades (Index 2)
                {
                    string prefijo = "";
                    string peso = "0";

                    if (cmbTablasCrud.SelectedIndex == 1)
                    {
                        tipoEntidad = "MODULO";
                    }
                    else
                    {
                        tipoEntidad = "PRIORIDAD";
                        prefijo = txtUsername.Text.Trim();
                        peso = !string.IsNullOrWhiteSpace(txtPassword.Text) ? txtPassword.Text.Trim() : "0";
                    }

                    exito = _turnoRepo.GuardarConfiguracionSistema(tipoEntidad, _idSeleccionadoGlobal, txtNombreCompleto.Text.Trim(), prefijo, peso);
                }

                if (exito)
                {
                    MessageBox.Show($"{tipoEntidad} procesado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SessionManager.GlobalEvents.NotifyTurnoChanged();
                    LimpiarFormularioCRUD();
                    CargarListaPrincipal();
                }
                else
                {
                    MessageBox.Show($"La operación no realizó cambios en la base de datos para {tipoEntidad}.", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de transaccionalidad al almacenar: " + ex.Message, "Falla Crítica", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_idSeleccionadoGlobal == 0)
            {
                MessageBox.Show("Seleccione un registro de la grilla antes de intentar la baja lógica.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("¿Desea inhabilitar este registro del sistema?", "Confirmar Desactivación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    bool exito = false;
                    if (cmbTablasCrud.SelectedIndex == 0)
                    {
                        exito = _usuarioRepo.Desactivar(_idSeleccionadoGlobal);
                    }
                    else
                    {
                        string tipoEntidad = cmbTablasCrud.SelectedIndex == 1 ? "MODULO_BAJA" : "PRIORIDAD_BAJA";
                        exito = _turnoRepo.GuardarConfiguracionSistema(tipoEntidad, _idSeleccionadoGlobal, "", "", "");
                    }

                    if (exito)
                    {
                        MessageBox.Show("Registro dado de baja con éxito.", "Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SessionManager.GlobalEvents.NotifyTurnoChanged();
                        LimpiarFormularioCRUD();
                        CargarListaPrincipal();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el registro seleccionado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al ejecutar baja: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            SessionManager.GlobalEvents.OnTurnoChanged -= GlobalEvents_OnTurnoChanged;
            base.OnFormClosed(e);
        }

        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            if (dtpInicio.Value.Date > dtpFin.Value.Date)
            {
                MessageBox.Show("La fecha de inicio de la consulta no puede ser posterior a la fecha de fin.", "Rango de fechas erróneo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                dgvReportes.DataSource = _turnoRepo.ObtenerReporteFiltrado(dtpInicio.Value.Date, dtpFin.Value.Date);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar el reporte de trazabilidad histórica: " + ex.Message, "Falla", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarFormularioCRUD()
        {
            _idSeleccionadoGlobal = 0;
            txtNombreCompleto.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            if (cmbRoles.Items.Count > 0) cmbRoles.SelectedIndex = 0;
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            SessionManager.GetInstance().Logout();
            this.Close();
        }
    }
}