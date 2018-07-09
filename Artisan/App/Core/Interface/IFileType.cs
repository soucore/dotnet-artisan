using System.Collections.Generic;

namespace Artisan.App.Core.Interface
{
    public interface IFileType
    {
        IDictionary<string, string> GetData();
        IDictionary<string, string> GetPathToSaveFile();
        Command GetCommand(int indice);
        void SetTypeName(string name);
        string CurrenceDirectory();
        void Initialize();
    }
}