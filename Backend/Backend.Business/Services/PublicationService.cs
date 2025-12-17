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
            var user = await _userRepository.GetByIdAsync(publication.AuthorId);
            var newPublication = new PublicationBD
            {
                AuthorId = publication.AuthorId,
                AuthorName = user.FullName,
                AuthorUsername = user.Username,
                Content = publication.Content,
                ImagenUrls = publication.ImagenUrls ?? new List<string>(),
                CreatedAt = DateTime.Now,
                LikesCount = 0,
                Comments = new List<string>()
            };
            await _publicationRepository.CreatePublicationAsync(newPublication);
            if(newPublication.Id != null)
            {
                await _userRepository.AddPublicationIdAsync(publication.AuthorId , newPublication.Id);
            }
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
        public async Task ToggleLikeAsync(string publicationId, string userId)
        {
            var publication = await _publicationRepository.GetByIdAsync(publicationId);
            if (publication == null) throw new Exception("Publicacion no encontrada");
            bool alreadyLiked = publication.Likes.Contains(userId);
            if(alreadyLiked)
            {
                await _publicationRepository.RemoveLikeAsync(publicationId, userId);
                await _userRepository.RemoveLikedPublicationAsync(userId, publicationId);
            }
            else
            {
                await _publicationRepository.AddLikeAsync(publicationId, userId);
                await _userRepository.AddLikedPublicationAsync(userId, publicationId);
            }
        }
        public async Task<List<PublicationDto>> GetLikedByUserAsync(string userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null) throw new Exception("Usuario no encontrado");
            var publications = await _publicationRepository.GetPublicationsByIdAsync(user.LikedPublications);
            return publications.Select(x => new PublicationDto
            {
                Id = x.Id,
                Content = x.Content,
                AuthorId = x.AuthorId,
                AuthorName = x.AuthorName,
                AuthorUsername = x.AuthorUsername,
                ImageUrls =x.ImagenUrls,
                CreateAt = x.CreatedAt,
                LikesCount = x.Likes.Count
            }).OrderByDescending(x=>x.CreateAt).ToList();
        }
    }
}
