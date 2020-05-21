using System;
using System.Collections.Generic;
using System.Linq;

namespace Demos.Iot.Discovers
{
    public interface ICommandLocateDiscover
    {
        IList<CommandLocate> GetCommandLocates(GetCommandLocatesArgs args);
    }

    public class GetCommandLocatesArgs : ICommandLocate
    {
        public string Manufacturer { get; set; }
        public string Device { get; set; }
        public string Action { get; set; }
    }

    public class CommandLocateDiscover : ICommandLocateDiscover
    {
        private readonly CommandLocateRegistry _registry;

        public CommandLocateDiscover(CommandLocateRegistry registry)
        {
            _registry = registry ?? throw new ArgumentNullException(nameof(registry));
        }

        public IList<CommandLocate> GetCommandLocates(GetCommandLocatesArgs args)
        {
            //if (args == null)
            //{
            //    throw new ArgumentNullException(nameof(args));
            //}

            var actionInfos = _registry.CommandLocates.Values.AsEnumerable();
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
