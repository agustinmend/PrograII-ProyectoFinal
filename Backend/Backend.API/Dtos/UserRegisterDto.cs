using Microsoft.AspNetCore.Mvc;
namespace Backend.API
{
    public class UserRegisterDto
    {
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string? Description { get; set; }
        public IFormFile? ProfilePhoto { get; set; }
    }
}