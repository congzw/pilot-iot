using System.Collections.Generic;

namespace Demos.Iot.Plugin
{
    public interface ICommandProviderLoader
    {
        IList<ICommandProvider> LoadProviders();
    }
}