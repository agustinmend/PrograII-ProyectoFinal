using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Backend.API
{
    public class PublicationCreateDto
    {
        public string AuthorId { get; set; }
        public string Content { get; set; }
        public List<IFormFile>? Images { get; set; }
    }
}
