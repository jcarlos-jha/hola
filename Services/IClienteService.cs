using pruebaTecnica1.Dtos;
using pruebaTecnica1.Models;

namespace pruebaTecnica1.Services
{
    public interface IClienteService
    {
        Task<IEnumerable<Cliente>> GetAll();
        Task<Cliente> GetById(int id);
        Task<Cliente> Create(ClienteDto clienteDTO);
        Task Update(int id, ClienteDto clienteDTO);
        Task Delete(int id);
    }
}
