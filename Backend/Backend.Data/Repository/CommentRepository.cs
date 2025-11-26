using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
namespace Backend.Data
{
    public class CommentRepository : ICommentRepository
    {
        private readonly IMongoCollection<CommentBD> _comments;
        public CommentRepository(MongoDBContext context)
        {
            _comments = context.Comments;
        }
        public async Task CreateCommentAsync(CommentBD comment)
        {
            await _comments.InsertOneAsync(comment);
        }
        public async Task<IEnumerable<CommentBD>> GetByPublicationIdAsync(string id)
        {
            return await _comments.Find(x => x.PublicationId == id).ToListAsync();
        }
    }
}