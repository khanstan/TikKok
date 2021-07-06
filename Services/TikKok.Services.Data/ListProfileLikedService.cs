namespace TikKok.Services.Data
{
    using System.Linq;

    using TikKok.Data.Common.Repositories;
    using TikKok.Data.Models;
    using TikKok.Web.ViewModels.Profile;

    public class ListProfileLikedService : IListProfileLikedService
    {
        private readonly IRepository<Like> likesRepository;

        public ListProfileLikedService(IRepository<Like> likesRepository)
        {
            this.likesRepository = likesRepository;
        }

        public IQueryable GetAll(string userId)
        {
            var postInfo = this.likesRepository.All().Where(u => u.UserId == userId).Select(y => new ProfileLikedViewModel
            {
                PostId = y.PostId,
                CredentialUsername = y.Post.Video.Uploader.CredentialUsername,
                Description = y.Post.Description,
                Likes = y.Post.Likes.Count(),
                Liked = "red",
                Path = y.Post.Video.Path,
                UploadDate = y.Post.CreatedOn,
            });

            return postInfo;
        }
    }
}
