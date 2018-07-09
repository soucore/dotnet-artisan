using System.Collections.Generic;
using Artisan.App.Core;
using Artisan.App.Core.Interface;
using FT = Artisan.App.Core.FileType;

namespace Artisan.App.FileTypes
{
    //todo: class em experimento
    public class ConfigureFileType : FT, IFileType
    {
        public ConfigureFileType(ICommandHandler commands, IAppName appName, IFileHandler fileHandler, IPersist persist) 
            : base(commands, appName, fileHandler, persist)
        {
        }

        public IDictionary<string, string> GetData()
        {
            throw new System.NotImplementedException();
        }

        public IDictionary<string, string> GetPathToSaveFile()
        {
            throw new System.NotImplementedException();
        }

        public Command GetCommand(int indice)
        {
            throw new System.NotImplementedException();
        }

        public void SetTypeName(string name)
        {
            throw new System.NotImplementedException();
        }

        public string CurrenceDirectory()
        {
            throw new System.NotImplementedException();
        }
    }
}