using System;
using System.Threading.Tasks;
namespace Backend.Data
{
    public interface IUsuarioRepository
    {
        Task<UsuarioDB> ObtenerPorCorreoAsync(string correo);
        Task CrearAsync(UsuarioDB nuevoUsuario);
    }
}

