using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.DTOs;
using Aplicacion.Interfaces;
using Dominio.Entidades;
namespace Aplicacion.Servicios
{
    public class UsuarioServicio : IUsuarioServicio
    {

        private readonly IUsuarioRepositorio repositorio;

        public UsuarioServicio(IUsuarioRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public IEnumerable<UsuarioDTO> GetAllUsuariosDTO()
        {

            var usuarios = repositorio.GetAllUsuarios();
            if (usuarios == null || !usuarios.Any())
            {
                throw new KeyNotFoundException("No se encontraron usuarios.");
            }
            return usuarios.Select(u => new UsuarioDTO
            {
                Nombre = u.Nombre,
                Correo = u.Correo
            }).ToList();
        }

        public UsuarioDTO GetUsuarioPorIdDTO(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "El ID del usuario debe ser mayor que cero.");
            }

            var usuario = repositorio.GetUsuarioPorId(id);
            if (usuario == null)
            {
                throw new KeyNotFoundException($"No se encontró un usuario con el ID {id}.");
            }

            return new UsuarioDTO
            {
                Nombre = usuario.Nombre,
                Correo = usuario.Correo
            };
        }

        public (bool esExitoso, string mensaje) LogInUsuarioDTO(string correo, string clave)
        {
            if (string.IsNullOrEmpty(correo))
                return (false, "El correo no puede estar vacío.");

            if (string.IsNullOrEmpty(clave))
                return (false, "La clave no puede estar vacía.");

            var usuario = repositorio.LogInUsuario(correo, clave);

            if (usuario == null)
                return (false, "Credenciales incorrectas.");

            return (true, "Login exitoso.");
        }

        public void RegistrarUsuarioDTO(UsuarioDTO dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto), "El usuario no puede ser nulo.");
            }
            repositorio.RegistrarUsuario(new Usuario
            {
                Nombre = dto.Nombre,
                Correo = dto.Correo,
                Clave = dto.Clave,
                Rol = dto.Rol
            });
        }
    }
}
