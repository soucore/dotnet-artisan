using Microsoft.Extensions.DependencyInjection;

namespace Artisan.Bootstrap
{
    public static class Startup
    {
        private static IServiceCollection Service { get; set; }
        public static ServiceProvider ServiceProvider{ get; private set; }

        public static void ConfigureService()
        {
            Service = new ServiceCollection();
            Run();
            ServiceProvider = Service.BuildServiceProvider();
        }
            
        private static void Run() =>
            ConfigureDependencyInjector.Configure(Service);
    }
}