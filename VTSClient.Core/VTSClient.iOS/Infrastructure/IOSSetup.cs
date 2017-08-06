using Autofac;
using VTSClient.Core.Infrastructure.DI;
using VTSClient.DAL.Infrastructure.Interfaces;

namespace VTSClient.iOS
{
	public static class IOSSetup
	{
		public static IContainer Container { get; set; }

		public static void Initialize()
		{
			var builder = new ContainerBuilder();

			builder.RegisterInstance(new IOSDbLocation())
				   .As<IDbLocation>();

			CoreSetup.Init(builder);

			IOSSetup.Container = builder.Build();
		}
	}
}
