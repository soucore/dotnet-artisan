using System.IO;
using Artisan.App.Core.Interface;

namespace Artisan.App.Core
{
    public class AppName : IAppName
    {
        private string Namespace { get; set; }
        private string DirName { get; set; }
        private string Dir { get; set; }
        public AppName()
        {
            var dirinfo = Directory.GetParent(Directory.GetCurrentDirectory());
            Dir = dirinfo.FullName;
            DirName = Path.GetFileName(Dir);
            Namespace = string.Empty;
            SetNamespace();
        }

        /*-------------------------------------------------------------------
            Seta namespace na propriedade
        --------------------------------------------------------------------*/
        public void SetNamespace()
        {
            if(GetNameSolution().Length == 0)
            {
                Namespace = DirName;
                //todo: Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\dotnet");
            }
        }

        /*-------------------------------------------------------------------
            Captura namespace para persistir com base no arquivo de .sln
            ou nome da pasta principal caso .sln não exista
        --------------------------------------------------------------------*/
        public string GetNameSolution()
        {
            if (!Directory.Exists(Dir)) return Namespace;
            var dir = new DirectoryInfo(Dir);
            var files = dir.GetFiles("*.sln", SearchOption.TopDirectoryOnly);
            foreach(var file in files)
            {
                if (file.Extension != ".sln") continue;
                Namespace = file.Name.Replace(".sln", "");
                break;
            }

            return Namespace;
        }

        public string GetNamespace()
        {
            return Namespace;
        }
    }
}