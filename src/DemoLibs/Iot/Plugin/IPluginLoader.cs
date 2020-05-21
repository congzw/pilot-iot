using System.Collections.Generic;

namespace Demos.Iot.Plugin
{
    public interface IPluginLoader
    {
        IList<ICommandHandler> GetCommandHandlers();
    }
}
