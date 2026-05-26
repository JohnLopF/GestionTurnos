using System;
using System.Data;
using System.Data.SqlClient;
using SistemaTurnos.Entidades;
using SistemaTurnos.AccesoDatos.Interfaces;

namespace SistemaTurnos.AccesoDatos.Repositorios
{
    public class TurnoRepository : IRepository<Turno>
    {
        private readonly DatabaseConnection _db = new DatabaseConnection();

        public DataTable ObtenerModulosConfiguracion()
        {
            return _db.ExecuteQuery("SELECT id_modulo, nombre_modulo, estado_modulo FROM Modulos", null);
        }

        public DataTable ObtenerPrioridadesConfiguracion()
        {
            return _db.ExecuteQuery("SELECT id_prioridad, nombre_prioridad, prefijo_codigo, peso_prioridad FROM Prioridades", null);
        }

        public bool Insertar(Turno t)
        {
            // 1. Consultar el prefijo configurado en tiempo real desde la BD
            DataTable dt = _db.ExecuteQuery($"SELECT prefijo_codigo FROM Prioridades WHERE id_prioridad = {t.IdPrioridad}", null);
            string prefijo = (dt != null && dt.Rows.Count > 0) ? dt.Rows[0]["prefijo_codigo"].ToString().Trim() : "T";

            // 2. Definir parámetros - CORREGIDO: @CodigoGenerado coincide exactamente con SQL
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdPrioridad", t.IdPrioridad),
                new SqlParameter("@Prefijo", prefijo),
                new SqlParameter("@NombreCliente", t.NombreCliente),
                new SqlParameter("@DocumentoCliente", t.DocumentoCliente),
                new SqlParameter("@CodigoGenerado", SqlDbType.VarChar, 10) { Direction = ParameterDirection.Output }
            };

            // 3. Ejecutar el procedimiento de forma segura
            return _db.ExecuteSP("sp_Turnos_Crear", parametros);
        }

        public DataTable ObtenerReporteFiltrado(DateTime inicio, DateTime fin)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@FechaInicio", SqlDbType.Date) { Value = inicio },
                new SqlParameter("@FechaFin", SqlDbType.Date) { Value = fin }
            };

            return _db.ExecuteSPQuery("sp_Reportes_Filtrar", parametros);
        }

        public bool GuardarConfiguracionSistema(string tipoTabla, int id, string nombre, string prefijo, string peso)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@TipoTabla", tipoTabla),
                new SqlParameter("@Id", id),
                new SqlParameter("@Nombre", nombre),
                new SqlParameter("@ParamPrefijo", (object)prefijo ?? DBNull.Value),
                new SqlParameter("@ParamPeso", (object)peso ?? DBNull.Value)
            };
            return _db.ExecuteSP("sp_Sistema_GuardarConfiguracion", parametros);
        }

        public void LiberarModulo(int idModulo)
        {
            SqlParameter[] param = { new SqlParameter("@IdModulo", idModulo) };
            _db.ExecuteSP("sp_Modulos_Liberar", param);
        }

        public void IniciarAtencion(int idTurno, int idUsuario, int idModulo)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdTurno", idTurno),
                new SqlParameter("@IdUsuario", idUsuario),
                new SqlParameter("@IdModulo", idModulo)
            };

            _db.ExecuteSP("sp_Atenciones_Iniciar", parametros);
        }

        public bool Actualizar(Turno t)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdTurno", t.Id),
                new SqlParameter("@EstadoFinal", t.Estado ?? "Atendido")
            };

            return _db.ExecuteSP("sp_Atenciones_Finalizar", parametros);
        }

        public void MarcarModuloOcupado(int idModulo)
        {
            SqlParameter[] param = { new SqlParameter("@IdModulo", idModulo) };
            _db.ExecuteSP("sp_Modulos_MarcarOcupado", param);
        }

        public DataTable ObtenerTodos()
        {
            return _db.ExecuteSPQuery("sp_Turnos_ObtenerDelDia", null);
        }

        public DataTable ObtenerTurnosEnEspera()
        {
            return _db.ExecuteSPQuery("sp_Turnos_ObtenerColaEspera", null);
        }

        public DataTable AsignarSiguienteEnCola(int idModulo, int idUsuarioAsesor)
        {
            DataTable dtSiguiente = _db.ExecuteSPQuery("sp_Turnos_SiguienteEnCola", null);

            if (dtSiguiente != null && dtSiguiente.Rows.Count > 0)
            {
                int idTurno = Convert.ToInt32(dtSiguiente.Rows[0]["id_turno"]);
                IniciarAtencion(idTurno, idUsuarioAsesor, idModulo);
                return dtSiguiente;
            }
            return null;
        }

        public Turno ObtenerSiguienteEnCola()
        {
            DataTable dt = _db.ExecuteSPQuery("sp_Turnos_SiguienteEnCola", null);

            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow fila = dt.Rows[0];
                return new TurnoConcreto
                {
                    Id = Convert.ToInt32(fila["id_turno"]),
                    Codigo = fila["codigo_turno"].ToString(),
                    Estado = "Pendiente",
                    IdPrioridad = Convert.ToInt32(fila["id_prioridad"])
                };
            }
            return null;
        }
    }
}