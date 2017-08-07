using Autofac;
using AutoMapper;
using VTSClient.Bll.Services;
using VTSClient.BLL.Interfaces;
using VTSClient.BLL.Services;
using VTSClient.Core.Infrastructure.Automapper;
using VTSClient.Core.Infrastructure.Automapper.Profiles;
using VTSClient.DAL.Infrastructure.Interfaces;
using VTSClient.DAL.Interfaces;
using VTSClient.DAL.Repositories;

namespace VTSClient.iOS.Infrastructure
{
	public static class IOSSetup
	{
		public static IContainer Container { get; set; }


		public static void Initialize()
		{
			var builder = new ContainerBuilder();


			builder.RegisterInstance(new DbLocation())
				.As<IDbLocation>();

			builder.Register(
					c => new MapperConfiguration(cfg =>
					{
						cfg.AddProfile(new DtoToEntityProfile());
						cfg.AddProfile(new EntityToDtoProfile());
					}))
				.AsSelf()
				.SingleInstance();

			builder.Register(
					c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve))
				.As<IMapper>()
				.InstancePerLifetimeScope();

			builder.RegisterType<SqlVacationService>().As<ISqlVacationService>();

			builder.RegisterType<ApiVacationService>().As<IApiVacationService>();

			builder.RegisterType<AccountService>().As<IAccountService>();

			builder.RegisterType<UserRepository>().As<IUserRepository>();

			builder.RegisterType<CommonApiRepository>().As<IApiRepository>();

			builder.RegisterGeneric(typeof(CommonSqlRepository<>))
				.As(typeof(ISqlRepository<>))
				.InstancePerDependency();

			AutoMapperCoreConfiguration.Configure();

			Container = builder.Build();
		}
	}
}
