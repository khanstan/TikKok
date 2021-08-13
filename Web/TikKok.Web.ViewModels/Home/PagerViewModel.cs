namespace TikKok.Web.ViewModels.Home
{
    using System.Linq;

    using TikKok.Data.Models;

    public class PagerViewModel
    {
        public IQueryable<IndexViewModel> Items { get; set; }

        public Pager Pager { get; set; }
    }
}
