using System.Collections.Generic;
using Demos.Iot.Plugin;

namespace Demos.Iot.Mocks
{
    public class MockPluginLoader : ICommandProviderLoader
    {
        public IList<ICommandProvider> LoadProviders()
        {
            //todo: use di container scan and find all providers!
            var providers = new List<ICommandProvider>();
            providers.Add(new MockFooProvider());
            providers.Add(new MockBlahProvider());
            return providers;
        }
    }
}
