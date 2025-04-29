using Microsoft.EntityFrameworkCore;
using pruebaTecnica1.Models;
namespace pruebaTecnica1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { 
        
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Rol)
                .WithMany(r => r.Usuarios)
                .HasForeignKey(u => u.RolId);
            modelBuilder.Entity<Cuenta>()
                .HasOne(c => c.Cliente)
                .WithMany(cu => cu.Cuentas)
                .HasForeignKey(c => c.ClienteId);
            modelBuilder.Entity<Rol>().HasData(
                new Rol
                {
                    RolId = 1,
                    Nombre = "Admin",
                    Descripcion = "Administrador del sistema con todos los permisos"
                },
                new Rol
                {
                    RolId = 2,
                    Nombre = "Usuario",
                    Descripcion = "Usuario normal"
                }
            );
        }

    }
}
