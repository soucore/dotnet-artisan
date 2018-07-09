using System;
using Artisan.App.Commands.Interface;
using Artisan.App.Core.Interface;
using Artisan.Bootstrap;

namespace Artisan.App.Commands
{
    public class Make : IMake
    {
        private readonly ICommandHandler _commands;

        public Make(ICommandHandler commands)
        {
            _commands = commands;
            Initialize();
        }
        
        public void Initialize()
        {
            var typeTreated = _commands.GetCollection()[1].NameClass;
            var elementType = Type.GetType($"Artisan.App.FileTypes.{typeTreated}");
            Startup.ServiceProvider.GetService(elementType);
        }
    }
}