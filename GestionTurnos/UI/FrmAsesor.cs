using System;
using System.Data;
using System.Windows.Forms;
using SistemaTurnos.AccesoDatos.Repositorios;
using SistemaTurnos.Entidades;
using SistemaTurnos.LogicaNegocio;

namespace SistemaTurnos.Presentacion
{
    public partial class FrmAsesor : Form
    {
        public FrmAsesor() : this(0) { }

        private readonly TurnoRepository _turnoRepo = new TurnoRepository();
        private Turno _turnoActual = null;
        private int _idModuloAsignado;

        public FrmAsesor(int idModulo)
        {
            InitializeComponent();
            _idModuloAsignado = idModulo;
        }

        private void FrmAsesor_Load(object sender, EventArgs e)
        {
            try
            {
                _turnoRepo.MarcarModuloOcupado(_idModuloAsignado);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo registrar la ocupación del módulo en el servidor: " + ex.Message,
                                "Falla de Inicialización", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ActualizarColaEspera();

            // --- SUSCRIPCIÓN AL EVENTO CON PROCESO SEGURO ---
            SessionManager.GlobalEvents.OnTurnoChanged += Asesor_OnTurnoChanged;

            // Validaciones preventivas de existencia de columnas en el DataGridView
            if (dgvColaEspera.Columns["id_prioridad"] != null)
                dgvColaEspera.Columns["id_prioridad"].Visible = false;

            if (dgvColaEspera.Columns.Contains("nombre_prioridad"))
                dgvColaEspera.Columns["nombre_prioridad"].HeaderText = "Prioridad";

            EstablecerEstadoControles(enAtencion: false);
        }

        private void Asesor_OnTurnoChanged()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(ActualizarColaEspera));
            }
            else
            {
                ActualizarColaEspera();
            }
        }

        private void ActualizarColaEspera()
        {
            try
            {
                dgvColaEspera.DataSource = _turnoRepo.ObtenerTurnosEnEspera();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error al actualizar el flujo de la cola de espera: " + ex.Message);
            }
        }

        private void EstablecerEstadoControles(bool enAtencion)
        {
            btnLlamarSiguiente.Enabled = !enAtencion;
            btnFinalizarTurno.Enabled = enAtencion;
            btnNoSePresento.Enabled = enAtencion;

            if (!enAtencion)
            {
                lblNumTurno.Text = "--";
                lblInfoCliente.Text = "Cliente: Sin asignar";
                _turnoActual = null;
            }
        }

        private void btnLlamarSiguiente_Click(object sender, EventArgs e)
        {
            try
            {
                int idUsuario = SessionManager.GetInstance().UsuarioLogueado?.Id ?? 1;
                int idModulo = _idModuloAsignado;

                DataTable dtTurno = _turnoRepo.AsignarSiguienteEnCola(idModulo, idUsuario);

                // BLINDAJE CRÍTICO: Validar que el DataTable no sea nulo Y que contenga al menos una fila
                if (dtTurno == null || dtTurno.Rows.Count == 0)
                {
                    MessageBox.Show("No hay turnos pendientes en la cola de espera en este momento.", "Cola Vacía", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    EstablecerEstadoControles(enAtencion: false);
                    return;
                }

                DataRow row = dtTurno.Rows[0];

                // --- CORRECCIÓN INTEGRAL DE MAPEO DINÁMICO ---
                _turnoActual = new TurnoConcreto();

                // 1. Mapeo del ID del Turno
                if (dtTurno.Columns.Contains("id_turno") && row["id_turno"] != DBNull.Value)
                    _turnoActual.Id = Convert.ToInt32(row["id_turno"]);
                else
                    _turnoActual.Id = 0;

                // 2. Mapeo del Código del Turno (Controlando el singular 'codigo_turno' de tu BD)
                if (dtTurno.Columns.Contains("codigo_turno") && row["codigo_turno"] != DBNull.Value)
                    _turnoActual.Codigo = row["codigo_turno"].ToString();
                else if (dtTurno.Columns.Contains("codigo_turnos") && row["codigo_turnos"] != DBNull.Value)
                    _turnoActual.Codigo = row["codigo_turnos"].ToString();
                else
                    _turnoActual.Codigo = "T-000";

                // 3. Mapeo del Nombre del Cliente (Evita el error si la columna no viene del SP)
                if (dtTurno.Columns.Contains("nombre_cliente") && row["nombre_cliente"] != DBNull.Value)
                    _turnoActual.NombreCliente = row["nombre_cliente"].ToString();
                else
                    _turnoActual.NombreCliente = "Cliente General"; // Valor por defecto seguro

                // 4. Mapeo del Documento del Cliente
                if (dtTurno.Columns.Contains("documento_cliente") && row["documento_cliente"] != DBNull.Value)
                    _turnoActual.DocumentoCliente = row["documento_cliente"].ToString();
                else
                    _turnoActual.DocumentoCliente = "Sin Documento";

                // Actualizar etiquetas en la interfaz de usuario
                lblNumTurno.Text = _turnoActual.Codigo;
                lblInfoCliente.Text = $"Cliente: {_turnoActual.NombreCliente} ({_turnoActual.DocumentoCliente})";

                EstablecerEstadoControles(enAtencion: true);
                ActualizarColaEspera();

                // --- NOTIFICACIÓN GLOBAL ---
                SessionManager.GlobalEvents.NotifyTurnoChanged();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al iniciar la atención del siguiente turno: " + ex.Message, "Error de Operación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFinalizarTurno_Click(object sender, EventArgs e)
        {
            if (_turnoActual == null)
            {
                EstablecerEstadoControles(enAtencion: false);
                return;
            }

            try
            {
                _turnoActual.Estado = "Atendido";
                _turnoActual.FechaFinAtencion = DateTime.Now;

                _turnoRepo.Actualizar(_turnoActual);

                MessageBox.Show($"Atención del turno {_turnoActual.Codigo} finalizada con éxito.",
                                "Turno Cerrado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                EstablecerEstadoControles(enAtencion: false);
                ActualizarColaEspera();

                // --- NOTIFICACIÓN GLOBAL ---
                SessionManager.GlobalEvents.NotifyTurnoChanged();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cerrar la atención del cliente en la base de datos: " + ex.Message,
                                "Error de Persistencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNoSePresento_Click(object sender, EventArgs e)
        {
            if (_turnoActual == null)
            {
                EstablecerEstadoControles(enAtencion: false);
                return;
            }

            var confirmacion = MessageBox.Show($"¿Desea marcar el turno {_turnoActual.Codigo} como 'No Presentado'?",
                                                "Confirmar Ausencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    _turnoActual.Estado = "Cancelado";
                    _turnoActual.FechaFinAtencion = DateTime.Now;

                    _turnoRepo.Actualizar(_turnoActual);

                    EstablecerEstadoControles(enAtencion: false);
                    ActualizarColaEspera();

                    // --- NOTIFICACIÓN GLOBAL ---
                    SessionManager.GlobalEvents.NotifyTurnoChanged();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al registrar la inasistencia en el servidor: " + ex.Message,
                                    "Error de Persistencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // --- SOLUCIÓN DE BLOQUEO CON CONTROL DE ATENCIÓN ACTIVA ---
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // BLINDAJE CRÍTICO: Si el asesor tiene un turno colgado e intenta forzar el cierre de la ventana ("X")
            if (_turnoActual != null)
            {
                MessageBox.Show("No puede cerrar la aplicación ni abandonar el puesto si tiene un turno activo en atención.\nPor favor termine el turno actual o márquelo como ausente.",
                                "Cierre de Seguridad Detenido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                e.Cancel = true; // Cancela el evento de cierre del formulario por completo
                return;
            }

            // Desuscribimos el evento para que no intente actualizar controles en proceso de destrucción
            SessionManager.GlobalEvents.OnTurnoChanged -= Asesor_OnTurnoChanged;

            try
            {
                // Cambia el estado en SQL de forma síncrona
                _turnoRepo.LiberarModulo(_idModuloAsignado);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error al liberar módulo en cierre: " + ex.Message);
            }

            base.OnFormClosing(e);
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            if (_turnoActual != null)
            {
                MessageBox.Show("No puede abandonar el puesto de atención si tiene un turno activo en el módulo.", "Atención en Curso",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmacion = MessageBox.Show("¿Está seguro de que desea cerrar sesión de asesor y salir?",
                                                "Confirmación de Salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmacion == DialogResult.Yes)
            {
                SessionManager.GetInstance().Logout();

                // Al invocar Close(), saltará a OnFormClosing donde validará y liberará el módulo en BD
                this.Close();
            }
        }
    }
}