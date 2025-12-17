using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Backend.Data
{
    public interface IPublicationRepository
    {
        Task CreatePublicationAsync(PublicationBD newPublication);
        Task<IEnumerable<PublicationBD>> GetByAuthorIdAsync(string authorId);
        Task<IEnumerable<PublicationBD>> SearchByTextAsync(string query);
        Task<PublicationBD?> GetByIdAsync(string id);
        Task AddCommentIdAsync(string publicationId, string commentId);
        Task AddLikeAsync(string publicationId, string userId);
        Task RemoveLikeAsync(string publicationId, string userId);
        Task<List<PublicationBD>> GetPublicationsByIdAsync(List<string> ids);
    }
}