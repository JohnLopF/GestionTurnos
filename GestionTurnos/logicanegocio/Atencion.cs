using System;
using System.Data;
using SistemaTurnos.Entidades;
using SistemaTurnos.AccesoDatos.Repositorios;
using SistemaTurnos.LogicaNegocio.Factories;

namespace SistemaTurnos.LogicaNegocio
{
    public class Atencion
    {
        private readonly TurnoRepository _turnoRepo = new TurnoRepository();

        /// <summary>
        /// Tramita y emite un nuevo turno en el sistema usando la Fábrica de objetos GoF
        /// </summary>
        public string EmitirNuevoTicket(string tipoTurno, int correlativoActual, int idPrioridad)
        {
            try
            {
                // 1. Fabricamos la instancia polimórfica adecuada de forma abstracta
                Turno nuevoTurno = TurnoFactory.CrearTurno(tipoTurno);

                // 2. Aplicamos el comportamiento de su clase hija para calcular el código alfanumérico
                nuevoTurno.Codigo = nuevoTurno.GenerarCodigo(correlativoActual);
                nuevoTurno.Fecha = DateTime.Now;
                nuevoTurno.Estado = "En Espera";
                nuevoTurno.IdPrioridad = idPrioridad;

                // 3. Persistimos los datos mediante el repositorio correspondiente
                bool guardado = _turnoRepo.Insertar(nuevoTurno);

                if (guardado)
                {
                    return nuevoTurno.Codigo;
                }
                throw new Exception("La base de datos rechazó el almacenamiento del turno.");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al procesar la emisión de la taquilla: " + ex.Message);
            }
        }

        /// <summary>
        /// Asigna y extrae de forma segura el próximo turno en cola para un módulo específico
        /// </summary>
        public Turno LlamarSiguiente(int idModulo)
        {
            try
            {
                // Extraemos el usuario autenticado desde el Singleton corporativo
                Usuario asesorActivo = SessionManager.GetInstance().UsuarioLogueado;
                if (asesorActivo == null)
                {
                    throw new InvalidOperationException("No hay un asesor autenticado en sesión para despachar turnos.");
                }

                // Ejecutamos el SP transaccional llamando de forma directa al repositorio ajustado
                DataTable dtResult = _turnoRepo.AsignarSiguienteEnCola(idModulo, asesorActivo.Id);

                if (dtResult != null && dtResult.Rows.Count > 0)
                {
                    DataRow fila = dtResult.Rows[0];

                    // Sincronización de nombres de columnas con el estándar de la base de datos
                    string colPrioridad = dtResult.Columns.Contains("IdPrioridad") ? "IdPrioridad" : "id_prioridad";
                    string colId = dtResult.Columns.Contains("Id") ? "Id" : "id_turno";
                    string colCodigo = dtResult.Columns.Contains("Codigo") ? "Codigo" : "codigo_turno";

                    int idPrioridad = Convert.ToInt32(fila[colPrioridad]);
                    string tipo = (idPrioridad == 1) ? "GENERAL" : "PRIORITARIO";

                    // Reconstruimos la entidad mediante la fábrica para retornarla al formulario
                    Turno turnoAsignado = TurnoFactory.CrearTurno(tipo);
                    turnoAsignado.Id = Convert.ToInt32(fila[colId]);
                    turnoAsignado.Codigo = fila[colCodigo].ToString();
                    turnoAsignado.Estado = "Llamado";
                    turnoAsignado.IdPrioridad = idPrioridad;

                    return turnoAsignado;
                }

                return null; // Retorna nulo si no hay clientes pendientes en la cola
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar procesar el siguiente cliente: " + ex.Message);
            }
        }

        /// <summary>
        /// Cambia el estado del ticket a finalizado cerrando los ciclos de control de tiempos
        /// </summary>
        public void FinalizarAtencion(int idTurno)
        {
            if (idTurno <= 0) return;

            try
            {
                // Creamos un clon temporal para mapear la actualización de estado segura usando la fábrica
                Turno turnoA_Cerrar = TurnoFactory.CrearTurno("GENERAL");
                turnoA_Cerrar.Id = idTurno;
                turnoA_Cerrar.Estado = "Atendido";

                _turnoRepo.Actualizar(turnoA_Cerrar);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al finalizar la trazabilidad del turno: " + ex.Message);
            }
        }

        /// <summary>
        /// Función Diferencial Inteligente (Requisito 6.13): Proyecta un tiempo estimado de espera en minutos
        /// </summary>
        public double EstimarTiempoEspera()
        {
            try
            {
                DataTable dtTodos = _turnoRepo.ObtenerTurnosEnEspera();
                if (dtTodos == null || dtTodos.Rows.Count == 0) return 0;

                string colEstado = dtTodos.Columns.Contains("Estado") ? "Estado" : "estado_turno";

                DataRow[] filasEnEspera = dtTodos.Select($"{colEstado} = 'En Espera'");
                int enEspera = filasEnEspera.Length;

                double promedioAtencionMinutos = 8.0;
                return enEspera * promedioAtencionMinutos;
            }
            catch
            {
                return 5.0; // Valor fallback de contingencia
            }
        }

        /// <summary>
        /// Recupera el flujo de muestreo diario para alimentar los tableros de visualización pública
        /// </summary>
        public DataTable ObtenerHistorialMuestreo()
        {
            try
            {
                DataTable dtOriginal = _turnoRepo.ObtenerTurnosEnEspera();

                if (dtOriginal != null)
                {
                    // Mapeo adaptativo para que coincida perfectamente con lo esperado por las vistas
                    if (dtOriginal.Columns.Contains("id_turno") && !dtOriginal.Columns.Contains("Id"))
                        dtOriginal.Columns["id_turno"].ColumnName = "Id";

                    if (dtOriginal.Columns.Contains("codigo_turno") && !dtOriginal.Columns.Contains("Codigo"))
                        dtOriginal.Columns["codigo_turno"].ColumnName = "Codigo";

                    if (dtOriginal.Columns.Contains("estado_turno") && !dtOriginal.Columns.Contains("Estado"))
                        dtOriginal.Columns["estado_turno"].ColumnName = "Estado";

                    if (dtOriginal.Columns.Contains("fecha_emision") && !dtOriginal.Columns.Contains("Fecha"))
                        dtOriginal.Columns["fecha_emision"].ColumnName = "Fecha";
                }

                return dtOriginal;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en procesamiento de mapeo lógico: " + ex.Message);
            }
        }
    }
}