using System;
namespace Backend.Business
{
    public class CommentDto
    {
        public string PublicationId { get; set; }
        public string UserId { get; set; }
        public string Content { get; set; }
    }
}
