namespace TikKok.Web.Controllers
{
    using System.Security.Claims;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TikKok.Services.Data;
    using TikKok.Web.ViewModels.Followers;

    public class FollowersController : Controller
    {
        private readonly IListFollowingService listFollowingService;
        private readonly IListFollowersService listFollowersService;

        public FollowersController(IListFollowingService listFollowingService, IListFollowersService listFollowersService)
        {
            this.listFollowingService = listFollowingService;
            this.listFollowersService = listFollowersService;
        }

        [Authorize]
        public IActionResult Followed(FollowersViewModel model)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var viewModel = this.listFollowersService.GetAll(userId);
            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult Following(FollowingViewModel model)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var viewModel = this.listFollowingService.GetAll(userId);
            return this.View(viewModel);
        }
    }
}
