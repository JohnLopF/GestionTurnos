using System.Data;

namespace SistemaTurnos.AccesoDatos.Interfaces
{
    public interface IRepository<T>
    {
        bool Insertar(T obj);
        bool Actualizar(T obj);
        DataTable ObtenerTodos();
    }
}