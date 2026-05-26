using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using SistemaTurnos.Entidades;
using SistemaTurnos.AccesoDatos.Repositorios;
using SistemaTurnos.LogicaNegocio;

namespace SistemaTurnos.Presentacion
{
    public partial class FrmRecepcion : Form
    {
        private readonly TurnoRepository _turnoRepo = new TurnoRepository();

        public FrmRecepcion()
        {
            InitializeComponent();
        }

        private void FrmRecepcion_Load(object sender, EventArgs e)
        {
            ConfigurarComboBoxPrioridades();
            ActualizarHistorialDiario();
            dgvTurnosDelDia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            txtDocumento.KeyPress += txtDocumento_KeyPress;
            txtNombre.KeyPress += txtNombre_KeyPress;

            txtDocumento.MaxLength = 12;
            txtNombre.MaxLength = 100;

            SessionManager.GlobalEvents.OnTurnoChanged += Recepcion_OnTurnoChanged;
        }

        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void Recepcion_OnTurnoChanged()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(ActualizarHistorialDiario));
            }
            else
            {
                ActualizarHistorialDiario();
            }
        }

        private void ConfigurarComboBoxPrioridades()
        {
            try
            {
                // Leer datos reales del servidor SQL de forma dinámica
                DataTable dtPrioridades = _turnoRepo.ObtenerPrioridadesConfiguracion();

                cmbTramite.DataSource = dtPrioridades;
                cmbTramite.DisplayMember = "nombre_prioridad";
                cmbTramite.ValueMember = "id_prioridad";

                if (cmbTramite.Items.Count > 0)
                    cmbTramite.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de sincronización al recuperar prioridades de red: " + ex.Message, "Falla", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarHistorialDiario()
        {
            try
            {
                dgvTurnosDelDia.DataSource = _turnoRepo.ObtenerTurnosEnEspera();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al refrescar el registro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            SessionManager.GlobalEvents.OnTurnoChanged -= Recepcion_OnTurnoChanged;
            base.OnFormClosed(e);
        }

        private void btnGenerarTurno_Click(object sender, EventArgs e)
        {
            string documento = txtDocumento.Text.Trim();
            string nombre = txtNombre.Text.Trim();

            if (string.IsNullOrWhiteSpace(documento) || string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("Debe ingresar el documento y el nombre del cliente.", "Campos obligatorios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Regex.IsMatch(documento, @"^\d+$"))
            {
                MessageBox.Show("El campo de documento solo puede contener números enteros.", "Formato Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDocumento.Focus();
                return;
            }

            if (documento.Length < 5)
            {
                MessageBox.Show("El número de documento es demasiado corto (mínimo 5 dígitos).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDocumento.Focus();
                return;
            }

            try
            {
                int idPrioridadSeleccionada = Convert.ToInt32(cmbTramite.SelectedValue);

                // Instanciamos el objeto con código vacío. La base de datos se encargará de
                
                Turno nuevoTurno = new TurnoConcreto
                {
                    Codigo = "",
                    Fecha = DateTime.Now,
                    Estado = "Pendiente",
                    IdPrioridad = idPrioridadSeleccionada,
                    NombreCliente = nombre,
                    DocumentoCliente = documento
                };

                if (_turnoRepo.Insertar(nuevoTurno))
                {
                    MessageBox.Show($"Turno solicitado con éxito para el cliente {nombre}.", "Operación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                    ActualizarHistorialDiario();

                    //Notificar a los tableros y dashboards en tiempo real
                    SessionManager.GlobalEvents.NotifyTurnoChanged();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar en el servidor: " + ex.Message, "Falla de Persistencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e) => LimpiarFormulario();

        private void LimpiarFormulario()
        {
            txtDocumento.Clear();
            txtNombre.Clear();
            txtDocumento.Focus();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            SessionManager.GetInstance().Logout();
            this.Close();
        }
    }
}