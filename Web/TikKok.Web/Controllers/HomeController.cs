namespace TikKok.Web.Controllers
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Mvc;
    using TikKok.Services.Data;
    using TikKok.Services.Data.Models;
    using TikKok.Web.ViewModels;
    using TikKok.Web.ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly IGetCountsService countsService;

        // private readonly IMapper mapper;
        public HomeController(IGetCountsService countsService /*IMapper mapper*/)
        {
            this.countsService = countsService;

            // this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var countsDto = this.countsService.GetCounts();

            // var viewModel = this.mapper.Map<IndexViewModel>(counts);
            var viewModel = new IndexViewModel
            {
                VideosCount = countsDto.VideosCount,
                TagsCount = countsDto.TagsCount,
                UsersCount = countsDto.UsersCount,
            };

            return this.View(viewModel);
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
