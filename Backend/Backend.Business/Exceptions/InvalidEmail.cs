using System;
namespace Backend.Business
{
    public class InvalidEmail : Exception
    {
        public InvalidEmail(string message) : base(message) { }
    }
}
