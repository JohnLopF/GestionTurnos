using System;
using System.Data;
using System.Data.SqlClient;
using SistemaTurnos.Entidades;
using SistemaTurnos.AccesoDatos.Interfaces;

namespace SistemaTurnos.AccesoDatos.Repositorios
{
    public class UsuarioRepository : IRepository<Usuario>
    {
        private readonly DatabaseConnection _db = new DatabaseConnection();

        public Usuario ValidarCredencialesBaseDatos(string username, string password)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Username", username),
                new SqlParameter("@Password", password)
            };

            DataTable dt = _db.ExecuteSPQuery("sp_Usuarios_Validar", parametros);

            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow fila = dt.Rows[0];
                Usuario usuario = new Usuario();

                usuario.Id = Convert.ToInt32(fila["id_usuario"]);
                usuario.Nombre = fila["nombre_completo"].ToString();
                usuario.Username = fila["username"].ToString();
                usuario.Activo = true;

                if (dt.Columns.Contains("nombre_rol") && fila["nombre_rol"] != DBNull.Value)
                {
                    string rolTexto = fila["nombre_rol"].ToString().ToUpper();

                    if (rolTexto.Contains("ADMIN")) { usuario.IdRol = 4; }
                    else if (rolTexto.Contains("RECEP")) { usuario.IdRol = 5; }
                    else if (rolTexto.Contains("DASH")) { usuario.IdRol = 7; }
                    else { usuario.IdRol = 6; }
                }
                else
                {
                    // CORREGIDO: Uso de id_rol estricto
                    usuario.IdRol = Convert.ToInt32(fila["id_rol"]);
                }

                return usuario;
            }

            return null;
        }

        public Usuario BuscarPorId(int id)
        {
            DataTable dt = ObtenerTodos();
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow[] filasEncontradas = dt.Select($"id_usuario = {id}");

                if (filasEncontradas.Length > 0)
                {
                    DataRow fila = filasEncontradas[0];

                    return new Usuario
                    {
                        Id = id,
                        Nombre = fila["nombre_completo"].ToString(),
                        Username = fila["username"].ToString(),
                        Password = dt.Columns.Contains("password_hash") ? fila["password_hash"].ToString() : "",
                        IdRol = Convert.ToInt32(fila["id_rol"]), // CORREGIDO
                        Activo = true
                    };
                }
            }
            return null;
        }

        public bool Desactivar(int idUsuario)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdUsuario", idUsuario)
            };
            return _db.ExecuteSP("sp_Usuarios_Desactivar", parametros);
        }

        public bool Insertar(Usuario obj)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdUsuario", 0),
                new SqlParameter("@Nombre", obj.Nombre),
                new SqlParameter("@Username", obj.Username),
                new SqlParameter("@Password", obj.Password),
                new SqlParameter("@IdRol", obj.IdRol) // CORREGIDO
            };
            return _db.ExecuteSP("sp_Usuarios_Guardar", parametros);
        }

        public bool Actualizar(Usuario obj)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdUsuario", obj.Id),
                new SqlParameter("@Nombre", obj.Nombre),
                new SqlParameter("@Username", obj.Username),
                new SqlParameter("@Password", obj.Password),
                new SqlParameter("@IdRol", obj.IdRol) // CORREGIDO
            };
            return _db.ExecuteSP("sp_Usuarios_Guardar", parametros);
        }

        public DataTable ObtenerTodos()
        {
            return _db.ExecuteSPQuery("sp_Usuarios_ObtenerTodos", null);
        }
    }
}