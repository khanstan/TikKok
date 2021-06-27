namespace TikKok.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;
    using TikKok.Data.Common.Repositories;
    using TikKok.Data.Models;

    public class ListVideoService : IListVideoService
    {

        private readonly IDeletableEntityRepository<Video> videosRepository;

        public ListVideoService(
            IDeletableEntityRepository<Video> videosRepository)
        {
            this.videosRepository = videosRepository;
        }

        public IQueryable GetAll() => this.videosRepository.All();

        public async Task DeleteAsync(string id)
        {
            var video = this.videosRepository.All().FirstOrDefault(x => x.Id == id);
            this.videosRepository.Delete(video);
            await this.videosRepository.SaveChangesAsync();
        }

    }
}
