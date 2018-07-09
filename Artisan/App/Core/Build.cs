using System;
using Artisan.App.Core.Interface;
using Artisan.Bootstrap;
using Microsoft.Extensions.DependencyInjection;

namespace Artisan.App.Core
{
    //todo: criar instancia de comando automatico, sem precisar pré injetar. Ex: Make, Autoload, App
    public class Build
    {
        private readonly ICommandHandler _commands;
        
        public Build(ICommandHandler commandHandler)
        {
            _commands = commandHandler;
        }

        public void Start(string[] args)
        {
            _commands.AddArgs(args);
            LoadCommand();
        }
        
        private void LoadCommand()
        {
            var typeTreated = _commands.GetCollection()[0].NameInterface;
            var elementType = Type.GetType($"Artisan.App.Commands.Interface.{typeTreated}");

            if (elementType == null) throw new Exception("Commando não encontrado");
            Startup.ServiceProvider.GetRequiredService(elementType);
        }
    }
}