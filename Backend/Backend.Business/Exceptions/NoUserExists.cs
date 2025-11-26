using System;
namespace Backend.Business
{
    public class NoUserExists: Exception
    {
        public NoUserExists(string message) : base(message) { }
    }
}
