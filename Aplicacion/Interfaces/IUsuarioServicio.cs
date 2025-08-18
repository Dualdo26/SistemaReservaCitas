using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.DTOs;
using Dominio.Entidades;

namespace Aplicacion.Interfaces
{
    public interface IUsuarioServicio
    {
        void RegistrarUsuarioDTO(UsuarioDTO usuario);

        (bool esExitoso, string mensaje) LogInUsuarioDTO(string correo , string clave);

        UsuarioDTO GetUsuarioPorIdDTO(int id);

        IEnumerable<UsuarioDTO> GetAllUsuariosDTO();
    }
}
