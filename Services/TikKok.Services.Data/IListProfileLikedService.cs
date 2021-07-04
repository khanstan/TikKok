namespace TikKok.Services.Data
{
    using System.Linq;

    public interface IListProfileLikedService
    {
        IQueryable GetAll(string userId);
    }
}
