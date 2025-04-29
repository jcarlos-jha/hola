using AutoMapper;
using Microsoft.EntityFrameworkCore;
using pruebaTecnica1.Data;
using pruebaTecnica1.Dtos;
using pruebaTecnica1.Models;

namespace pruebaTecnica1.Services
{
    public class CuentaService : ICuentaService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CuentaService(AppDbContext appDbContext, IMapper mapper) {
            _context = appDbContext;
            _mapper = mapper;
        }

        public async Task<Cuenta> CrearCuenta(CuentaDto CuentaDTO)
        {
            var cuenta = _mapper.Map<Cuenta>(CuentaDTO);
            _context.Cuentas.Add(cuenta);
            await _context.SaveChangesAsync();
            return cuenta;
        }

        public async Task<bool> elimnarCuenta(int idCuenta)
        {
            var cuenta = await _context.Cuentas.FindAsync(idCuenta);
            if (cuenta == null) {
                return false;
            }
            cuenta.Estado = false;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Cuenta>> GetAll()
        {
            return await _context.Cuentas.ToListAsync();
        }

        public async Task<IEnumerable<Cuenta>> GetAllActivos()
        {
            return await _context.Cuentas.Where(c => c.Estado == true).ToListAsync();
        }

        public async Task<IEnumerable<Cuenta>> GetCuentaUsuario(int idUsuario)
        {
            return await _context.Cuentas.Where(c => c.Estado == true && c.ClienteId==idUsuario).ToListAsync();
        }

        public async Task<Cuenta> UpdateCuenta(CuentaDto CuentaDTO, int idUsuario)
        {
            var cuenta = await _context.Cuentas.FindAsync(idUsuario);
            if (cuenta != null) {
                _mapper.Map(CuentaDTO,cuenta);
                await _context.SaveChangesAsync();                
            }
            return cuenta;
        }
    }
}
