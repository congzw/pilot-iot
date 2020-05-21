using System.Collections.Generic;
using Demos.Iot.Providers;

namespace Demos.Iot.Mocks
{
    public class MockBlahProvider : ICommandLocateProvider
    {
        public IList<CommandLocate> ImplCommandLocates()
        {
            var actionInfos = new List<CommandLocate>();
            actionInfos.Add(CommandLocate.Create("Blah", "Light", "On"));
            actionInfos.Add(CommandLocate.Create("Blah", "Light", "Off"));
            return actionInfos;
        }
    }
}