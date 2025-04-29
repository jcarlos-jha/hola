using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using pruebaTecnica1.Data;
using pruebaTecnica1.Dtos;
using pruebaTecnica1.Encript;
using pruebaTecnica1.Models;

namespace pruebaTecnica1.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UsuarioService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Usuario Autenticar(string email, string password)
        {

            var usuario =  _context.Usuarios.FirstOrDefault(u => u.Email == email);
            if (usuario == null || PasswordHasher.HashPassword(password) != usuario.Password)
            {
                return null;
            }                
            return usuario;
        }

        /*public async Task<Usuario> create(UsuarioDto usuarioDto)
        {
           var usuario = _mapper.Map<Usuario>(usuarioDto);
           _context.Usuarios.Add(usuario);
           await _context.SaveChangesAsync();
           return usuario;
        }
        /**/
        public async Task<Usuario> create(UsuarioDto usuarioDto)
        {
            var usuario = new Usuario
            {
                NombreUsuario = usuarioDto.NombreUsuario,
                Email = usuarioDto.Email,
                Password = PasswordHasher.HashPassword(usuarioDto.Password),
                RolId = usuarioDto.RolId
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task delete(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
            }
        }

        public async Task <bool> deleteLogico(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return false;
            }
            usuario.Estado = false;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Usuario>> GetAll()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<IEnumerable<Usuario>> GetAllLogico()
        {
            return await _context.Usuarios
                .Where(u => u.Estado == true)
                .ToListAsync();
        }

        public async Task<Usuario> GetUsuarioId(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task<Usuario> update(UsuarioDto usuarioDto, int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _mapper.Map(usuarioDto, usuario);
                await _context.SaveChangesAsync();
            }
            return usuario;

        }
    }
}
