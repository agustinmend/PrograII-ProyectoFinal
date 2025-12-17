using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
namespace Backend.Data
{
    public class PublicationRepository : IPublicationRepository
    {
        private readonly IMongoCollection<PublicationBD> _publications;
        public PublicationRepository(MongoDBContext context)
        {
            _publications = context.Publications;
        }
        public async Task CreatePublicationAsync(PublicationBD newPublication)
        {
            await _publications.InsertOneAsync(newPublication);
        }
        public async Task<IEnumerable<PublicationBD>> GetByAuthorIdAsync(string authorId)
        {
            return await _publications.Find(x => x.AuthorId == authorId).ToListAsync();
        }
        public async Task<IEnumerable<PublicationBD>> SearchByTextAsync(string query)
        {
            var filter = Builders<PublicationBD>.Filter.Regex("content", new BsonRegularExpression(query, "i"));
            return await _publications.Find(filter).ToListAsync();
        }
        public async Task<PublicationBD?> GetByIdAsync(string id)
        {
            return await _publications.Find(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task AddCommentIdAsync(string publicationId , string commentId)
        {
            var filter = Builders<PublicationBD>.Filter.Eq(x => x.Id, publicationId);
            var update = Builders<PublicationBD>.Update.Push(x => x.Comments, commentId);
            await _publications.UpdateOneAsync(filter, update);
        }
        public async Task AddLikeAsync(string publicationId, string userId)
        {
            var filter = Builders<PublicationBD>.Filter.Eq(x => x.Id, publicationId);
            var update = Builders<PublicationBD>.Update.AddToSet(x => x.Likes, userId);
            await _publications.UpdateOneAsync(filter, update);
        }
        public async Task RemoveLikeAsync(string publicacionId, string userId)
        {
            var filter = Builders<PublicationBD>.Filter.Eq(x => x.Id, publicacionId);
            var update = Builders<PublicationBD>.Update.Pull(x => x.Likes, userId);
            await _publications.UpdateOneAsync(filter, update);
        }
        public async Task<List<PublicationBD>> GetPublicationsByIdAsync(List<string> ids)
        {
            var filter = Builders<PublicationBD>.Filter.In(x => x.Id, ids);
            return await _publications.Find(filter).ToListAsync();
        }
    }
}
