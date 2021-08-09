namespace TikKok.Services.Data
{
    using System.Threading.Tasks;

    using TikKok.Web.ViewModels.Video.Upload;

    public interface IVideoUploadService
    {
        Task<string> CreateAsync(UploadVideoInputModel input, string userId, string videoPath, string rootPath);

        Task DeleteAsync(string id);
    }
}
