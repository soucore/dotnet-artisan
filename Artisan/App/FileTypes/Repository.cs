using Artisan.App.Core.Interface;

namespace Artisan.App.FileTypes
{
    public class Repository
    {   
        private IFileType FileType { get; }

        public Repository(IFileType fileType)
        {
            FileType = fileType;
            Configure();
            FileType.Initialize();
        }
        private void Configure()
        {
            FileType.SetTypeName("Repository");
            FileType.GetPathToSaveFile().Add("class", $"{FileType.CurrenceDirectory()}\\..\\src\\Infra\\Data\\Repository");
            FileType.GetPathToSaveFile().Add("interface", $"{FileType.CurrenceDirectory()}\\..\\src\\Domain\\Interfaces\\Repository");

        }
    }
}