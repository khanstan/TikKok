namespace TikKok.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    public interface IListPostService
    {
        IQueryable GetAll();

        IQueryable GetAll(string userId);

        Task DeleteAsync(string id);
    }
}
