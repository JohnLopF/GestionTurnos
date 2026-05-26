using System;
using System.Data;
using System.Data.SqlClient;

namespace SistemaTurnos.AccesoDatos
{
    public class DatabaseConnection
    {
        private readonly string _strConn = @"Server=DESKTOP-CGPGC8Q\SQLEXPRESS;Database=SistemaTurnos;Trusted_Connection=True;TrustServerCertificate=True;";

        public bool ExecuteSP(string spName, SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_strConn))
                {
                    using (SqlCommand cmd = new SqlCommand(spName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (parameters != null)
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddRange(parameters);
                        }

                        conn.Open();
                        int filasAfectadas = cmd.ExecuteNonQuery();

                        return filasAfectadas > 0 || filasAfectadas == -1;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error de base de datos al ejecutar {spName}: " + ex.Message);
            }
        }

        public DataTable ExecuteSPQuery(string spName, SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(_strConn))
                {
                    using (SqlCommand cmd = new SqlCommand(spName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (parameters != null)
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddRange(parameters);
                        }

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
                return dt;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error de consulta en la base de datos ({spName}): " + ex.Message);
            }
        }

        public DataTable ExecuteQuery(string query, SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(_strConn))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        if (parameters != null)
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddRange(parameters);
                        }

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
                return dt;
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al ejecutar la consulta SQL directa: " + ex.Message);
            }
        }
    }
}