namespace TikKok.Web.Controllers
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using TikKok.Data.Models;
    using TikKok.Services.Data;
    using TikKok.Services.Data.Models;
    using TikKok.Web.ViewModels;
    using TikKok.Web.ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly IGetCountsService countsService;
        private readonly IListVideoService listVideoService;

        public HomeController(IGetCountsService countsService, IListVideoService listVideoService)
        {
            this.countsService = countsService;
            this.listVideoService = listVideoService;

            // this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var viewModel = this.listVideoService.GetAll();

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            await this.listVideoService.DeleteAsync(id);
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
