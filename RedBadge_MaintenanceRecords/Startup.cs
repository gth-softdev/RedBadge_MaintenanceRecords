using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RedBadge_MaintenanceRecords.Startup))]
namespace RedBadge_MaintenanceRecords
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
