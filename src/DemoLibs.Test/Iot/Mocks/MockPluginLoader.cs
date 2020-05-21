using System.Collections.Generic;
using Demos.Iot.Mocks.PluginBlah;
using Demos.Iot.Mocks.PluginFoo;
using Demos.Iot.Plugin;

namespace Demos.Iot.Mocks
{
    public class MockPluginLoader : IPluginLoader
    {
        public IList<ICommandHandler> GetCommandHandlers()
        {
            //todo: use di container scan and find all providers!
            var providers = new List<ICommandHandler>();

            providers.Add(new FooLightOnCommandHandler());
            providers.Add(new FooLightOffCommandHandler());
            providers.Add(new FooCurtainOpenCommandHandler());
            providers.Add(new FooCurtainCloseCommandHandler());

            providers.Add(new BlahLightOnCommandHandler());
            providers.Add(new BlahLightOffCommandHandler());
            return providers;
        }
    }
}
