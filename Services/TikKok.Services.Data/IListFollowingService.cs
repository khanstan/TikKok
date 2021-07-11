using System.Linq;

namespace TikKok.Services.Data
{
    public interface IListFollowingService
    {
        IQueryable GetAll(string userId);
    }
}