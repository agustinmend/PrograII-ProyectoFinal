using Microsoft.Win32;
using Backend.Data;
using System;
using System.Threading.Tasks;
namespace Backend.Business
{
    public static class CreateUserValidator
    {
        public static async Task validate(CreateUserDto user , IUserRepository userRepository)
        {
            if(!EmailValidator.ValidateEmail(user.Email))
            {
                throw new InvalidEmail("Email invalido");
            }
            if(!PasswordValidator.ValidatePassword(user.Password))
            {
                throw new InvalidPassword("Contraseña invalida, almenos debe contener Una Mayuscula, una minuscula 8 caracteres minimos y un nro");
            }
            if(!UsernameValidator.ValidateUsername(user.Username))
            {
                throw new InvalidUsername("Nombre de Usuario invalido");
            }
            var ExistsEmail = await userRepository.GetByEmailAsync(user.Email);
            if(ExistsEmail != null)
            {
                throw new ExistingEmail("Ya existe un usuario con este Email");
            }
            var ExistsUsername = await userRepository.GetByUsernameAsync(user.Username);
            if(ExistsUsername != null)
            {
                throw new ExistingUsername("Ya existe un usuario con este username");
            }
        }
    }
}

