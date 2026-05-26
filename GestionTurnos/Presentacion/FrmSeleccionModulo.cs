using System;
using System.Data;
using System.Windows.Forms;
using SistemaTurnos.AccesoDatos; // Asegúrate de tener acceso a tu DatabaseConnection

namespace SistemaTurnos.Presentacion
{
    public partial class FrmSeleccionModulo : Form
    {
        public int IdModuloSeleccionado { get; private set; }
        private readonly DatabaseConnection _db = new DatabaseConnection();

        public FrmSeleccionModulo()
        {
            InitializeComponent();
            CargarModulos();
        }

        private void CargarModulos()
        {
            try
            {
                //Este SP debe hacer un SELECT * FROM Modulos WHERE estado_modulo = 'Disponible'
                DataTable dt = _db.ExecuteSPQuery("sp_Modulos_ObtenerDisponibles", null);

                cmbModulos.DataSource = dt;
                cmbModulos.DisplayMember = "nombre_modulo"; //Ajusta al nombre de tu columna
                cmbModulos.ValueMember = "id_modulo";      //Ajusta al nombre de tu columna
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar módulos: " + ex.Message);
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (cmbModulos.SelectedIndex != -1)
            {
                IdModuloSeleccionado = (int)cmbModulos.SelectedValue;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un módulo.");
            }
        }
    }
}