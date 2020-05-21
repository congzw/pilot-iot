using Demos.Iot.Mocks;
using Demos._Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demos.Iot
{
    [TestClass]
    public class CommandRepositorySpec
    {
        private CommandRepository _actionInfoDiscover;

        [TestInitialize]
        public void PrepareTest()
        {
            var actionInfoRegistry = new CommandRegistry();
            actionInfoRegistry.Init(new MockPluginLoader());
            _actionInfoDiscover = new CommandRepository(actionInfoRegistry);
        }


        [TestMethod]
        public void GetCommands_Empty_Should_GetAll()
        {
            var actionInfos = _actionInfoDiscover.GetCommands(new GetCommandsArgs());
            actionInfos.LogJson();
            actionInfos.Count.ShouldEqual(6);
        }

        [TestMethod]
        public void GetCommands_Foo_Should_Ok()
        {
            var actionInfos = _actionInfoDiscover.GetCommands(new GetCommandsArgs() { Manufacturer = "FoO" });
            actionInfos.LogJson();
            actionInfos.Count.ShouldEqual(4);
        }

        [TestMethod]
        public void GetCommands_Foo_Light_Should_Ok()
        {
            var actionInfos = _actionInfoDiscover.GetCommands(new GetCommandsArgs() { Manufacturer = "FoO", Device = "LIGHT"});
            actionInfos.LogJson();
            actionInfos.Count.ShouldEqual(2);
        }

        [TestMethod]
        public void GetCommands_Light_Should_Ok()
        {
            var actionInfos = _actionInfoDiscover.GetCommands(new GetCommandsArgs() { Device = "LIGHT"});
            actionInfos.LogJson();
            actionInfos.Count.ShouldEqual(4);
        }
    }
}
