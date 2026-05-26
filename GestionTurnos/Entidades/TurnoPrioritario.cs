using System;

namespace SistemaTurnos.Entidades
{
    public class TurnoPrioritario : Turno
    {
        // Implementación del método abstracto de la clase padre
        public override string GenerarCodigo(int correlativo)
        {
            // Formatea el número correlativo con ceros a la izquierda (Ej: 3 -> "003")
            return $"P-{correlativo:D3}";
        }
    }
}