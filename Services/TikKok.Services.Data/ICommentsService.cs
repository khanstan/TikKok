namespace TikKok.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using TikKok.Data.Models;
    using TikKok.Web.ViewModels.Comments;

    public interface ICommentsService
    {
        IQueryable GetAll(string postId);

        Task<CommentsViewModel> AddComment(CommentsInputModel input, string userId);

    }
}
