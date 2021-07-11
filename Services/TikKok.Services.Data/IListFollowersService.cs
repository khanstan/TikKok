using System.Linq;

namespace TikKok.Services.Data
{
    public interface IListFollowersService
    {
        IQueryable GetAll(string userId);
    }
}