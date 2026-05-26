namespace SistemaTurnos.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Activo { get; set; }
        public int IdRol { get; set; } // Vinculación clave con la entidad Rol
    }
}