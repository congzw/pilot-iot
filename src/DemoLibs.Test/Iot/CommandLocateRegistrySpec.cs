using System;
using Demos.Iot.Mocks;
using Demos._Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demos.Iot
{
    [TestClass]
    public class CommandLocateRegistrySpec
    {
        [TestMethod]
        public void Init_Null_Should_Throws()
        {
            var actionInfoRegistry = new CommandLocateRegistry();
            AssertHelper.ShouldThrows<ArgumentNullException>(() =>
            {
                actionInfoRegistry.Init(null);
            });
        }

        [TestMethod]
        public void Init_NotInvoke_Should_Empty()
        {
            var actionInfoRegistry = new CommandLocateRegistry();
            actionInfoRegistry.CommandLocates.Count.ShouldEqual(0);
        }
        
        [TestMethod]
        public void Init_WithProvider_Should_Ok()
        {
            var actionInfoRegistry = new CommandLocateRegistry();
            actionInfoRegistry.Init(new MockPluginLoader());
            actionInfoRegistry.CommandLocates.LogJson();
            actionInfoRegistry.CommandLocates.Count.ShouldEqual(6);
        }
    }
}
