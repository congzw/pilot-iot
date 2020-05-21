using System;
using System.Collections.Generic;
using System.Linq;
using Demos.Iot.Commands;

namespace Demos.Iot.Discovers
{
    public interface ICommandDiscover
    {
        IList<Command> GetCommands(GetCommandsArgs args);
    }

    public class GetCommandsArgs : ICommandKey
    {
        public string Manufacturer { get; set; }
        public string Device { get; set; }
        public string Action { get; set; }
    }

    public class CommandDiscover : ICommandDiscover
    {
        private readonly CommandRegistry _registry;

        public CommandDiscover(CommandRegistry registry)
        {
            _registry = registry ?? throw new ArgumentNullException(nameof(registry));
        }

        public IList<Command> GetCommands(GetCommandsArgs args)
        {
            //if (args == null)
            //{
            //    throw new ArgumentNullException(nameof(args));
            //}

            var actionInfos = _registry.Commands.Values.AsEnumerable();
            if (args == null)
            {
                return actionInfos.ToList();
            }

            if (!string.IsNullOrWhiteSpace(args.Manufacturer))
            {
                actionInfos = actionInfos.Where(x => x.Manufacturer.Equals(args.Manufacturer, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(args.Device))
            {
                actionInfos = actionInfos.Where(x => x.Device.Equals(args.Device, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(args.Action))
            {
                actionInfos = actionInfos.Where(x => x.Action.Equals(args.Action, StringComparison.OrdinalIgnoreCase));
            }

            return actionInfos.ToList();
        }
    }
}
