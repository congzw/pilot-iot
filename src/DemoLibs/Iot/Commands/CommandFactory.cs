using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demos.Iot.Commands
{
    public interface ICommandService
    {
        Command CreateCommand(ICommand locate);
    }

    public class CommandFactory
    {
        
    }
}
