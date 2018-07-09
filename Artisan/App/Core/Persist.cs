using System;
using Artisan.App.Core.Interface;

namespace Artisan.App.Core
{
    public class Persist : IPersist
    {
        private IFileHandler FileheHandler { get; }
        private string Code { get; set; }
        private string Path { get; set; }
        private string NameFile { get; set; }        
        
        
        public Persist(IFileHandler fileheHandler)
        {
            FileheHandler = fileheHandler;
        }

        public void Execute(string code, string path, string nameFile, bool subscribe)
        {
            Code = code;
            Path = path;
            NameFile = nameFile;            
            FileheHandler.SetArchive($"{path}\\{nameFile}");
            ExecuteWrite(subscribe);
        }
        
        private void ExecuteWrite(bool subscribe)
        {   
            if(FileheHandler.Write(Code, Path, subscribe))
            {
                Console.WriteLine($"{NameFile} criado com sucesso!");
            }
        }
    }
}