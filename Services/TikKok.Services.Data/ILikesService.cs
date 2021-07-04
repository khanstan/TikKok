namespace TikKok.Services.Data
{
    using System.Threading.Tasks;

    public interface ILikesService
    {
        Task SetLikeAsync(string postId, string userId);

        int GetTotalLikes(string postId);

    }
}