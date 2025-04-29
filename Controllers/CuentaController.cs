using Microsoft.AspNetCore.Mvc;
using pruebaTecnica1.Dtos;
using pruebaTecnica1.Models;
using pruebaTecnica1.Services;

namespace pruebaTecnica1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaController : Controller
    {
        private readonly ICuentaService _cuentaService;
        public CuentaController(ICuentaService cuentaService) { 
            _cuentaService = cuentaService; 
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cuenta>>> Get()
        {            
            var cuentas = await _cuentaService.GetAll(); 
            return Ok(cuentas);
        }

        [HttpGet("Listado")]
        public async Task<ActionResult<IEnumerable<Cuenta>>> getCuentasActivas()
        {
            var cuentas = await _cuentaService.GetAllActivos();
            return Ok(cuentas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Cuenta>>> GetCuentausuario(int id)
        {
            var cuentas = await _cuentaService.GetCuentaUsuario(id);
            if(cuentas == null)
            {
                return NotFound();
            }
            return Ok(cuentas);
        }

        [HttpPost]
        public async Task<ActionResult<Cuenta>> crear([FromBody] CuentaDto cuentaDTO)
        {
            var cuenta = await _cuentaService.CrearCuenta(cuentaDTO);
            return CreatedAtAction(nameof(Get), new { id = cuenta.CuentaId }, cuenta);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CuentaDto cuentaDTO)
        {      
            await _cuentaService.UpdateCuenta(cuentaDTO, id);
            return NoContent();
        }

       
        [HttpPut("Logico/{id}")]
        public async Task<bool> BorradoLogico(int id)
        {            
            return await _cuentaService.elimnarCuenta(id);
        }


    }
}
