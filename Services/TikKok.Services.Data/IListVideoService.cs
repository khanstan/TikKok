namespace TikKok.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    public interface IListVideoService
    {
        IQueryable GetAll();

        Task DeleteAsync(string id);
    }
}
