using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Backend.Data
{
    public class UsuarioDB
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Nombre")]
        public string Nombre { get; set; }
        
        [BsonElement("Apellidos")]
        public string Apellidos { get; set; }
        
        [BsonElement("Username")]
        public string Username { get; set; }

        [BsonElement("ConstrasenaHash")]
        public string ContrasenaHash { get; set; }
        
        [BsonElement("FechaCreacion")]
        public DateTime FechaCreacion { get; set; }
        
        [BsonElement("Correo")]
        public string Correo { get; set; }
    }
}