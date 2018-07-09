using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Artisan.App.Core.Interface;

namespace Artisan.App.Core
{
    //todo: generalizar e refatorar classe
    public class FileType : IFileType
    {
        private const string RegExp = "\\{\\[([a-z0-9]+)\\]\\}";
        private IAppName AppName { get;}
        private IFileHandler FileHandler { get; set; }
        private IPersist Persist { get; }
        private readonly IDictionary<string, string> _data;
        private readonly IDictionary<string, string> _pathToSaveFile;
        private readonly IDictionary<string, string> _tplFile;
        private readonly string _currentDirectory;
        private ICommandHandler Commands { get; }
        private string TypeName{get; set; }
        
        public FileType(ICommandHandler commands, IAppName appName, IFileHandler fileHandler, IPersist persist)
        {
            Commands = commands;
            AppName = appName;
            FileHandler = fileHandler;
            Persist = persist;
            _data = new Dictionary<string, string>();
            _tplFile = new Dictionary<string, string>();
            _pathToSaveFile = new Dictionary<string, string>();
            _currentDirectory = Directory.GetCurrentDirectory();
            
            Build(); 
        }

        /// <summary>
        /// Constrói dados para inicialização de processo
        /// </summary>
        private void Build()
        {   
            _data.Add("namespace", AppName.GetNamespace());
            _data.Add("class", Commands.GetCollection()[2].Name);
            _data.Add("extension", ".cs");
            
            //todo: atualizar caminhos do template
            _tplFile.Add("class", $"{_currentDirectory}\\Templates\\{Commands.GetCollection()[1].Name}.t");
            _tplFile.Add("interface", $"{_currentDirectory}\\Templates\\Interfaces\\{Commands.GetCollection()[1].Name}.t");
        }

        public void Initialize() => InstanceFilesBuildAndStore(_tplFile);

        /// <summary>
        /// Inicia instâncias FileHandler para tratamento de arquivos
        /// </summary>
        /// <param name="tplFile">Caminho do template</param>
        private void InstanceFilesBuildAndStore(IDictionary<string, string> tplFile)
        {
            foreach(KeyValuePair<string, string> file in tplFile)
            {
                var fl = FileHandler.SetArchive(file.Value);
                var strFile = fl.Read();
                var strCode = Parse(strFile);
                var pathVerifield = PathVerifield(file.Key);
                if(!string.IsNullOrEmpty(pathVerifield))
                {
                    Store(strCode, _pathToSaveFile[file.Key], FileName(file.Key), CanBeRewritten());
                } 
            }  
        }

        /// <summary>
        /// Retorna nomenclatura correta para nomes de arquivos (classes e interfaces)
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private string FileName(string key)
        {
            var i = string.Empty;
            
            if(key == "interface") i = "I";
            return _data.TryGetValue("filename", out var aux) 
                ? $"{i + aux}.cs" 
                : $"{i + aux + Commands.GetCollection()[2].Name + TypeName + _data["extension"]}";
        }        

        /// <summary>
        /// Verifica a chave
        /// </summary>
        /// <param name="key">string</param>
        /// <returns>string</returns>
        private string PathVerifield(string key)
        {
            return _pathToSaveFile.TryGetValue(key, out var cl) ? cl : string.Empty;
        }

        /// <summary>
        /// Analisa a string do template para realizar a ligação de variáveis
        /// de acordo com dados obtidos
        /// </summary>
        /// <param name="strTpl">string lida do template</param>
        /// <returns>string modificda</returns>
        private string Parse(string strTpl)
        {
            return Regex.Replace(strTpl, RegExp, m => GetMatch(m, _data));
        }

        /// <summary>
        /// Realiza o data bind no template retornando uma string modificada
        /// </summary>
        /// <param name="m"></param>
        /// <param name="data"></param>
        /// <returns>string</returns>
        private static string GetMatch(Match m, IDictionary<string, string> data)
        {
            if (!m.Success) return string.Empty;
            var key = m.Result("$1");
            return data[key];
        }
        
        /// <summary>
        /// Verifica se o arquivo deve ou não ser reescrito
        /// </summary>
        /// <returns>bool</returns>
        private bool CanBeRewritten()
        {
            var command = Commands.GetCollection().FindLastIndex(c => c.Name == "--force");
            return command != -1;
        }

        /// <summary>
        /// persiste novo arquivo
        /// </summary>
        /// <param name="code"></param>
        /// <param name="file"></param>
        /// <param name="nameFile"></param>
        /// <param name="canBeRewriten"></param>
        private void Store(string code, string file, string nameFile, bool canBeRewriten)
        {
            Persist.Execute(code, file, nameFile, canBeRewriten);
        }

        /// <summary>
        /// Chaves com respectivos valores para interpretação do template
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, string> GetData()
        {
            return _data;
        }

        /// <summary>
        /// Local onde será salvo o arquivo
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, string> GetPathToSaveFile()
        {
            return _pathToSaveFile;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="indice"></param>
        /// <returns></returns>
        public Command GetCommand(int indice)
        {
            return Commands.GetCollection()[indice];
        }

        /// <summary>
        /// Nome do arquivo
        /// </summary>
        /// <param name="name"></param>
        public void SetTypeName(string name)
        {
            TypeName = name;
        }

        /// <summary>
        /// Captura o diretório atual
        /// </summary>
        /// <returns></returns>
        public string CurrenceDirectory()
        {
            return _currentDirectory;
        }
    }
}