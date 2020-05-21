using System.Collections.Generic;
using Demos.Iot.Providers;

namespace Demos.Iot.Mocks
{
    public class MockBlahProvider : IActionInfoProvider
    {
        public IList<ActionInfo> ImplActionInfos()
        {
            var actionInfos = new List<ActionInfo>();
            actionInfos.Add(ActionInfo.Create("Blah", "Light", "On"));
            actionInfos.Add(ActionInfo.Create("Blah", "Light", "Off"));
            return actionInfos;
        }
    }
}