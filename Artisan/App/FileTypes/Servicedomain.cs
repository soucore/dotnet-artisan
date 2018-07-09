using Artisan.App.Core.Interface;

namespace Artisan.App.FileTypes
{
    public class Servicedomain
    {    
        private IFileType FileType { get; }

        public Servicedomain(IFileType fileType)
        {
            FileType = fileType;
            Configure();
            FileType.Initialize();
        }
        private void Configure()
        {
            FileType.SetTypeName("Servicedomain");
            FileType.GetData().Add("varclass", FileType.GetCommand(2).Name.ToLower());
            FileType.GetPathToSaveFile().Add("class", $"{FileType.CurrenceDirectory()}\\..\\src\\Domain\\Services");
            FileType.GetPathToSaveFile().Add("interface", $"{FileType.CurrenceDirectory()}\\..\\src\\Domain\\Interfaces\\Services");

        }
    }
}