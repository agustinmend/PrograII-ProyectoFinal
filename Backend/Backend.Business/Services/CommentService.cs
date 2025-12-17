using System;
using System.Threading.Tasks;
using Backend.Data;
namespace Backend.Business
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IUserRepository _userRepository;
        private readonly IPublicationRepository _publicationRepository;
        private readonly INotifier _notifier;
        public CommentService(
            ICommentRepository commentRepository,
            IUserRepository userRepossitory,
            IPublicationRepository publicationRepository,
            INotifier notifier)
        {
            _commentRepository = commentRepository;
            _userRepository = userRepossitory;
            _publicationRepository = publicationRepository;
            _notifier = notifier;
        }
        public async Task AddCommentAsync(CommentDto comment)
        {
            AddCommentValidator.validate(comment, _userRepository);
            var newComment = new CommentBD
            {
                PublicationId = comment.PublicationId,
                AuthorId = comment.UserId,
                Text = comment.Content,
                CreateAt = DateTime.Now
            };
            await _commentRepository.CreateCommentAsync(newComment);
            await _publicationRepository.AddCommentIdAsync(comment.PublicationId, newComment.Id);
            var user = await _userRepository.GetByIdAsync(comment.UserId);
            await _notifier.NotifyAsync($"El usuario {user.FullName} comento una publicacion");
        }
    }
}
