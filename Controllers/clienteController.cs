using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using pruebaTecnica1.Dtos;
using pruebaTecnica1.Models;
using pruebaTecnica1.Services;

namespace pruebaTecnica1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class clienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        public clienteController(IClienteService clienteService) { 
            _clienteService = clienteService;
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<Cliente>>> Get()
        {
            var clientes = await _clienteService.GetAll();
            return Ok(clientes);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> Get(int id)
        {
            var cliente = await _clienteService.GetById(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> Post([FromBody] ClienteDto clienteDTO)
        {
            var cliente = await _clienteService.Create(clienteDTO);
            return CreatedAtAction(nameof(Get), new { id = cliente.ClienteId }, cliente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ClienteDto clienteDTO)
        {
            await _clienteService.Update(id, clienteDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _clienteService.Delete(id);
            return NoContent();
        }
    }
}
