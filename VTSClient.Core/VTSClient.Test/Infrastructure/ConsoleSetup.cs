using Autofac;
using VTSClient.Core.Infrastructure.DI;

namespace VTSClient.Test.Infrastructure
{
    public static class ConsoleSetup
    {
        public static IContainer Container { get; set; }

        public static void Initialize()
        {
            var builder = new ContainerBuilder();

            CoreSetup.Init(builder);

            Container = builder.Build();
        }
    }
}
