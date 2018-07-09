using Artisan.App.Core;
using Artisan.Bootstrap;
using Microsoft.Extensions.DependencyInjection;
using static Artisan.Bootstrap.Startup;

namespace Artisan
{
    public class Program
    {   
        public static void Main(string[] args)
        {
            ConfigureService();
            Startup.ServiceProvider.GetService<Build>().Start(args);
        }
    }
}
