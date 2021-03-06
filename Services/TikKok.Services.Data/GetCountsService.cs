namespace TikKok.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TikKok.Data.Common.Repositories;
    using TikKok.Data.Models;
    using TikKok.Services.Data.Models;
    using TikKok.Web.ViewModels.Home;

    public class GetCountsService : IGetCountsService
    {
        private readonly IDeletableEntityRepository<Video> videosRepository;
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;

        public GetCountsService(
            IDeletableEntityRepository<Video> videosRepository,
            IDeletableEntityRepository<ApplicationUser> usersRepository)
        {
            this.videosRepository = videosRepository;
            this.usersRepository = usersRepository;
        }

        public CountsDto GetCounts()
        {
            var data = new CountsDto
            {
                VideosCount = this.videosRepository.All().Count(),
                UsersCount = this.usersRepository.All().Count()
            };

            return data;
        }
    }
}
