using System.Collections.Generic;

namespace Demos.Iot.Providers
{
    public interface IPluginLoader
    {
        IList<IActionInfoProvider> LoadProviders();
    }
}