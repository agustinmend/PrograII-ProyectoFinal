using System;
namespace Backend.Business
{
    public class ExistingUsername : Exception
    {
        public ExistingUsername(string message) : base(message) { }
    }
}