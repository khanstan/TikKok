namespace TikKok.Web.Controllers
{
    using System;
    using System.Diagnostics;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using TikKok.Data.Models;
    using TikKok.Services.Data;
    using TikKok.Web.ViewModels;
    using TikKok.Web.ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly IGetCountsService countsService;
        private readonly IListPostService listPostService;
        private readonly UserManager<ApplicationUser> userManager;

        public HomeController(IGetCountsService countsService, IListPostService listPostService, UserManager<ApplicationUser> userManager)
        {
            this.countsService = countsService;
            this.listPostService = listPostService;
            this.userManager = userManager;

            // this.mapper = mapper;
        }

        public IActionResult Index(IndexViewModel model)
        {
            if (this.User.Identity.IsAuthenticated)
            {
                var test = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var viewModel = this.listPostService.GetAll(test);
                return this.View(viewModel);
            }
            else
            {
                var viewModel = this.listPostService.GetAll();
                return this.View(viewModel);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            await this.listPostService.DeleteAsync(id);
            return this.Redirect("/");
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
