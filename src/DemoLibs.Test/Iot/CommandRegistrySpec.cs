using System;
using Demos.Iot.Mocks;
using Demos._Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demos.Iot
{
    [TestClass]
    public class CommandRegistrySpec
    {
        [TestMethod]
        public void Init_Null_Should_Throws()
        {
            var actionInfoRegistry = new CommandRegistry();
            AssertHelper.ShouldThrows<ArgumentNullException>(() =>
            {
                actionInfoRegistry.Init(null);
            });
        }

        [TestMethod]
        public void Init_NotInvoke_Should_Empty()
        {
            var actionInfoRegistry = new CommandRegistry();
            actionInfoRegistry.Commands.Count.ShouldEqual(0);
        }
        
        [TestMethod]
        public void Init_WithProvider_Should_Ok()
        {
            var actionInfoRegistry = new CommandRegistry();
            actionInfoRegistry.Init(new MockPluginLoader());
            actionInfoRegistry.Commands.LogJson();
            actionInfoRegistry.Commands.Count.ShouldEqual(6);
        }
    }
}
