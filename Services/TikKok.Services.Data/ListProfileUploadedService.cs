namespace TikKok.Services.Data
{
    using System.Linq;

    using TikKok.Data.Common.Repositories;
    using TikKok.Data.Models;
    using TikKok.Web.ViewModels.Profile;

    public class ListProfileUploadedService : IListProfileUploadedService
    {
        private readonly IDeletableEntityRepository<Post> postsRepository;

        public ListProfileUploadedService(IDeletableEntityRepository<Post> postsRepository)
        {
            this.postsRepository = postsRepository;
        }

        public IQueryable GetAll(string userId)
        {
            var postInfo = this.postsRepository.All().Where(u => u.UserId == userId).Select(y => new ProfileUploadedViewModel
            {
                PostId = y.Id,
                CredentialUsername = y.Video.Uploader.CredentialUsername,
                Description = y.Description,
                Likes = y.Likes.Count(),
                Liked = "red",
                Path = y.Video.Path,
                UploadDate = y.CreatedOn,
            });

            return postInfo;
        }
    }
}
