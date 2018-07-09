using Artisan.App.Core.Interface;

namespace Artisan.App.FileTypes
{
    public class Controller
    {
        private IFileType FileType { get; }

        public Controller(IFileType fileType)
        {
            FileType = fileType;
            Configure();
            FileType.Initialize();
        }
        private void Configure()
        {
            FileType.SetTypeName("Controller");
            FileType.GetData().Add("varclass", FileType.GetCommand(2).Name.ToLower());
            FileType.GetPathToSaveFile().Add("class", $"{FileType.CurrenceDirectory()}\\..\\src\\Presentation\\Controllers");
        }
    }
}