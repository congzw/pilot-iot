using System.Collections.Generic;
using Demos.Iot.Providers;

namespace Demos.Iot.Mocks
{
    public class MockFooProvider : IActionInfoProvider
    {
        public IList<ActionInfo> ImplActionInfos()
        {
            var actionInfos = new List<ActionInfo>();
            actionInfos.Add(ActionInfo.Create("Foo", "Light", "On"));
            actionInfos.Add(ActionInfo.Create("Foo", "Light", "Off"));
            actionInfos.Add(ActionInfo.Create("Foo", "Curtain", "Open"));
            actionInfos.Add(ActionInfo.Create("Foo", "Curtain", "Close"));
            return actionInfos;
        }
    }
}
