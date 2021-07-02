namespace TikKok.Services.Data
{
    using Microsoft.AspNetCore.Identity;
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
        private readonly IDeletableEntityRepository<Post> postsRepository;
        private readonly IDeletableEntityRepository<Video> videosRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;

        public VideoUploadService(IDeletableEntityRepository<Post> postsRepository, IDeletableEntityRepository<Video> videosRepository,
        UserManager<ApplicationUser> userManager, IDeletableEntityRepository<ApplicationUser> usersRepository)
        {
            this.postsRepository = postsRepository;
            this.videosRepository = videosRepository;
            this.userManager = userManager;
            this.usersRepository = usersRepository;
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
                //Uploader = this.usersRepository.All().Where(x => x.Id == UploaderId).Select(x => x.UserName),
                UploaderId = userId,
                Extension = extension,
            };

            var post = new Post
            {
                Video = video,
                Description = "Add a desctiption form",
                //Tags = new Tag {
                //    Name = "Choose appropriate tags!",
                //},
            };



            var physicalPath = $"{videoPath}/videos/{video.Id}.{extension}";

            video.Path = $"/videos/videos/{video.Id}.{extension}";

            using Stream fileStream = new FileStream(physicalPath, FileMode.Create);
            await input.Video.CopyToAsync(fileStream);

            await this.postsRepository.AddAsync(post);
            await this.postsRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var video = this.videosRepository.All().FirstOrDefault(x => x.Id == id);
            this.videosRepository.Delete(video);
            await this.videosRepository.SaveChangesAsync();
        }
    }
}
