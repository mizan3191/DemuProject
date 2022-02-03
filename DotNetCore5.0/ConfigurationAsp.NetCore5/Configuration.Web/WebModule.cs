using Autofac;
using Configuration.Web.Models;

namespace Configuration.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UpdateProfileModel>().AsSelf();

            base.Load(builder);
        }
    }
}
