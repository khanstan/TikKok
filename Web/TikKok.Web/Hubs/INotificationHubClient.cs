namespace TikKok.Web.Hubs
{
    using System.Threading.Tasks;

    public interface INotificationHubClient
    {
        Task NotifyUploaded(string message);
    }
}
