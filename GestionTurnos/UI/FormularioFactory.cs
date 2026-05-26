using GestionTurnos;
using GestionTurnos.UI;
using System;
using System.Windows.Forms;

namespace SistemaTurnos.Presentacion
{
    public static class FormularioFactory
    {
        public static Form ObtenerPanelPorRol(string rol)
        {

            switch (rol?.Trim())
            {
                case "Admin":
                    return new FrmAdmin();
                case "Recepcionista":
                    return new FrmRecepcion();
                case "Asesor":
                    return new FrmAsesor();
                default:
                    throw new Exception("El rol institucional detectado no cuenta con un panel asignado en el sistema.");
            }
        }
    }
}