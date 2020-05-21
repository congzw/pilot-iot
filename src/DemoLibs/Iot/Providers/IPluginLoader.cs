using System.Collections.Generic;

namespace Demos.Iot.Providers
{
    public interface IPluginLoader
    {
        IList<ICommandLocateProvider> LoadProviders();
    }
}