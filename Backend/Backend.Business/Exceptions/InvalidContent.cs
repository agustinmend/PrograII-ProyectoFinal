using System;
namespace Backend.Business
{
    public class InvalidContent : Exception
    {
        public InvalidContent(string message) : base(message) { }
    }
}
