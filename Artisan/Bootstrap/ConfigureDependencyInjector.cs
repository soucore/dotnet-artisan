using Artisan.App.Core;
using Artisan.App.Core.Interface;
using Artisan.App.Commands;
using Artisan.App.Commands.Interface;
using Artisan.App.FileTypes;
using Microsoft.Extensions.DependencyInjection;

namespace Artisan.Bootstrap
{
    public static class ConfigureDependencyInjector
    {
        
        public static void Configure(IServiceCollection service)
        {
            service.AddSingleton<ICommandHandler, CommandHandler>();
            service.AddSingleton<IAppName, AppName>();
            service.AddTransient<IMake, Make>();
            service.AddTransient<IFileHandler, FileHandler>();
            service.AddTransient<IFileType, FileType>();
            service.AddTransient<IPersist, Persist>();
            
            service.AddTransient<Build>();
            service.AddTransient<CommandCollection>();
            service.AddTransient<Command>();
            service.AddTransient<Controller>();
            service.AddTransient<Model>();
            service.AddTransient<Modelconfig>();
            service.AddTransient<Repository>();
            service.AddTransient<Serviceapp>();
            service.AddTransient<Servicedomain>();
            service.AddTransient<Validator>();
            service.AddTransient<View>();
            service.AddTransient<Viewmodel>();
        }
    }
}