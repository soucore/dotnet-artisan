namespace Artisan.App.Core.Interface
{
    public interface IFileHandler
    {
        IFileHandler SetArchive(string archive);
        bool Write(string data, string path = null, bool subscribe = false);
        string Read();
        string ReadLastLine();
    }
}