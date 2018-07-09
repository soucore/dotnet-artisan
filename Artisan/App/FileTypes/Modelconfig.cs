using Artisan.App.Core.Interface;

namespace Artisan.App.FileTypes
{
    public class Modelconfig
    {   
        private IFileType FileType { get; }

        public Modelconfig(IFileType fileType)
        {
            FileType = fileType;
            Configure();
            FileType.Initialize();
        }
        private void Configure()
        {
            FileType.SetTypeName("Modelconfig");
            FileType.GetPathToSaveFile().Add("class", $"{FileType.CurrenceDirectory()}\\..\\src\\Infra\\Data\\ModelConfig");
        }
    }
}