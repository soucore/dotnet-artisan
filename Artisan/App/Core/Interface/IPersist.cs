namespace Artisan.App.Core.Interface
{
    public interface IPersist
    {
        void Execute(string code, string path, string nameFile, bool subscribe);
    }
}