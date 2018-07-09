namespace Artisan.App.Core.Interface
{
    public interface ICommandHandler
    {
        void AddArgs(string[] args);
        CommandCollection GetCollection();
    }
}