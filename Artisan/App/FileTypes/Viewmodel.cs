using Artisan.App.Core.Interface;

namespace Artisan.App.FileTypes
{
    public class Viewmodel
    {   
        private IFileType FileType { get; }

        public Viewmodel(IFileType fileType)
        {
            FileType = fileType;
            Configure();
            FileType.Initialize();
        }
        private void Configure()
        {
            FileType.SetTypeName("Viewmodel");
            FileType.GetPathToSaveFile().Add("class", $"{FileType.CurrenceDirectory()}\\..\\src\\Application\\ViewModels");
        }
    }
}