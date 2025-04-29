using AutoMapper;
using Microsoft.EntityFrameworkCore;
using pruebaTecnica1.Data;
using pruebaTecnica1.Dtos;
using pruebaTecnica1.Models;

namespace pruebaTecnica1.Services
{
    public class ClienteService : IClienteService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ClienteService(AppDbContext context, IMapper mapper) { 
            _context = context;
            _mapper  = mapper;  
        }
        public async Task<Cliente> Create(ClienteDto clienteDTO)
        {
            var cliente = _mapper.Map<Cliente>(clienteDTO);
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task Delete(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null) {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Cliente>> GetAll()
        {
            return await _context.Clientes.ToListAsync();

        }

        public async Task<Cliente> GetById(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task Update(int id, ClienteDto clienteDTO)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null) {
                _mapper.Map(clienteDTO, cliente);
                await _context.SaveChangesAsync();
            }
        }
    }
}
