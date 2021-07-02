namespace TikKok.Web.ViewModels.Video.Upload
{
    using Microsoft.AspNetCore.Http;

    public class UploadVideoInputModel
    {
        public IFormFile Video { get; set; }

        public string Description { get; set; }
    }
}
