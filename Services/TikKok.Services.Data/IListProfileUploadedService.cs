namespace TikKok.Services.Data
{
    using System.Linq;

    public interface IListProfileUploadedService
    {
        IQueryable GetAll(string userId);
    }
}
