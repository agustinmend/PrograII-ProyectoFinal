using System;
using System.Threading.Tasks;
using Backend.Data;
namespace Backend.Business
{
    public static class AddCommentValidator
    {
        public static async Task validate(CommentDto comment , IUserRepository _userRepository)
        {
            if(string.IsNullOrWhiteSpace(comment.Content))
            {
                throw new EmptyComment("El comentario no puede estar vacio");
            }
            var user = await _userRepository.GetByIdAsync(comment.UserId);
            if(user == null)
            {
                throw new NoUserExists("Usuario no encontrado");
            }
        }
    }
}
