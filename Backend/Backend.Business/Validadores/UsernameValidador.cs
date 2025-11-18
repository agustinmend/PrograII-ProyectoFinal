using System;
using System.Text.RegularExpressions;
namespace Backend.Business
{
    public static class UsernameValidador
    {

        public static bool ValidarUsername(string username)
        {
            if(string.IsNullOrWhiteSpace(username))
            {
                return false;
            }
            string patron = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$";
            return Regex.IsMatch(username, patron);
        }
    }
}

