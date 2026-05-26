using System;

namespace SistemaTurnos.Entidades
{
    public class Atencion
    {
        public int Id { get; set; }
        public int IdTurno { get; set; }
        public int IdUsuario { get; set; }
        public int IdModulo { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime? HoraFin { get; set; } // Tipo Nullable (?), ya que al iniciar la atención este campo es nulo
    }
}