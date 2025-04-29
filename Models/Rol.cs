namespace pruebaTecnica1.Models
{
    public class Rol
    {
        public int RolId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }
    }
}
