namespace TikKok.Web.Controllers
{
    using System.Security.Claims;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TikKok.Services.Data;
    using TikKok.Web.ViewModels.Home;
    using TikKok.Web.ViewModels.Profile;

    public class ProfileController : BaseController
    {
        private readonly IListProfileLikedService listProfileLikedService;

        public ProfileController(IListProfileLikedService listProfileLikedService)
        {
            this.listProfileLikedService = listProfileLikedService;
        }

        [Authorize]
        public IActionResult Index(ProfileLikedViewModel model)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var viewModel = this.listProfileLikedService.GetAll(userId);
            return this.View(viewModel);
        }
    }
}
