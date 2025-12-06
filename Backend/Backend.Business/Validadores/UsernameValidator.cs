using System;
using System.Text.RegularExpressions;
namespace Backend.Business
{
    public static class UsernameValidator
    {
        public static bool ValidateUsername(string username)
        {
            if(string.IsNullOrWhiteSpace(username))
            {
                return false;
            }
            string patron = @"^(?=.*[a-z])(?=.*[A-Z]).{8,}$";
            return Regex.IsMatch(username, patron);
        }
    }
}