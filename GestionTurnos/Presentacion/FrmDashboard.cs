using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SistemaTurnos.AccesoDatos.Repositorios;
using SistemaTurnos.LogicaNegocio;

namespace SistemaTurnos.UI
{
    public partial class FrmDashboard : Form
    {
        private readonly TurnoRepository _turnoRepo = new TurnoRepository();
        // Constante diferencial: estimación de 4 minutos estándar de atención promedio por persona
        private const int TIEMPO_PROMEDIO_MINUTOS = 4;

        // --- NUEVAS VARIABLES DE ESTADO PARA EL TIEMPO DINÁMICO ---
        private double _tiempoEstimadoDinamico = 0;
        private int _cantidadEnColaAnterior = -1;
        private int _modulosActivosAnterior = -1;
        private DateTime _ultimaVezCalculado = DateTime.Now;

        public FrmDashboard()
        {
            InitializeComponent();

            typeof(DataGridView).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty,
                null, dgvHistorialTurnos, new object[] { true });

            EstilizarTablaUI();

            SessionManager.GlobalEvents.OnTurnoChanged += Dashboard_OnTurnoChanged;
        }

        private void EstilizarTablaUI()
        {
            Color fondoGrisOscuro = Color.FromArgb(30, 30, 30);
            Color blancoHueso = Color.FromArgb(245, 247, 250);

            dgvHistorialTurnos.BackgroundColor = blancoHueso;
            dgvHistorialTurnos.BorderStyle = BorderStyle.None;
            dgvHistorialTurnos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvHistorialTurnos.GridColor = Color.FromArgb(220, 224, 230);
            dgvHistorialTurnos.EnableHeadersVisualStyles = false;
            dgvHistorialTurnos.RowHeadersVisible = false;
            dgvHistorialTurnos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistorialTurnos.MultiSelect = false;

            dgvHistorialTurnos.RowTemplate.Height = 45;
            dgvHistorialTurnos.ColumnHeadersHeight = 45;
            dgvHistorialTurnos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.BackColor = fondoGrisOscuro;
            headerStyle.ForeColor = Color.White;
            headerStyle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHistorialTurnos.ColumnHeadersDefaultCellStyle = headerStyle;

            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
            cellStyle.BackColor = Color.White;
            cellStyle.ForeColor = Color.FromArgb(50, 50, 50);
            cellStyle.Font = new Font("Segoe UI", 14F, FontStyle.Regular);
            cellStyle.SelectionBackColor = Color.FromArgb(225, 235, 245);
            cellStyle.SelectionForeColor = Color.FromArgb(30, 30, 30);
            cellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHistorialTurnos.DefaultCellStyle = cellStyle;

            DataGridViewCellStyle alternatingStyle = new DataGridViewCellStyle();
            alternatingStyle.BackColor = Color.FromArgb(238, 242, 247);
            dgvHistorialTurnos.AlternatingRowsDefaultCellStyle = alternatingStyle;
        }

        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.WindowState = FormWindowState.Normal;
            this.Size = new Size(1024, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            lblReloj.Text = DateTime.Now.ToString("hh:mm:ss tt");

            // Asegurar que el Timer esté funcionando para el dinamismo del tiempo
            if (timerActualizar != null)
            {
                timerActualizar.Enabled = true;
                timerActualizar.Start();
            }

            ActualizarPantallaTurnos();
        }

        private void Dashboard_OnTurnoChanged()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(ActualizarPantallaTurnos));
            }
            else
            {
                ActualizarPantallaTurnos();
            }
        }

        private void timerActualizar_Tick(object sender, EventArgs e)
        {
            lblReloj.Text = DateTime.Now.ToString("hh:mm:ss tt");
            ActualizarPantallaTurnos(); // Este Tick es el que hará que los minutos cambien en pantalla
        }

        private void ActualizarPantallaTurnos()
        {
            try
            {
                DataTable dtTurnos = _turnoRepo.ObtenerTodos();

                if (dtTurnos != null && dtTurnos.Rows.Count > 0)
                {
                    // 1. --- ECUACIÓN PREDICTIVA Y COMPORTAMIENTO DINÁMICO ---

                    DataView dvPendientes = new DataView(dtTurnos);
                    dvPendientes.RowFilter = "Estado = 'Pendiente' OR Estado = 'En Espera'";
                    int cantidadEnCola = dvPendientes.Count;

                    // CORRECCIÓN: Detectar módulos reales leyendo la BD para captar cuando un asesor entra
                    DataTable dtModulos = _turnoRepo.ObtenerModulosConfiguracion();
                    int modulosActivos = 1; // Por defecto 1

                    if (dtModulos != null && dtModulos.Rows.Count > 0)
                    {
                        DataView dvMod = new DataView(dtModulos);
                        // Filtramos los módulos que están operando
                        dvMod.RowFilter = "estado_modulo = 'Libre' OR estado_modulo = 'Ocupado'";
                        modulosActivos = Math.Max(1, dvMod.Count);
                    }

                    // --- LÓGICA DE TIEMPO REAL (DISMINUCIÓN Y AUMENTO) ---
                    if (cantidadEnCola != _cantidadEnColaAnterior || modulosActivos != _modulosActivosAnterior)
                    {
                        // Si entró gente o cambió la cantidad de asesores, recalculamos la base teórica
                        _tiempoEstimadoDinamico = (double)(cantidadEnCola * TIEMPO_PROMEDIO_MINUTOS) / modulosActivos;
                        _cantidadEnColaAnterior = cantidadEnCola;
                        _modulosActivosAnterior = modulosActivos;
                        _ultimaVezCalculado = DateTime.Now;
                    }
                    else
                    {
                        // Si la sala está estática, el tiempo estimado para los nuevos disminuye con los minutos
                        double minutosTranscurridos = (DateTime.Now - _ultimaVezCalculado).TotalMinutes;
                        _tiempoEstimadoDinamico -= minutosTranscurridos;
                        _ultimaVezCalculado = DateTime.Now;

                        // Limites lógicos:
                        if (_tiempoEstimadoDinamico < 1 && cantidadEnCola > 0)
                            _tiempoEstimadoDinamico = 1; // Si hay gente, mínimo 1 minuto
                        else if (cantidadEnCola == 0)
                            _tiempoEstimadoDinamico = 0;
                    }

                    // Calculamos cuánto tiempo lleva esperando la persona más antigua de la fila (AUMENTA)
                    int maxMinutosEspera = 0;
                    if (cantidadEnCola > 0)
                    {
                        dvPendientes.Sort = "Id ASC"; // Traer el más viejo
                        if (dvPendientes[0].Row.Table.Columns.Contains("Fecha"))
                        {
                            DateTime fechaCreacion;
                            if (DateTime.TryParse(dvPendientes[0]["Fecha"].ToString(), out fechaCreacion))
                            {
                                maxMinutosEspera = (int)(DateTime.Now - fechaCreacion).TotalMinutes;
                            }
                        }
                    }

                    if (cantidadEnCola > 0)
                    {
                        int tiempoEstimadoFinal = (int)Math.Ceiling(_tiempoEstimadoDinamico);
                        lblTiempoEspera.ForeColor = Color.GreenYellow;

                        string textoInformativo = $"Espera aprox: {tiempoEstimadoFinal} min ({cantidadEnCola} en cola a {modulosActivos} vent.)";
                        if (maxMinutosEspera > 0)
                        {
                            textoInformativo += $" | Máx espera actual: {maxMinutosEspera} min";
                        }

                        lblTiempoEspera.Text = textoInformativo;
                    }
                    else
                    {
                        lblTiempoEspera.ForeColor = Color.DarkGray;
                        lblTiempoEspera.Text = "Sin tiempo de espera (Cola libre)";
                        _tiempoEstimadoDinamico = 0;
                    }

                    // 2. PROCESAMIENTO DEL TURNO ACTUAL LLAMADO
                    DataView dvAtendiendo = new DataView(dtTurnos);
                    dvAtendiendo.RowFilter = "Estado = 'Llamado' OR Estado = 'Atendiendo'";
                    dvAtendiendo.Sort = "Id DESC";

                    if (dvAtendiendo.Count > 0)
                    {
                        DataRowView primerTurno = dvAtendiendo[0];
                        string codigoTurno = primerTurno.Row.Table.Columns.Contains("Codigo")
                            ? primerTurno["Codigo"].ToString()
                            : primerTurno["codigo_turno"].ToString();

                        string modulo = primerTurno.Row.Table.Columns.Contains("NombreModulo")
                            ? primerTurno["NombreModulo"].ToString()
                            : (primerTurno.Row.Table.Columns.Contains("IdModulo") ? $"MÓDULO {primerTurno["IdModulo"]}" : "MÓDULO");

                        if (lblTurnoGrande.Text != codigoTurno)
                        {
                            lblTurnoGrande.Text = codigoTurno;
                            lblModuloGrande.Text = modulo.ToUpper();
                        }
                    }
                    else
                    {
                        lblTurnoGrande.Text = "--";
                        lblModuloGrande.Text = "ESPERANDO";
                    }

                    // 3. HISTORIAL DE LA GRILLA
                    DataView dvHistorial = new DataView(dtTurnos);
                    dvHistorial.RowFilter = "Estado IN ('Atendido', 'Atendiendo', 'Llamado', 'No Presentado', 'Cancelado')";
                    dvHistorial.Sort = "Id DESC";

                    dgvHistorialTurnos.DataSource = dvHistorial.ToTable();
                    OcultarColumnasEspecificas();
                }
                else
                {
                    lblTurnoGrande.Text = "--";
                    lblModuloGrande.Text = "SALA VACÍA";
                    lblTiempoEspera.Text = "Espera aprox: 0 min";
                    _tiempoEstimadoDinamico = 0;
                    dgvHistorialTurnos.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                lblModuloGrande.Text = "ERR: " + ex.Message.Substring(0, Math.Min(15, ex.Message.Length)).ToUpper();
            }
        }

        private void OcultarColumnasEspecificas()
        {
            try
            {
                if (dgvHistorialTurnos.Columns.Count > 0)
                {
                    if (dgvHistorialTurnos.Columns.Contains("Id")) dgvHistorialTurnos.Columns["Id"].Visible = false;
                    if (dgvHistorialTurnos.Columns.Contains("id_turno")) dgvHistorialTurnos.Columns["id_turno"].Visible = false;
                    if (dgvHistorialTurnos.Columns.Contains("IdPrioridad")) dgvHistorialTurnos.Columns["IdPrioridad"].Visible = false;
                    if (dgvHistorialTurnos.Columns.Contains("IdUsuarioAsesor")) dgvHistorialTurnos.Columns["IdUsuarioAsesor"].Visible = false;
                    if (dgvHistorialTurnos.Columns.Contains("DocumentoCliente")) dgvHistorialTurnos.Columns["DocumentoCliente"].Visible = false;
                    if (dgvHistorialTurnos.Columns.Contains("Fecha")) dgvHistorialTurnos.Columns["Fecha"].Visible = false;

                    if (dgvHistorialTurnos.Columns.Contains("Codigo")) dgvHistorialTurnos.Columns["Codigo"].HeaderText = "Turno";
                    if (dgvHistorialTurnos.Columns.Contains("codigo_turno")) dgvHistorialTurnos.Columns["codigo_turno"].HeaderText = "Turno";
                    if (dgvHistorialTurnos.Columns.Contains("Estado")) dgvHistorialTurnos.Columns["Estado"].HeaderText = "Estado";
                    if (dgvHistorialTurnos.Columns.Contains("NombreModulo")) dgvHistorialTurnos.Columns["NombreModulo"].HeaderText = "Módulo";
                }
            }
            catch { }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            SessionManager.GlobalEvents.OnTurnoChanged -= Dashboard_OnTurnoChanged;
            base.OnFormClosed(e);
        }
    }
}