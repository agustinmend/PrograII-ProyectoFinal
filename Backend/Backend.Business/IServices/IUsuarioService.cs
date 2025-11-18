using System;
using Backend.Data;
namespace Backend.Business
{
    public interface IUsuarioService
    {
        Task<UsuarioDB> RegistrarUsuario(Usuario nuevoUsuario);
    }
}
