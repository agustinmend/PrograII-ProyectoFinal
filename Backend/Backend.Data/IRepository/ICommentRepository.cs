using System;
using System.Collections;
using System.Threading.Tasks;
namespace Backend.Data
{
    public interface ICommentRepository
    {
        public Task CreateCommentAsync(CommentBD comment);
        public Task<IEnumerable<CommentBD>> GetByPublicationIdAsync(string id);
    }
}