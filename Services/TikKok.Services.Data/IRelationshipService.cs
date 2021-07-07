namespace TikKok.Services.Data
{
    using System.Threading.Tasks;

    public interface IRelationshipService
    {
        Task SetFollowAsync(string userToFollow, string currentUser);
    }
}