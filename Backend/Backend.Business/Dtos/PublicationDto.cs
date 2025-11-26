using System;
using System.Collections.Generic;
namespace Backend.Business
{
    public class PublicationDto
    {
        public string  Id { get; set; }
        public string Content { get; set; }
        public List<string> ImageUrls { get; set; }
        public DateTime CreateAt { get; set; }
        public int LikesCount { get; set; }
    }
}