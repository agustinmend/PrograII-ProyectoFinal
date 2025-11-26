using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Net.Mime;
using System.Threading.Tasks;
using Backend.Data;
namespace Backend.Business
{
    public class PublicationService : IPublicationService
    {
        private readonly IPublicationRepository _publicationRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICommentRepository _commentRepository;
        public PublicationService(IPublicationRepository publicationRepository , IUserRepository userRepository , ICommentRepository commentRepository)
        {
            _publicationRepository = publicationRepository;
            _userRepository = userRepository;
            _commentRepository = commentRepository;
        }
        public async Task CreatePublicationAsync(CreatePublicationDto publication)
        {
            CreatePublicationValidator.validate(publication, _userRepository);
            var newPublication = new PublicationBD
            {
                AuthorId = publication.AuthorId,
                Content = publication.Content,
                ImagenUrls = publication.ImagenUrls ?? new List<string>(),
                CreatedAt = DateTime.Now,
                LikesCount = 0,
                Comments = new List<string>()
            };
            await _publicationRepository.CreatePublicationAsync(newPublication);
        }
        public async Task<PublicationDetailDto> GetPublicationDetailAsync(string publicationId)
        {
            var publication = await _publicationRepository.GetByIdAsync(publicationId);
            var comments = await _commentRepository.GetByPublicationIdAsync(publicationId);
            var publicationDetail = new PublicationDetailDto
            {
                Id = publication.Id,
                Content = publication.Content,
                ImageUrls = publication.ImagenUrls,
                CreateAt = publication.CreatedAt,
                LikesCount = publication.LikesCount,
                Comments = comments.Select(x => new CommentDetailDto
                {
                    Id = x.Id,
                    PublicationId = x.PublicationId,
                    AuthorId = x.AuthorId,
                    Text = x.Text,
                    CreateAt = x.CreateAt
                }).OrderBy(x => x.CreateAt).ToList()
            };
            return publicationDetail;
        }
    }
}
