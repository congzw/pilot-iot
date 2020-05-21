using System;
using System.Collections.Generic;
using Demos.Iot.Plugin;

namespace Demos.Iot
{
    public class CommandRegistry
    {
        public CommandRegistry()
        {
            Commands = new Dictionary<string, Command>(StringComparer.OrdinalIgnoreCase);
        }

        public CommandRegistry Init(IPluginLoader pluginLoader)
        {
            if (pluginLoader == null)
            {
                throw new ArgumentNullException(nameof(pluginLoader));
            }

            var handlers = pluginLoader.GetCommandHandlers();
            if (handlers == null || handlers.Count == 0)
            {
                return this;
            }
            foreach (var handler in handlers)
            {
                var command = handler.Command;
                Register(command);
            }
            return this;
        }

        public IDictionary<string, Command> Commands { get; set; }

        public CommandRegistry Register(Command command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            var locateKey = command.GetLocateKey();
            if (Commands.ContainsKey(locateKey))
            {
                throw new InvalidOperationException("command registered already: " + locateKey);
            }

            Commands[locateKey] = command;
            return this;
        }
    }
}
