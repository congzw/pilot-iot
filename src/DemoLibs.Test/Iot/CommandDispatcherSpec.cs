using Demos.Iot.Mocks;
using Demos._Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demos.Iot
{
    [TestClass]
    public class CommandDispatcherSpec
    {
        private CommandDispatcher _commandDispatcher;

        [TestInitialize]
        public void PrepareTest()
        {
            var mockPluginLoader = new MockPluginLoader();
            _commandDispatcher = new CommandDispatcher(mockPluginLoader.GetCommandHandlers());
        }

        [TestMethod]
        public void Dispatch_Exist_ShouldSuccess()
        {
            var command = Command.Create("Foo", "Light", "On");
            //app logic: get command context in store such as database, eg: device ip, port, ect...
            var commandResult = _commandDispatcher.Dispatch(command, "Whatever Context Object");
            commandResult.Message.Log();
            commandResult.Success.ShouldTrue();
        }

        [TestMethod]
        public void Dispatch_NotExist_ShouldSuccess()
        {
            var command = Command.Create("Xxx", "Light", "On");
            var commandResult = _commandDispatcher.Dispatch(command, "Whatever Context Object");
            commandResult.Message.Log();
            commandResult.Success.ShouldFalse();
        }
    }
}
