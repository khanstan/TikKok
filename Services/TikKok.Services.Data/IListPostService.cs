namespace TikKok.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using TikKok.Web.ViewModels.Home;

    public interface IListPostService
    {
        IQueryable<IndexViewModel> GetAll();

        IQueryable<IndexViewModel> GetAll(string userId);

        IndexViewModel GetSingle(string postId);

        IndexViewModel GetSingle(string postId, string userId);

        Task DeleteAsync(string id);
    }
}
