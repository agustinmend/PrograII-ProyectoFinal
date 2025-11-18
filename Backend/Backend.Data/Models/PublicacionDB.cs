using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Backend.Data
{
    public class PublicacionDB
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        [BsonElement("UsuarioId")]
        public string UsuarioId { get; set; }
        
        [BsonElement("Descripcion")]
        public string Descripcion { get; set; }
        
        [BsonElement("FechaPublicacion")]
        public DateTime FechaPublicacion { get; set; }
        
        [BsonElement("ComentariosId")]
        public List<string> Comentarios { get; set; }
    }
}

