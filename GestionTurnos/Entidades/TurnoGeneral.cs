using System;

namespace SistemaTurnos.Entidades
{
    public class TurnoGeneral : Turno
    {
        // Implementación del método abstracto de la clase padre
        public override string GenerarCodigo(int correlativo)
        {
            // Formatea el número correlativo con ceros a la izquierda (Ej: 14 -> "014")
            return $"G-{correlativo:D3}";
        }
    }
}