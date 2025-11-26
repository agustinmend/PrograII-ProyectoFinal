using System;
namespace Backend.Business
{
    public class NonExistentAuthor : Exception
    {
        public NonExistentAuthor(string message) : base(message) { }
    }
}
