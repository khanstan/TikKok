namespace TikKok.Web.ViewModels.Home
{
    using System.Collections.Generic;

    using TikKok.Data.Models;

    public class IndexViewModel
    {
        public string VideoUrl { get; set; }

        public int VideosCount { get; set; }

        public IEnumerable<Video> Videos { get; set; }
    }
}