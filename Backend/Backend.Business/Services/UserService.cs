using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Net.Mime;
using System.Threading.Tasks;
using Backend.Data;
namespace Backend.Business
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPublicationRepository _publicationRepository;
        public UserService(IUserRepository userRepository, IPublicationRepository publicationRepository)
        {
            _userRepository = userRepository;
            _publicationRepository = publicationRepository;
        }
        public async Task RegisterUserAsync(CreateUserDto userDto)
        {
            await CreateUserValidator.validate(userDto , _userRepository);
            var newUser = new UserBD
            {
                FullName = userDto.FullName,
                Username = userDto.Username,
                ContrasenaHash = PasswordValidator.HashPassword(userDto.Password),
                Email = userDto.Email,
                Contacts = userDto.Contacts ?? new List<string>(),
                Description = userDto.Description,
                ProfilePhotoUrl = userDto.ProfilePhotoUrl,
                Publicaciones = userDto.Publicaciones ?? new List<string>()
            };
            await _userRepository.CreateUserAsync(newUser);
        }
        public async Task<UserProfileDto> GetUserProfileAsync(string userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            var publications = await _publicationRepository.GetByAuthorIdAsync(userId);
            var profile = new UserProfileDto
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Description = user.Description,
                ProfilePhotoUrl = user.ProfilePhotoUrl,
                Publications = publications.Select(x => new PublicationDto
                {
                    Id = x.Id,
                    Content = x.Content,
                    AuthorId = x.AuthorId,
                    AuthorName = x.AuthorName,
                    AuthorUsername = x.AuthorUsername,
                    ImageUrls = x.ImagenUrls,
                    CreateAt = x.CreatedAt,
                    LikesCount = x.LikesCount
                }).OrderByDescending(x => x.CreateAt).ToList()
            };
            return profile;
        }
        public async Task<string> LoginAsync(string username , string password)
        {
            var user = await _userRepository.GetByUsernameAsync(username);
            if(user == null)
            {
                throw new Exception("Usuario no existe");
            }
            if(!PasswordValidator.VerifyPassword(password , user.ContrasenaHash))
            {
                throw new Exception("Contrasena erronea");
            }
            return user.Id;
        }
    }
}
