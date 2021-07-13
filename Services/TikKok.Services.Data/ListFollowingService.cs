namespace TikKok.Services.Data
{
    using System.Linq;

    using TikKok.Data.Common.Repositories;
    using TikKok.Data.Models;
    using TikKok.Web.ViewModels;

    public class ListFollowingService : IListFollowingService
    {
        private readonly IRepository<UserFollow> userFollowRepository;
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;

        public ListFollowingService(
            IRepository<UserFollow> userFollowRepository, IDeletableEntityRepository<ApplicationUser> usersRepository)
        {
            this.userFollowRepository = userFollowRepository;
            this.usersRepository = usersRepository;
        }

        public IQueryable GetAll(string userId)
        {
            var following = this.userFollowRepository.All().Where(x => x.SourceUserId == userId).Select(y => y.FollowedUserId);

            var userInfo = this.usersRepository.All().Where(x => following.Contains(x.Id)).Select(y => new UserViewModel
            {
                UserId = y.Id,
                Username = y.CredentialUsername,
                Avatar = y.Avatar,
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
