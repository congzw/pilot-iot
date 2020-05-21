using System;
using Demos.Iot.Mocks;
using Demos._Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demos.Iot
{
    [TestClass]
    public class ActionInfoRegistrySpec
    {
        [TestMethod]
        public void Init_Null_Should_Throws()
        {
            var actionInfoRegistry = new ActionInfoRegistry();
            AssertHelper.ShouldThrows<ArgumentNullException>(() =>
            {
                actionInfoRegistry.Init(null);
            });
        }

        [TestMethod]
        public void Init_NotInvoke_Should_Empty()
        {
            var actionInfoRegistry = new ActionInfoRegistry();
            actionInfoRegistry.ActionInfos.Count.ShouldEqual(0);
        }
        
        [TestMethod]
        public void Init_WithProvider_Should_Ok()
        {
            var actionInfoRegistry = new ActionInfoRegistry();
            actionInfoRegistry.Init(new MockPluginLoader());
            actionInfoRegistry.ActionInfos.LogJson();
            actionInfoRegistry.ActionInfos.Count.ShouldEqual(6);
        }
    }
}
