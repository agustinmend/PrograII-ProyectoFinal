using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using Backend.Data;
namespace Backend.Business
{
    public class SimpleSearchStrategy : ISearchStrategy
    {
        private readonly IPublicationRepository _publicationRepository;
        public SimpleSearchStrategy(IPublicationRepository publicationRepository)
        {
            _publicationRepository = publicationRepository;
        }
        public async Task<List<PublicationDto>> SearchAsync(string query)
        {
            var entities = await _publicationRepository.SearchByTextAsync(query);
            return entities.Select(x => new PublicationDto
            {
                Id = x.Id,
                Content = x.Content,
                AuthorId = x.AuthorId,
                ImageUrls = x.ImagenUrls,
                CreateAt = x.CreatedAt,
                LikesCount = x.LikesCount
            }).ToList();
        }
    }
}