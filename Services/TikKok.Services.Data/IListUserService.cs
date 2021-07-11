using System.Linq;

namespace TikKok.Services.Data
{
    public interface IListUserService
    {
        IQueryable GetAll(string userId);
    }
}