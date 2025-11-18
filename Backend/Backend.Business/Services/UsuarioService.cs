using System;
using System.Threading.Tasks;
using Backend.Data;
namespace Backend.Business
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioRepository(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public async Task<UsuarioDB> RegistrarUsuario(Usuario nuevoUsuario)
        {
            if(EmailValidador.ValidarEmail(nuevoUsuario.Correo) && UsernameValidador.ValidarUsername(nuevoUsuario.Username) && PasswordValidador.ValidarPassword(nuevoUsuario.Password))
            {
                var UsuarioExistente = await _usuarioRepository.ObtenerPorCorreoAsync(nuevoUsuario.Correo);
                if(UsuarioExistente != null)
                {
                    throw new Exception("El email ya esta registrado");
                }
                else
                {
                    var nuevoUsuarioDB = new UsuarioDB
                    {
                        Nombre = nuevoUsuario.Nombre;
                        Apellidos = nuevoUsuario.Apellidos;
                        Username = nuevoUsuario.Username;
                        FechaCreacion = nuevoUsuario.FechaCreacion;
                        Correo = nuevoUsuario.Correo;
                    }
                    await _usuarioRepository.CrearAsync(nuevoUsuarioDB);
                }
                return nuevoUsuario;
            }
            throw new Exception("Datos no validos");
        }
    }
}
