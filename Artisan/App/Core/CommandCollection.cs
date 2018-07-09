using System.Collections.Generic;
using System.Linq;

namespace Artisan.App.Core
{
    public class CommandCollection : List<Command>
    {
        public Command this[string name] 
        {
            get
            {
                return this.SingleOrDefault(command => command.Name == name);
            }   
        }
    }
}