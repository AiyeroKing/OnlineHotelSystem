using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnLineHotelOs.Startup))]
namespace OnLineHotelOs
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
