using GestionTurnos;
using SistemaTurnos.Entidades;
using SistemaTurnos.LogicaNegocio;
// Asegúrate de tener los using de tus formularios aquí
using SistemaTurnos.Presentacion;
using SistemaTurnos.UI;
using System;
using System.Windows.Forms;

namespace SistemaTurnos.Presentacion
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();

            // Enlazamos eventos
            chkVerPassword.CheckedChanged += chkVerPassword_CheckedChanged;
            btnRegistrar.Click += btnRegistrar_Click;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            lblMensajeError.Visible = false;

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MostrarError("Por favor, ingrese el usuario y la contraseña.");
                return;
            }

            try
            {
                // 1. Invocamos el inicio de sesión
                bool loginExitoso = SessionManager.GetInstance().Login(username, password);

                if (loginExitoso)
                {
                    Usuario usuarioValidado = SessionManager.GetInstance().UsuarioLogueado;
                    Form formularioDestino = null;

                    // 2. Lógica de enrutamiento
                    switch (usuarioValidado.IdRol)
                    {
                        case 4: // Administrador
                            formularioDestino = new FrmAdmin();
                            break;

                        case 5: // Recepcionista
                            formularioDestino = new FrmRecepcion();
                            break;

                        case 7: // DASHBOARD
                            formularioDestino = new FrmDashboard();
                            break;

                        case 6: // Asesor Operativo
                            using (var frmSeleccion = new FrmSeleccionModulo())
                            {
                                if (frmSeleccion.ShowDialog() == DialogResult.OK)
                                {
                                    formularioDestino = new FrmAsesor(frmSeleccion.IdModuloSeleccionado);
                                }
                                else
                                {
                                    // Si cancela, no hacemos nada y salimos
                                    return;
                                }
                            }
                            break;

                        default:
                            MessageBox.Show($"El rol asignado (ID: {usuarioValidado.IdRol}) no tiene una pantalla configurada.",
                                            "Acceso Restringido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                    }

                    // 3. Ejecución en modo PRUEBAS (Multi-ventana)
                    if (formularioDestino != null)
                    {
                        /* --- CAMBIOS PARA ENTORNO DE PRUEBAS --- */

                        // COMENTADO: Ya no ocultamos el Login para poder ver ambas ventanas
                        // this.Hide(); 

                        // COMENTADO: Ya no forzamos el cierre de sesión al cerrar una ventana
                        /*
                        formularioDestino.FormClosed += (s, args) =>
                        {
                            SessionManager.GetInstance().Logout();
                            this.Show();
                        };
                        */

                        // Abrimos la ventana nueva SIN bloquear el Login
                        formularioDestino.Show();
                    }
                }
                else
                {
                    MostrarError("* Usuario o clave incorrectos / Inactivo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el sistema de autenticación: " + ex.Message,
                                "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkVerPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkVerPassword.Checked;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Por favor, póngase en contacto con el Administrador para solicitar un usuario.",
                            "Solicitud de Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MostrarError(string mensaje)
        {
            lblMensajeError.Text = mensaje;
            lblMensajeError.Visible = true;
            txtPassword.Clear();
            txtPassword.Focus();
        }

        private void LimpiarCampos()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            chkVerPassword.Checked = false;
            lblMensajeError.Visible = false;
            txtUsername.Focus();
        }
    }
}