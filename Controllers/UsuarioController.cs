using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using pruebaTecnica1.Dtos;
using pruebaTecnica1.Encript;
using pruebaTecnica1.Models;
using pruebaTecnica1.Services;

namespace pruebaTecnica1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        private readonly JwtHelper _jwtHelper;
        public UsuarioController(IUsuarioService usuarioService, JwtHelper jwtHelper)
        {
            _usuarioService = usuarioService;
            _jwtHelper = jwtHelper;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var usuario = _usuarioService.Autenticar(loginDto.Email , loginDto.Password);
            if (usuario == null) return Unauthorized();

            var token = _jwtHelper.GenerateToken(usuario);
            return Ok(new { token });
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<Usuario>>> Get()
        {
            var usuarios = await _usuarioService.GetAll();
            return Ok(usuarios);
        }

        [HttpGet("Listado")]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetActiveClients()
        {
            var usuarios = await _usuarioService.GetAllLogico();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        //[Authorize(Roles = "Admin,Usuario")]
        public async Task<ActionResult<Usuario>> Get(int id)
        {
            var usuario = await _usuarioService.GetUsuarioId(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> Post([FromBody] UsuarioDto usuarioDTO)
        {
            var usuario = await _usuarioService.create(usuarioDTO);
            return CreatedAtAction(nameof(Get), new { id = usuario.UsuarioId }, usuario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UsuarioDto usuarioDTO)
        {
            await _usuarioService.update(usuarioDTO,id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _usuarioService.delete(id);
            return NoContent();
        }
        [HttpPut("Logico/{id}")]
        public async Task<bool> BorradoLogico(int id) 
        {
            return await _usuarioService.deleteLogico(id);
        }

    }
}
