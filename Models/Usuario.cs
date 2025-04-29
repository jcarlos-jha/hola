using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace pruebaTecnica1.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UsuarioId { get; set; }
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int RolId { get; set; }
        [StringLength(255, MinimumLength = 10)]
        public bool Estado { get; set; } = true;
        public Rol Rol { get; set; }
    }
}
