using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Backend.Data
{
    public class PublicationBD
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("author_id")]
        public string AuthorId { get; set; }

        [BsonElement("content")]
        public string Content { get; set; }

        [BsonElement("author_username")]
        public string AuthorUsername { get; set; }

        [BsonElement("Author_name")]
        public string AuthorName { get; set; }

        [BsonElement("image_urls")]
        public List<string> ImagenUrls { get; set; } = new List<string>();

        [BsonElement("created_at")]
        public DateTime CreatedAt { get; set; }

        [BsonElement("likes_count")]
        public int LikesCount { get; set; }

        [BsonElement("Comments")]
        public List<string> Comments { get; set; }

        [BsonElement("likes")]
        public List<string> Likes { get; set; } = new List<string>();
    }
}
