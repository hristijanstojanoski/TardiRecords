using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TardiRecords.Startup))]
namespace TardiRecords
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
