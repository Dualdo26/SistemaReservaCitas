using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.Interfaces;
using Dominio.Entidades;
using Infraestructura.Persistencia.Contexto;

namespace Infraestructura.Persistencia.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {

        private readonly P2Context context;

        public UsuarioRepositorio(P2Context context)
        {
            this.context = context;
        }
        public IEnumerable<Usuario> GetAllUsuarios()
        {
            return context.Usuario.ToList();
        }

        public Usuario GetUsuarioPorId(int id)
        {
            return context.Usuario.Find(id);
        }

        public bool LogInUsuario(string correo , string clave)
        {
            var usuario = context.Usuario.FirstOrDefault(u => u.Correo == correo && u.Clave == clave);
            return usuario != null;

        }

        public void RegistrarUsuario(Usuario usuario)
        {
            if (usuario == null)
            {
                throw new ArgumentNullException(nameof(usuario), "El usuario no puede ser nulo.");
            }
            // Verificar si el usuario ya existe
            var existingUser = context.Usuario.FirstOrDefault(u => u.Correo == usuario.Correo);
            if (existingUser != null)
            {
                throw new InvalidOperationException("El usuario ya existe con el correo proporcionado.");
            }
            // Agregar el nuevo usuario al contexto
            context.Usuario.Add(usuario);
            context.SaveChanges();
        }
    }
}
