using System;
namespace Backend.Business
{
    public class CommentDetailDto
    {
        public string Id { get; set; }

        public string PublicationId { get; set; }

        public string AuthorId { get; set; }

        public string Text { get; set; }

        public DateTime CreateAt { get; set; }
    }
}
