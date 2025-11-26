using System;
namespace Backend.Business
{
    public class InvalidPassword : Exception
    {
        public InvalidPassword(string message) : base(message) { }
    }
}
