using System;
using System.Text.RegularExpressions;
namespace Backend.Business
{
    public static class PasswordValidador
    {
        public static bool ValidarPassword(string password)
        {
            if(string.IsNullOrWhiteSpace(password))
            {
                return false;
            }
            string patron = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$";

            return Regex.IsMatch(contrasena, patron);
        }
    }
}

