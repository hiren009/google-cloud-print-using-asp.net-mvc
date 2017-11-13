using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GoogleCloudPrint.Web.Startup))]
namespace GoogleCloudPrint.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
             
        }
    }
}
