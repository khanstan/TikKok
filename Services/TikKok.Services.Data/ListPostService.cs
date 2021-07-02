namespace TikKok.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using TikKok.Data.Common.Repositories;
    using TikKok.Data.Models;
    using TikKok.Data;
    using TikKok.Web.ViewModels.Home;

    public class ListPostService : IListPostService
    {

        private readonly IDeletableEntityRepository<Post> postsRepository;
        private readonly IDeletableEntityRepository<Video> videosRepository;

        public ListPostService(
            IDeletableEntityRepository<Post> postsRepository, IDeletableEntityRepository<Video> videosRepository)
        {
            this.postsRepository = postsRepository;
            this.videosRepository = videosRepository;
        }

        public IQueryable GetAll()
        {
            var postInfo = this.postsRepository.All().Select(y => new IndexViewModel
            {
                CredentialUsername = y.Video.Uploader.CredentialUsername,
                Path = y.Video.Path,
                Extension = y.Video.Extension,
                UploadDate = y.CreatedOn,
                UploaderId = y.Video.Uploader.UserName,
            });

            return postInfo;
        }

        public async Task DeleteAsync(string id)
        {

            var video = this.postsRepository.All().FirstOrDefault(x => x.Id == id);
            this.postsRepository.Delete(video);
            await this.postsRepository.SaveChangesAsync();
        }

    }
}
