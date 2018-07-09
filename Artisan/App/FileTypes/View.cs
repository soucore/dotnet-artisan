using Artisan.App.Core.Interface;

namespace Artisan.App.FileTypes
{
    public class View
    {   
        private IFileType FileType { get; }

        public View(IFileType fileType)
        {
            FileType = fileType;
            Configure();
            FileType.Initialize();
        }
        private void Configure()
        {
            FileType.SetTypeName("View");
            FileType.GetData()["extension"] = ".cshtml";
            FileType.GetPathToSaveFile().Add("class", $"{FileType.CurrenceDirectory()}\\..\\src\\Presentation\\Views\\{FileType.GetCommand(2).Name}");
        }
        
    }
}