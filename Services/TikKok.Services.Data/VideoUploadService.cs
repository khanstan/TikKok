namespace TikKok.Services.Data
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using TikKok.Data.Common.Repositories;
    using TikKok.Data.Models;
    using TikKok.Web.ViewModels.Video.Upload;
    using Xabe.FFmpeg;
    using Xabe.FFmpeg.Downloader;

    public class VideoUploadService : IVideoUploadService
    {
        private readonly string[] allowedExtensions = new[] { "mp4", "avi" };
        private readonly IDeletableEntityRepository<Post> postsRepository;
        private readonly IDeletableEntityRepository<Video> videosRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;

        public VideoUploadService(
            IDeletableEntityRepository<Post> postsRepository,
            IDeletableEntityRepository<Video> videosRepository,
            UserManager<ApplicationUser> userManager,
            IDeletableEntityRepository<ApplicationUser> usersRepository)
        {
            this.postsRepository = postsRepository;
            this.videosRepository = videosRepository;
            this.userManager = userManager;
            this.usersRepository = usersRepository;
        }

        public async Task CreateAsync(UploadVideoInputModel input, string userId, string videoPath, string rootPath)
        {
            // /wwwroot/videos/videos/jhdsi-343g3h453-=g34g.jpg
            FFmpeg.SetExecutablesPath(rootPath);
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

            var post = new Post
            {
                Video = video,
                Description = input.Description,
                UserId = userId,
                // Tags = new Tag {
                //    Name = "Choose appropriate tags!",
                // },
            };

            var physicalPath = $"{videoPath}/videos/{video.Id}.{extension}";

            video.Path = $"/videos/videos/{video.Id}.{extension}";

            using Stream fileStream = new FileStream(physicalPath, FileMode.Create);

            await input.Video.CopyToAsync(fileStream);

            var metaData = await FFmpeg.GetMediaInfo($"wwwroot/{post.Video.Path}");


            // THIS FUNCTION CONVERTS 19:6 TO 6:19 AND ADDS BLACK TOP AND BOTTOM!!!!!!!!

            // if (metaData.VideoStreams.FirstOrDefault().Ratio == "6:19")
            // {
            //    string ffmpeg = $"ffmpeg -i input.mp4 -vf "pad = iw:2 * trunc(iw * 16 / 18):(ow - iw) / 2:(oh - ih) / 2,setsar = 1" -c:a copy output.mp4";
            //    FFMpegConverter wrap = new FFMpegConverter();
            //    wrap.Invoke(ffmpeg);
            // }

            video.Size = (int)metaData.Size;
            video.Duration = metaData.Duration;

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
