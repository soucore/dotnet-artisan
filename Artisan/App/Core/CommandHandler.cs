using System.Text.RegularExpressions;
using Artisan.App.Core.Interface;

namespace Artisan.App.Core
{
    public class CommandHandler : ICommandHandler
    {
        private CommandCollection Collection { get; }
        private string[] CommandString { get; set; }

        public CommandHandler()
        {
            Collection = new CommandCollection();
        }

        /// <summary>
        /// Adiciona argumentos no scopo da classe
        /// </summary>
        /// <param name="args"></param>
        public void AddArgs(string[] args)
        {
            CommandString = args;
            MakeCollection();
        }

        /// <summary>
        /// Monta a coleção de comando
        /// </summary>
        private void MakeCollection()
        {
            foreach (var command in CommandString)
            {
                SeparateCommand(command);
            }
        }

        /// <summary>
        /// Executa a separação do primeiro comando se necessário
        /// </summary>
        /// <param name="command"></param>
        private void SeparateCommand(string command)
        {
            if (Regex.IsMatch(command, ":"))
            {
                SplitCommand(command);
            }
            else
            {
                Collection.Add(new Command(command));
            }
        }

        /// <summary>
        /// Separa comando principal de comando de função
        /// </summary>
        /// <param name="command"></param>
        private void SplitCommand(string command)
        {
            var split = command.Split(':');
            if (split.Length != 2) return;
            Collection.Add(new Command(split[0]));
            Collection.Add(new Command(split[1]));
        }

        public CommandCollection GetCollection()
        {
            return Collection;
        }
    }
}