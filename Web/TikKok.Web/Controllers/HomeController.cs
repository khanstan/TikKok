namespace TikKok.Web.Controllers
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
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
        }

        public IActionResult Index(int? page)
        {
            if (this.User.Identity.IsAuthenticated)
            {
                var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

                var dummyItems = this.listPostService.GetAll(userId);
                var pager = new Pager(dummyItems.Count(), page);

                var viewModel = new PagerViewModel
                {
                    Items = dummyItems.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize),
                    Pager = pager,
                };

                return this.View(viewModel);
            }
            else
            {
                var dummyItems = this.listPostService.GetAll();
                var pager = new Pager(dummyItems.Count(), page);

                var viewModel = new PagerViewModel
                {
                    Items = dummyItems.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize),
                    Pager = pager,
                };

                return this.View(viewModel);
            }
        }

        public IActionResult Post(string postId = "f7212977-5703-40e6-8f70-1123a0406a93")
        {
            if (this.User.Identity.IsAuthenticated)
            {
                var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var viewModel = this.listPostService.GetSingle(postId, userId);
                return this.View(viewModel);
            }
            else
            {
                var viewModel = this.listPostService.GetSingle(postId);
                return this.View(viewModel);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
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
