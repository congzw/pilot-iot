using System.Collections.Generic;
using Demos.Iot.Commands;
using Demos.Iot.Plugin;

namespace Demos.Iot.Mocks
{
    public class MockBlahProvider : ICommandProvider
    {
        public IList<Command> SupportCommands()
        {
            var actionInfos = new List<Command>();
            actionInfos.Add(Command.Create("Blah", "Light", "On"));
            actionInfos.Add(Command.Create("Blah", "Light", "Off"));
            return actionInfos;
        }
    }
}