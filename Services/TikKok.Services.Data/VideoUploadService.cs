namespace TikKok.Services.Data
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using TikKok.Data.Common.Repositories;
    using TikKok.Data.Models;
    using TikKok.Web.ViewModels.Video.Upload;

    public class VideoUploadService : IVideoUploadService
    {
        private readonly string[] allowedExtensions = new[] { "mp4", "avi" };
        private readonly IDeletableEntityRepository<Video> videosRepository;

        public VideoUploadService(IDeletableEntityRepository<Video> videosRepository)
        {
            this.videosRepository = videosRepository;
        }

        public async Task CreateAsync(UploadVideoInputModel input, string userId, string videoPath)
        {
            // /wwwroot/videos/videos/jhdsi-343g3h453-=g34g.jpg
            Directory.CreateDirectory($"{videoPath}/videos/");

            var extension = Path.GetExtension(input.Video.FileName).TrimStart('.');
            if (!this.allowedExtensions.Any(x => extension.EndsWith(x)))
            {
                throw new Exception($"Invalid image extension {extension}");
            }

            var video = new Video
            {
                UploaderId = userId,
                Extension = extension,
            };

            var physicalPath = $"{videoPath}/videos/{video.Id}.{extension}";

            video.Path = $"/videos/videos/{video.Id}.{extension}";

            using Stream fileStream = new FileStream(physicalPath, FileMode.Create);
            await input.Video.CopyToAsync(fileStream);

            await this.videosRepository.AddAsync(video);
            await this.videosRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var video = this.videosRepository.All().FirstOrDefault(x => x.Id == id);
            this.videosRepository.Delete(video);
            await this.videosRepository.SaveChangesAsync();
        }
    }
}
