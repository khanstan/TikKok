namespace TikKok.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using TikKok.Data.Common.Repositories;
    using TikKok.Data.Models;

    public class LikesService : ILikesService
    {

        private readonly IRepository<Like> likesRepository;

        public LikesService(IRepository<Like> likesRepository)
        {
            this.likesRepository = likesRepository;
        }

        public async Task SetLikeAsync(string postId, string userId)
        {
            var like = this.likesRepository.All()
                .FirstOrDefault(x => x.PostId == postId && x.UserId == userId);

            if (like == null)
            {
                like = new Like
                {
                    PostId = postId,
                    UserId = userId,
                };

                await this.likesRepository.AddAsync(like);
            }
            else
            {
                this.likesRepository.Delete(like);
            }

            await this.likesRepository.SaveChangesAsync();
        }

        public int GetTotalLikes(string postId)
        {
            return this.likesRepository.All().Where(x => x.PostId == postId).Count();
        }
    }
}
