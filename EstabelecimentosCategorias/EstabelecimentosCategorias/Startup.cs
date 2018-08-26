using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EstabelecimentosCategorias.Startup))]
namespace EstabelecimentosCategorias
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
