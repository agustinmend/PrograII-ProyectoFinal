using System;
using Microsoft.Win32;
using Backend.Data;
using System.Threading.Tasks;
namespace Backend.Business
{
    public static class CreatePublicationValidator
    {
        public static async Task validate(CreatePublicationDto publication , IUserRepository _userRepository)
        {
            if(string.IsNullOrWhiteSpace(publication.Content))
            {
                throw new InvalidContent("La publicacion esta vacia");
            }
            var user = await _userRepository.GetByIdAsync(publication.AuthorId);
            if(user == null || publication.AuthorId.Length != 24)
            {
                throw new NonExistentAuthor("No existe autor para esta publicacion");
            }
        }
    }
}