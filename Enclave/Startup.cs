using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Enclave.Startup))]

namespace Enclave
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
