using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace Backend.Business
{
    public static class EmailValidator
    {
        public static bool ValidateEmail(string email)
        {
            if(string.IsNullOrWhiteSpace(email))
            {
                return false;
            }
            string patron = @"^(?:[a-zA-Z0-9_'^&/+-])+(?:\.(?:[a-zA-Z0-9_'^&/+-])+)*@(?:(?:[a-zA-Z0-9-]+\.)+[a-zA-Z]{2,})$";
            return Regex.IsMatch(email, patron, RegexOptions.IgnoreCase);
        }
    }
}

