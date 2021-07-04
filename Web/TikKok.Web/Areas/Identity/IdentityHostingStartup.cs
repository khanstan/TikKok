using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(TikKok.Web.Areas.Identity.IdentityHostingStartup))]

namespace TikKok.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}
