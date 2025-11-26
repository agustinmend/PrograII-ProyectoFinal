using System;
using System.Collections.Generic;
namespace Backend.Business
{
    public class PublicationDetailDto : PublicationDto
    {
        public List<CommentDetailDto> Comments { get; set; } = new List<CommentDetailDto>();
    }
}