using pruebaTecnica1.Dtos;
using pruebaTecnica1.Models;

namespace pruebaTecnica1.Services
{
    public interface IUsuarioService
    {
        Task<IEnumerable<Usuario>> GetAll();
        Task<IEnumerable<Usuario>> GetAllLogico();
        Task<Usuario> GetUsuarioId(int id);

        Task<Usuario> create(UsuarioDto usuario);
        Task<Usuario> update(UsuarioDto usuarioDto, int id);

        Task delete(int id);

        Task <bool> deleteLogico(int id);

        Usuario Autenticar(string email, string password);


    }
}
