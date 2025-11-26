using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Backend.Data
{
    public class UserBD
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Full_name")]
        public string FullName { get; set; }
        
        [BsonElement("Username")]
        public string Username { get; set; }

        [BsonElement("ConstrasenaHash")]
        public string ContrasenaHash { get; set; }
        
        [BsonElement("Email")]
        public string Email { get; set; }

        [BsonElement("Contacts")]
        public List<string> Contacts { get; set; } = new List<string>();

        [BsonElement("Description")]
        public string Description { get; set; }

        [BsonElement("Profile_photo_Url")]
        public string ProfilePhotoUrl { get; set; }

        [BsonElement("Publicaciones")]
        public List<string> Publicaciones { get; set; }
    }
}