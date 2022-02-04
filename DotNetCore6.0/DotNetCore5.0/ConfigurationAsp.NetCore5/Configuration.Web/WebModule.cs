using Autofac;
using Configuration.Web.Models;

namespace Configuration.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CreateUserModel>().AsSelf();
            builder.RegisterType<EditUserModel>().AsSelf();
            builder.RegisterType<UserDataReadModel>().AsSelf();
            builder.RegisterType<TableModel>().AsSelf();

            base.Load(builder);
        }
    }
}
