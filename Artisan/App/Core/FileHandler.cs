using System;
using System.IO;
using Artisan.App.Core.Interface;

namespace Artisan.App.Core
{
    public class FileHandler : IFileHandler
    {
        private string Archive { get; set; }

        public IFileHandler SetArchive(string archive)
        {
            Archive = archive;
            return this;
        }

        public bool Write(string data, string path = null, bool subscribe = false)
        {
            if(!File.Exists(Archive))
            {
                return CreateAndWrite(data, path);
            }
            else
            {
                if(subscribe)
                {
                    File.Delete(Archive);
                    return CreateAndWrite(data, path);
                }
                else
                {
                    Console.WriteLine("O arquivo já existe! Use --force para reescrever o arquivo");
                    return false;
                }
            }
        }

        public string Read()
        {
            var data = string.Empty;
            if (!File.Exists(Archive)) return data;
            using (var read = new StreamReader(Archive))
            {
                data = read.ReadToEnd();
                read.Close();
            }

            return data;
        }
        
        public string ReadLastLine()
        {
            var data = string.Empty;
            if (!File.Exists(Archive)) return data;
            using (var read = new StreamReader(Archive))
            {
                while (read.Peek() >= 0)
                {
                    data = read.ReadLine();
                }
                    
                read.Close();
            }

            return data;
        }

        //todo: separar responsabilidades
        private bool CreateAndWrite(string data, string path)
        {
            if (!VerifyDirectory(path)) return false;
            using (var write = new StreamWriter(Archive, true))
            { 
                write.WriteLine(data);
                write.Close();
            }
            return true;

        }

        /// <summary>
        /// Verifica se dretório existe, caso o mesmo seja passado no parâmetro
        /// </summary>
        /// <param name="directory"></param>
        /// <returns></returns>
        private static bool VerifyDirectory(string directory)
        {
            if(directory != null)
            {
                try
                {
                    if(!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"O processo falhou: {e.Message}");
                    return false;
                }
            }
            else{
                return true;
            }
        }
    }
}
