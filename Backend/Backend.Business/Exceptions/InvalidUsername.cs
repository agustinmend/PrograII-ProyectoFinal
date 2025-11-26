using System;
namespace Backend.Business
{
    public class InvalidUsername : Exception
    {
        public InvalidUsername(string message) : base(message) { }
    }
}
