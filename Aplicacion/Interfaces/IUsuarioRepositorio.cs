using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;

namespace Aplicacion.Interfaces
{
    public interface IUsuarioRepositorio
    {

        void RegistrarUsuario(Usuario usuario);

        bool LogInUsuario(string correo , string clave); 

        Usuario GetUsuarioPorId(int id);

        IEnumerable<Usuario> GetAllUsuarios();







    }
}
