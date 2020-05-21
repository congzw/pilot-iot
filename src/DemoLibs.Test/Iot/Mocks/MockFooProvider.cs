using System.Collections.Generic;
using Demos.Iot.Commands;
using Demos.Iot.Plugin;

namespace Demos.Iot.Mocks
{
    public class MockFooProvider : ICommandProvider
    {
        public IList<Command> SupportCommands()
        {
            var commands = new List<Command>();
            commands.Add(Command.Create("Foo", "Light", "On"));
            commands.Add(Command.Create("Foo", "Light", "Off"));
            commands.Add(Command.Create("Foo", "Curtain", "Open"));
            commands.Add(Command.Create("Foo", "Curtain", "Close"));
            return commands;
        }
    }
}
