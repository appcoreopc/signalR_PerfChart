using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PerfBoardCast.Startup))]
namespace PerfBoardCast
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            
            app.MapSignalR();
        }
    }
}
