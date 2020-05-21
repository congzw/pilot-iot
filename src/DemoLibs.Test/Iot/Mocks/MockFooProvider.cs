using System.Collections.Generic;
using Demos.Iot.Providers;

namespace Demos.Iot.Mocks
{
    public class MockFooProvider : ICommandLocateProvider
    {
        public IList<CommandLocate> ImplCommandLocates()
        {
            var actionInfos = new List<CommandLocate>();
            actionInfos.Add(CommandLocate.Create("Foo", "Light", "On"));
            actionInfos.Add(CommandLocate.Create("Foo", "Light", "Off"));
            actionInfos.Add(CommandLocate.Create("Foo", "Curtain", "Open"));
            actionInfos.Add(CommandLocate.Create("Foo", "Curtain", "Close"));
            return actionInfos;
        }
    }
}
