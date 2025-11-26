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
    }
}