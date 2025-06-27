using Microsoft.AspNetCore.Mvc;
using mvc_app.DTOs;
using mvc_app.Services;
using System.Threading.Tasks;

namespace mvc_app.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public AuthController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto dto)
        {
            var result = await _usuarioService.RegistrarUsuarioAsync(dto);
            if (!result)
                return BadRequest("No se pudo registrar el usuario. Verificá que los datos estén bien.");

            return Ok("Usuario registrado correctamente.");
        }
    }
}
