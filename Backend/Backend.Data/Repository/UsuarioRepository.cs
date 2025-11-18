using System;
using System.Threading.Tasks;
using MongoDB.Driver;
namespace Backend.Data
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IMongoCollection<UsuarioDB> UsuariosColeccion;
        public UsuarioRepository(MongoDBContext context)
        {
            UsuariosColeccion = context.Usuarios;
        }
        public async Task<UsuarioDB> ObtenerPorCorreoAsync(string correo)
        {
            return await UsuariosColeccion.Find(x => x.Correo == correo).FirstOrDefaultAsync();
        }
        public async Task CrearAsync(UsuarioDB nuevoUsuario)
        {
            await UsuariosColeccion.InsertOneAsync(nuevoUsuario);
        }
    }
}

