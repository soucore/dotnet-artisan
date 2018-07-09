using Artisan.App.Core.Interface;

namespace Artisan.App.FileTypes
{
    public class Model
    {     
        private IFileType FileType { get; set; }

        public Model(IFileType fileType)
        {
            FileType = fileType;
            Configure();
            FileType.Initialize();
        }
        private void Configure()
        {
            FileType.SetTypeName("Model");
            FileType.GetData().Add("filename", FileType.GetCommand(2).Name);
            FileType.GetPathToSaveFile().Add("class", $"{FileType.CurrenceDirectory()}\\..\\src\\Domain\\Models");
        }
    }
}