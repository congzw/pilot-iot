using System.Collections.Generic;
using Demos.Iot.Commands;

namespace Demos.Iot.Plugin
{
    public interface ICommandProvider
    {
        IList<Command> SupportCommands();
    }
}
