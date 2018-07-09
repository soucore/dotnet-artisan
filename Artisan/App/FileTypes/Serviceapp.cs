using Artisan.App.Core.Interface;

namespace Artisan.App.FileTypes
{
    public class Serviceapp
    {   
        private IFileType FileType { get; }

        public Serviceapp(IFileType fileType)
        {
            FileType = fileType;
            Configure();
            FileType.Initialize();
        }
        private void Configure()
        {
            FileType.SetTypeName("Serviceapp");
            FileType.GetData().Add("varclass", FileType.GetCommand(2).Name.ToLower());
            FileType.GetPathToSaveFile().Add("class", $"{FileType.CurrenceDirectory()}\\..\\src\\Application");
            FileType.GetPathToSaveFile().Add("interface", $"{FileType.CurrenceDirectory()}\\..\\src\\Application\\Interfaces");

        }
    }
}