namespace TikKok.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using TikKok.Data;
    using TikKok.Services.Data;
    using TikKok.Web.ViewModels;
    using TikKok.Web.ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly ApplicationDbContext db;
        private readonly IGetCountsService countsService;
        private readonly IMapper mapper;

        public HomeController(IGetCountsService countsService, IMapper mapper)
        {
            this.countsService = countsService;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var counts = this.countsService.GetCounts();

            var viewModel = this.mapper.Map<IndexViewModel>(counts);

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
