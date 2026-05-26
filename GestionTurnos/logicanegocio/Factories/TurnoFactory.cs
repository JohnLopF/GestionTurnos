using System;
using SistemaTurnos.Entidades;

namespace SistemaTurnos.LogicaNegocio.Factories
{
    public class TurnoFactory
    {
        /// <summary>
        /// Método de Fábrica que centraliza la instanciación polimórfica de Turnos (Patrón GoF)
        /// </summary>
        public static Turno CrearTurno(string tipo)
        {
            if (string.IsNullOrWhiteSpace(tipo))
            {
                throw new ArgumentException("El tipo de turno a fabricar no puede estar vacío.");
            }

            switch (tipo.Trim().ToUpper())
            {
                case "PRIORITARIO":
                    return new TurnoPrioritario();

                case "GENERAL":
                    return new TurnoGeneral();

                default:
                    // Fallback seguro por defecto ante variaciones imprevistas
                    return new TurnoGeneral();
            }
        }
    }
}