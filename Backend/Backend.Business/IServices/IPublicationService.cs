using System;
using System.Threading.Tasks;
namespace Backend.Business
{
    public interface IPublicationService
    {
        Task CreatePublicationAsync(CreatePublicationDto publication);
        Task<PublicationDetailDto> GetPublicationDetailAsync(string publicationId);
    }
}

