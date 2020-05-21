using Demos.Iot.Discovers;
using Demos.Iot.Mocks;
using Demos._Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demos.Iot
{
    [TestClass]
    public class ActionInfoDiscoverSpec
    {
        private ActionInfoRegistry _actionInfoRegistry;

        [TestInitialize]
        public void PrepareTest()
        {
            _actionInfoRegistry = new ActionInfoRegistry();
            _actionInfoRegistry.Init(new MockPluginLoader());
        }


        [TestMethod]
        public void GetActionInfos_Empty_Should_GetAll()
        {
            var actionInfoDiscover = new ActionInfoDiscover(_actionInfoRegistry);
            var actionInfos = actionInfoDiscover.GetActionInfos(new GetActionInfosArgs());
            actionInfos.LogJson();
            actionInfos.Count.ShouldEqual(6);
        }

        [TestMethod]
        public void GetActionInfos_Foo_Should_Ok()
        {
            var actionInfoDiscover = new ActionInfoDiscover(_actionInfoRegistry);
            var actionInfos = actionInfoDiscover.GetActionInfos(new GetActionInfosArgs() { Manufacturer = "FoO" });
            actionInfos.LogJson();
            actionInfos.Count.ShouldEqual(4);
        }

        [TestMethod]
        public void GetActionInfos_Foo_Light_Should_Ok()
        {
            var actionInfoDiscover = new ActionInfoDiscover(_actionInfoRegistry);
            var actionInfos = actionInfoDiscover.GetActionInfos(new GetActionInfosArgs() { Manufacturer = "FoO", Device = "LIGHT"});
            actionInfos.LogJson();
            actionInfos.Count.ShouldEqual(2);
        }

        [TestMethod]
        public void GetActionInfos_Light_Should_Ok()
        {
            var actionInfoDiscover = new ActionInfoDiscover(_actionInfoRegistry);
            var actionInfos = actionInfoDiscover.GetActionInfos(new GetActionInfosArgs() { Device = "LIGHT"});
            actionInfos.LogJson();
            actionInfos.Count.ShouldEqual(4);
        }
    }
}
