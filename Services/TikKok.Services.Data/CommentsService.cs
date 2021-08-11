namespace TikKok.Services.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using TikKok.Data.Common.Repositories;
    using TikKok.Data.Models;
    using TikKok.Web.ViewModels.Comments;

    public class CommentsService : ICommentsService
    {
        private readonly IDeletableEntityRepository<Comment> commentsRepository;

        public CommentsService(IDeletableEntityRepository<Comment> commentsRepository)
        {
            this.commentsRepository = commentsRepository;
        }

        public async Task<CommentsViewModel> AddComment(CommentsInputModel input, string userId)
        {
            var comment = new Comment()
            {
                ParentId = input.ParentId,
                CommentText = input.CommentText,
                UserId = userId,
                CommentDate = DateTime.Now,
                PostId = input.PostId,
            };

            await this.commentsRepository.AddAsync(comment);
            await this.commentsRepository.SaveChangesAsync();

            var viewModel = this.commentsRepository.All().Where(x => x.Id == comment.Id)
                    .Select(x => new CommentsViewModel
                    {
                        CommentId = x.Id,
                        CommentText = x.CommentText,
                        ParentId = x.ParentId,
                        CommentDate = x.CommentDate.ToString(),
                        User = x.User,
                    }).FirstOrDefault();

            return viewModel;
        }

        public IQueryable GetAll(string postId)
        {
            var viewModel = this.commentsRepository.All().Where(x => x.PostId == postId).OrderByDescending(x => x.CommentDate)
                .Select(x => new CommentsViewModel
                {
                    CommentId = x.Id,
                    CommentText = x.CommentText,
                    ParentId = x.ParentId,
                    CommentDate = DateTime.Now.Subtract(x.CommentDate).TotalMinutes.ToString("N0"),
                    User = x.User,
                    ChildComments = this.commentsRepository.All().Where(y => y.ParentId == x.Id).ToList(),
                });
            return viewModel;
        }

    }
}
