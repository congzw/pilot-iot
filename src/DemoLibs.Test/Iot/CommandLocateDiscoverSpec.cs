using Demos.Iot.Discovers;
using Demos.Iot.Mocks;
using Demos._Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demos.Iot
{
    [TestClass]
    public class CommandLocateDiscoverSpec
    {
        private CommandLocateDiscover _actionInfoDiscover;

        [TestInitialize]
        public void PrepareTest()
        {
            var actionInfoRegistry = new CommandLocateRegistry();
            actionInfoRegistry.Init(new MockPluginLoader());
            _actionInfoDiscover = new CommandLocateDiscover(actionInfoRegistry);
        }


        [TestMethod]
        public void GetCommandLocates_Empty_Should_GetAll()
        {
            var actionInfos = _actionInfoDiscover.GetCommandLocates(new GetCommandLocatesArgs());
            actionInfos.LogJson();
            actionInfos.Count.ShouldEqual(6);
        }

        [TestMethod]
        public void GetCommandLocates_Foo_Should_Ok()
        {
            var actionInfos = _actionInfoDiscover.GetCommandLocates(new GetCommandLocatesArgs() { Manufacturer = "FoO" });
            actionInfos.LogJson();
            actionInfos.Count.ShouldEqual(4);
        }

        [TestMethod]
        public void GetCommandLocates_Foo_Light_Should_Ok()
        {
            var actionInfos = _actionInfoDiscover.GetCommandLocates(new GetCommandLocatesArgs() { Manufacturer = "FoO", Device = "LIGHT"});
            actionInfos.LogJson();
            actionInfos.Count.ShouldEqual(2);
        }

        [TestMethod]
        public void GetCommandLocates_Light_Should_Ok()
        {
            var actionInfos = _actionInfoDiscover.GetCommandLocates(new GetCommandLocatesArgs() { Device = "LIGHT"});
            actionInfos.LogJson();
            actionInfos.Count.ShouldEqual(4);
        }
    }
}
