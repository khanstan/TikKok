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
        private readonly string[] allowedExtensions = new[] { "mp4" };
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

        public async Task<string> CreateAsync(UploadVideoInputModel input, string userId, string videoPath, string rootPath)
        {
            //FFmpegDownloader.GetLatestVersion(FFmpegVersion.Official);
            // /wwwroot/videos/videos/jhdsi-343g3h453-=g34g.jpg
            FFmpeg.SetExecutablesPath(rootPath);
            Directory.CreateDirectory($"{videoPath}/videos/");

            var extension = Path.GetExtension(input.Video.FileName).TrimStart('.');
            if (!this.allowedExtensions.Any(x => extension.EndsWith(x)))
            {
                throw new Exception($"Invalid video extension {extension}");
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

            //video.Path = $"/videos/videos/{video.Id}.{extension}";

            using Stream fileStream = new FileStream(physicalPath, FileMode.Create);
            await input.Video.CopyToAsync(fileStream);

            var metaData = await FFmpeg.GetMediaInfo(physicalPath);
            var randomName = Guid.NewGuid();
            var isConverted = false;

            //if (metaData.VideoStreams.FirstOrDefault().Ratio != "9:16")
            //{
            //    video.Path = $"/videos/videos/converted_{randomName}.mp4";

            //    var converted = await FFmpeg.Conversions.New()
            //    .AddStream(metaData.Streams)
            //    .AddParameter($"-b:a 64k -ar 44.1k -movflags faststart -c:v libx264 -strict -2 -s 540x952 -psy 1 -psy-rd 1.00:0.00 -chromaoffset -2 -threads 30 -maxrate 4000k -bufsize 8000k -preset ultrafast -crf  24 {videoPath}/videos/converted_{randomName}.mp4")
            //    .Start();
            //    isConverted = true;
            //} else
            //{
                video.Path = $"/videos/videos/{video.Id}.{extension}";
            //}

            // THIS FUNCTION CONVERTS 19:6 TO 6:19 AND ADDS BLACK TOP AND BOTTOM!!!!!!!!

            // if (metaData.VideoStreams.FirstOrDefault().Ratio == "6:19")
            // {
            //    string ffmpeg = $"ffmpeg -i input.mp4 -vf "pad = iw:2 * trunc(iw * 16 / 18):(ow - iw) / 2:(oh - ih) / 2,setsar = 1" -c:a copy output.mp4";
            //    FFMpegConverter wrap = new FFMpegConverter();
            //    wrap.Invoke(ffmpeg);
            // }

            // video.Size = (int)metaData.Size;
            // video.Duration = metaData.Duration;
            await this.postsRepository.AddAsync(post);
            await this.postsRepository.SaveChangesAsync();

            if (isConverted)
            {
                return metaData.Path;
            } else
            {
                return null;
            }
        }

        public async Task DeleteAsync(string id)
        {
            var video = this.videosRepository.All().FirstOrDefault(x => x.Id == id);
            this.videosRepository.Delete(video);
            await this.videosRepository.SaveChangesAsync();
        }
    }
}
