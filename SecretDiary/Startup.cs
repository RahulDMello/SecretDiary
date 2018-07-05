using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SecretDiary.Startup))]
namespace SecretDiary
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
