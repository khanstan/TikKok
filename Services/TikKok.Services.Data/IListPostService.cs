namespace TikKok.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    public interface IListPostService
    {
        IQueryable GetAll();

        Task DeleteAsync(string id);

        Task Like(string postId);
    }
}
