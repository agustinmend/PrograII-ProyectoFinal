using System;
using System.Collections.Generic;
namespace Backend.Business
{
    public class CreateUserDto
    {
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string? Description { get; set; }
        public string ProfilePhotoUrl { get; set; }
        public List<string> Contacts { get; set; }
        public List<string> Publicaciones { get; set; }
    }
}

