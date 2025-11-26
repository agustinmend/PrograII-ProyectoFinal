using System;
using System.Collections.Generic;
namespace Backend.Business
{
    public class CreatePublicationDto
    {
        public string AuthorId { get; set; }
        public string Content { get; set; }
        public List<string> ImagenUrls { get; set; }
    }
}
