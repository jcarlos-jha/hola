using pruebaTecnica1.Dtos;
using pruebaTecnica1.Models;

namespace pruebaTecnica1.Services
{
    public interface ICuentaService
    {
        Task<IEnumerable<Cuenta>> GetAll();
        Task<IEnumerable<Cuenta>> GetAllActivos();
        Task<IEnumerable<Cuenta>> GetCuentaUsuario(int idUsuario);
        Task<Cuenta> CrearCuenta(CuentaDto CuentaDTO);
        Task<Cuenta> UpdateCuenta(CuentaDto CuentaDTO, int idUsuario);
        Task<bool> elimnarCuenta(int idCuenta);

    }
}
