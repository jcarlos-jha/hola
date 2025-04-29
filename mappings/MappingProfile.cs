using AutoMapper;
using pruebaTecnica1.Dtos;
using pruebaTecnica1.Models;

namespace pruebaTecnica1.mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<ClienteDto, Cliente>();
            CreateMap<UsuarioDto, Usuario>();
            CreateMap<RolDto, Rol>();
            CreateMap<CuentaDto, Cuenta>();
        }
            
    }
}
