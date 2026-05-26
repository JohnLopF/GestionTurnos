using System;
using SistemaTurnos.Entidades;
using SistemaTurnos.AccesoDatos.Repositorios;
namespace SistemaTurnos.LogicaNegocio
{
    public class SessionManager
    {
        private static SessionManager _instance;
        private Usuario _usuarioLogueado;
        private readonly UsuarioRepository _usuarioRepo = new UsuarioRepository();

        private SessionManager() { }

        public static SessionManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new SessionManager();
            }
            return _instance;
        }

        public Usuario UsuarioLogueado => _usuarioLogueado;

        public bool Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            try
            {
                Usuario usuario = _usuarioRepo.ValidarCredencialesBaseDatos(username.Trim(), password);

                if (usuario != null && usuario.Activo)
                {
                    _usuarioLogueado = usuario;
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Error de comunicación en el proceso de autenticación: " + ex.Message);
            }
        }

        // --- BUS DE EVENTOS GLOBAL INTEGRADO ---
        public static class GlobalEvents
        {
            public static event Action OnTurnoChanged;

            public static void NotifyTurnoChanged()
            {
                OnTurnoChanged?.Invoke();
            }
        }

        public void Logout()
        {
            _usuarioLogueado = null;
        }
    }
}