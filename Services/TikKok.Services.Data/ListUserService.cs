namespace TikKok.Services.Data
{
    using System.Linq;

    using TikKok.Data.Common.Repositories;
    using TikKok.Data.Models;
    using TikKok.Web.ViewModels;

    public class ListUserService : IListUserService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;

        public ListUserService(IDeletableEntityRepository<ApplicationUser> usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public IQueryable GetAll(string userId)
        {
            var userInfo = this.usersRepository.All().Select(y => new UserViewModel
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
