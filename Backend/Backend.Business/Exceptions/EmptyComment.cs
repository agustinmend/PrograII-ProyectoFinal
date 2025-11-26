using System;
namespace Backend.Business
{
    public class EmptyComment : Exception
    {
        public EmptyComment(string message) : base(message) { }
    }
}
