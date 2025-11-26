using System;
using System.Collections.Generic;
namespace Backend.Business
{
    public class UserProfileDto
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string ProfilePhotoUrl { get; set; }
        public List<PublicationDto> Publications { get; set; }
    }
}