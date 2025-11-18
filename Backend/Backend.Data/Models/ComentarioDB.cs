using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Backend.Data
{
    public class ComentarioDB
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    
        [BsonElement("UsuarioId")]
        public string UsuarioId { get; set; }
        
        [BsonElement("Comentario")]
        public string Comentario { get; set; }
    }
}

