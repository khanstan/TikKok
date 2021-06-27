namespace TikKok.Services.Data
{
    using System.Threading.Tasks;

    using TikKok.Web.ViewModels.Video.Upload;

    public interface IVideoUploadService
    {
        Task CreateAsync(UploadVideoInputModel input, string userId, string videoPath);

        Task DeleteAsync(string id);
    }
}
