using Autofac;
using Configuration.Membership.Contexts;
using Configuration.Membership.Repositories;
using Configuration.Membership.Services;
using Configuration.Membership.UnitOfWorks;
using System;

namespace Configuration.Membership
{
    public class MembershipModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public MembershipModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<ApplicationDbContext>().AsSelf()
            //    .WithParameter("connectionString", _connectionString)
            //    .WithParameter("migrationAssemblyName", _migrationAssemblyName)
            //    .InstancePerLifetimeScope();

            //builder.RegisterType<ApplicationDbContext>().As<IApplicationDbContext>()
            //    .WithParameter("connectionString", _connectionString)
            //    .WithParameter("migrationAssemblyName", _migrationAssemblyName)
            //    .InstancePerLifetimeScope();

            builder.RegisterType<MembershipDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<MembershipDbContext>().As<IMembershipDbContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<MembershipUnitOfWork>().As<IMembershipUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<GroupService>().As<IGroupService>().InstancePerLifetimeScope();
            builder.RegisterType<UserInformationRepository>().As<IUserInformationRepository>().InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}