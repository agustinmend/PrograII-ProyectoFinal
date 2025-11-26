using System;
namespace Backend.Business
{
    public class ExistingEmail : Exception
    {
        public ExistingEmail(string message) : base(message) { }
    }
}
