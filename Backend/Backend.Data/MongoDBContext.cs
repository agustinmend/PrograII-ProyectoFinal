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
        public IMongoCollection<UserBD> Users
            => _database.GetCollection<UserBD>("Usuarios");
        public IMongoCollection<PublicationBD> Publications
            => _database.GetCollection<PublicationBD>("Publicaciones");
        public IMongoCollection<CommentBD> Comments
            => _database.GetCollection<CommentBD>("Comentarios");
    }
}
