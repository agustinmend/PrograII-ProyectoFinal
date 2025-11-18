using MongoDB.Driver;
using System;
namespace Backend.Data
{
    public class MongoDBContext
    {
        private readonly IMongoDatabase _database;

        public MongoDBContext(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }
        public IMongoCollection<UsuarioDB> Usuarios
            => _database.GetCollection<UsuarioDB>("Usuarios");
        public IMongoCollection<PublicacionDB> Publicaciones
            => _database.GetCollection<PublicacionDB>("Publicaciones");
        public IMongoCollection<ComentarioDB> Comentarios
            => _database.GetCollection<ComentarioDB>("Comentarios");
    }
}
