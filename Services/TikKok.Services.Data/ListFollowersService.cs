namespace TikKok.Services.Data
{
    using System.Linq;

    using TikKok.Data.Common.Repositories;
    using TikKok.Data.Models;
    using TikKok.Web.ViewModels;
    using TikKok.Web.ViewModels.Followers;

    public class ListFollowersService : IListFollowersService
    {
        private readonly IRepository<UserFollow> userFollowRepository;
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;

        public ListFollowersService(
            IRepository<UserFollow> userFollowRepository,
            IDeletableEntityRepository<ApplicationUser> usersRepository)
        {
            this.userFollowRepository = userFollowRepository;
            this.usersRepository = usersRepository;
        }

        public IQueryable GetAll(string userId)
        {
            var followers = this.userFollowRepository.All().Where(x => x.FollowedUserId == userId).Select(y => y.SourceUserId);

            var userInfo = this.usersRepository.All().Where(x => followers.Contains(x.Id)).Select(y => new UserViewModel
            {
                UserId = y.Id,
                Username = y.CredentialUsername,
                CreatedOn = y.CreatedOn,
                Posts = y.Posts.Count(),
                Likes = y.Likes.Count(),
                Followers = y.Followers.Count(),
                Following = y.Following.Count(),
            });

            return userInfo;
        }
    }
}
