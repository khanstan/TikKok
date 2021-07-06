namespace TikKok.Web.Controllers
{
    using System.Security.Claims;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TikKok.Services.Data;
    using TikKok.Web.ViewModels.Profile;

    public class ProfileController : BaseController
    {
        private readonly IListProfileLikedService listProfileLikedService;
        private readonly IListProfileUploadedService listProfileUploadedService;

        public ProfileController(IListProfileLikedService listProfileLikedService, IListProfileUploadedService listProfileUploadedService)
        {
            this.listProfileLikedService = listProfileLikedService;
            this.listProfileUploadedService = listProfileUploadedService;
        }

        [Authorize]
        public IActionResult Liked(ProfileLikedViewModel model)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var viewModel = this.listProfileLikedService.GetAll(userId);
            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult Uploaded(ProfileUploadedViewModel model)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var viewModel = this.listProfileUploadedService.GetAll(userId);
            return this.View(viewModel);
        }
    }
}
