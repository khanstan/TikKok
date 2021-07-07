namespace TikKok.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using TikKok.Data.Common.Repositories;
    using TikKok.Data.Models;

    public class RelationshipService : IRelationshipService
    {
        private readonly IRepository<UserFollow> userFollowRepository;

        public RelationshipService(IRepository<UserFollow> userFollowRepository)
        {
            this.userFollowRepository = userFollowRepository;
        }

        public async Task SetFollowAsync(string userToFollow, string currentUser )
        {
            var follow = this.userFollowRepository.All()
                .FirstOrDefault(x => x.FollowedUserId == userToFollow);

            if (follow == null)
            {
                follow = new UserFollow
                {
                    SourceUserId = currentUser,
                    FollowedUserId = userToFollow,
                };

                await this.userFollowRepository.AddAsync(follow);
            }
            else
            {
                this.userFollowRepository.Delete(follow);
            }

            await this.userFollowRepository.SaveChangesAsync();
        }
    }
}
