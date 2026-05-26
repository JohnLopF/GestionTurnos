using System;

namespace SistemaTurnos.Entidades
{
    public abstract class Turno
    {
        // Atributos base definidos en tu estructura original
        public int Id { get; set; }
        public string Codigo { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
        public int IdPrioridad { get; set; }

        // Nuevas propiedades requeridas por el flujo de atención del Asesor
        public string NombreCliente { get; set; }
        public string DocumentoCliente { get; set; }
        public DateTime? FechaAtencion { get; set; }
        public DateTime? FechaFinAtencion { get; set; }
        public int? IdUsuarioAsesor { get; set; }

        // Propiedad de conveniencia para mapear el código si se usa indistintamente


        public string CodigoTurno
        {
            get => Codigo;
            set => Codigo = value;
        }

        // Método abstracto original
        public abstract string GenerarCodigo(int correlativo);
    }

    /// <summary>
    /// Clase concreta para permitir la instanciación de turnos recuperados de la BD
    /// </summary>
    public class TurnoConcreto : Turno
    {
        public override string GenerarCodigo(int correlativo)
        {
            return $"{Codigo}-{correlativo}";
        }
    }
}