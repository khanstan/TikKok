using System.Threading.Tasks;

namespace TikKok.Services.Data
{
    public interface ILikesService
    {
        Task SetLikeAsync(string postId, string userId);

        int GetTotalLikes(string postId);
    }
}