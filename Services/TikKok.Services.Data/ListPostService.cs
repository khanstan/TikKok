namespace TikKok.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using TikKok.Data.Common.Repositories;
    using TikKok.Data.Models;
    using TikKok.Web.ViewModels.Home;

    public class ListPostService : IListPostService
    {
        private readonly IDeletableEntityRepository<Post> postsRepository;
        private readonly IRepository<Like> likesRepository;

        public ListPostService(
            IDeletableEntityRepository<Post> postsRepository,
            IRepository<Like> likesRepository)
        {
            this.postsRepository = postsRepository;
            this.likesRepository = likesRepository;
        }

        public IQueryable GetAll(string userId)
        {
            var postInfo = this.postsRepository.All().Select(y => new IndexViewModel
            {
                PostId = y.Id,
                CredentialUsername = y.Video.Uploader.CredentialUsername,
                Description = y.Description,
                Likes = y.Likes.Count(),
                Comments = y.Comments.Count(),
                Liked = y.Likes.Any(x => x.UserId == userId) ? "red" : "currentColor",
                Path = y.Video.Path,
                Extension = y.Video.Extension,
                UploadDate = y.CreatedOn,
                UploaderId = y.UserId,
                Followed = y.User.Followers.Any(x => x.SourceUserId == userId) ? "unfollow" : "follow",
            });

            return postInfo;
        }

        public IQueryable GetAll()
        {
            var postInfo = this.postsRepository.All().Select(y => new IndexViewModel
            {
                PostId = y.Id,
                CredentialUsername = y.Video.Uploader.CredentialUsername,
                Description = y.Description,
                Likes = y.Likes.Count(),
                Comments = y.Comments.Count(),
                Liked = "currentColor",
                Path = y.Video.Path,
                Extension = y.Video.Extension,
                UploadDate = y.CreatedOn,
                UploaderId = y.Video.Uploader.UserName,
            });

            return postInfo;
        }

        // public bool DidUserLikeThis(string postId, string userId)
        // {
        //    var like = this.likesRepository.All()
        //        .FirstOrDefault(x => x.PostId == postId && x.UserId == userId);

        // if (like == null)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        // }
        public async Task DeleteAsync(string postId)
        {
            var video = this.postsRepository.All().FirstOrDefault(x => x.Id == postId);
            var videoFromLikes = this.likesRepository.All().FirstOrDefault(x => x.PostId == postId);
            this.postsRepository.Delete(video);

            if (videoFromLikes != null)
            {
                this.likesRepository.Delete(videoFromLikes);
            }

            await this.postsRepository.SaveChangesAsync();
            await this.likesRepository.SaveChangesAsync();
        }
    }
}
