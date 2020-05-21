using System;
using System.Collections.Generic;
using System.Linq;

namespace Demos.Iot
{
    public interface ICommandRepository
    {
        IList<Command> GetCommands(GetCommandsArgs args);
    }

    public class GetCommandsArgs : ICommand
    {
        public string Manufacturer { get; set; }
        public string Device { get; set; }
        public string Action { get; set; }
    }

    public class CommandRepository : ICommandRepository
    {
        private readonly CommandRegistry _registry;

        public CommandRepository(CommandRegistry registry)
        {
            _registry = registry ?? throw new ArgumentNullException(nameof(registry));
        }

        public IList<Command> GetCommands(GetCommandsArgs args)
        {
            var query = _registry.Commands.Values.AsEnumerable();
            if (args == null)
            {
                return query.ToList();
            }

            if (!string.IsNullOrWhiteSpace(args.Manufacturer))
            {
                query = query.Where(x => x.Manufacturer.Equals(args.Manufacturer, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(args.Device))
            {
                query = query.Where(x => x.Device.Equals(args.Device, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(args.Action))
            {
                query = query.Where(x => x.Action.Equals(args.Action, StringComparison.OrdinalIgnoreCase));
            }

            return query.ToList();
        }
    }
}
