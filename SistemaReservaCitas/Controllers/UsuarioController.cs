using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Aplicacion.Servicios;
using Aplicacion.DTOs;

namespace Presentacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioServicio service;

        public UsuarioController(UsuarioServicio service)
        {
            this.service = service;
        }


        [HttpPost("Registrar")]

        public void RegistrarUsuario(UsuarioDTO usuario)
        {
            service.RegistrarUsuarioDTO(usuario);
        }

        [HttpPost("LogIn")]

        public void LogInUsuario(string correo, string clave)
        {
            service.LogInUsuarioDTO(correo, clave);
        }

        [HttpGet("GetUsuarioPorId/{id}")]

        public UsuarioDTO GetUsuarioPorId(int id)
        {
            
            var usuario = service.GetUsuarioPorIdDTO(id);
            
            return (usuario);
        }

        [HttpGet("GetAllUsuarios")]

        public IEnumerable<UsuarioDTO> GetAllUsuarios()
        {
            var usuarios = service.GetAllUsuariosDTO();
            
            return usuarios;


        }
    }
}
