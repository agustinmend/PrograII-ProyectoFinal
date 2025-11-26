using System;
using System.Threading.Tasks;
namespace Backend.Business
{
    public interface ICommentService
    {
        public Task AddCommentAsync(CommentDto comment);
    }
}
