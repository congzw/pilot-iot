using System.Collections.Generic;
using Demos.Iot.Providers;

namespace Demos.Iot.Mocks
{
    public class MockPluginLoader : IPluginLoader
    {
        public IList<ICommandLocateProvider> LoadProviders()
        {
            //todo: use di container scan and find all providers!
            var actionInfoProviders = new List<ICommandLocateProvider>();
            actionInfoProviders.Add(new MockFooProvider());
            actionInfoProviders.Add(new MockBlahProvider());
            return actionInfoProviders;
        }
    }
}
