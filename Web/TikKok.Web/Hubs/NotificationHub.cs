namespace TikKok.Web.Hubs
{
    using Microsoft.AspNetCore.SignalR;

    public class NotificationHub : Hub<INotificationHubClient>
    {
        public void NotifyUploaded(string username, string text)
        {
            this.Clients.Others.NotifyUploaded(text);
        }
    }
}