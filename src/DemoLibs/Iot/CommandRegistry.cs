using System;
using System.Collections.Generic;
using Demos.Iot.Commands;
using Demos.Iot.Plugin;

namespace Demos.Iot
{
    public class CommandRegistry
    {
        public CommandRegistry()
        {
            Commands = new Dictionary<string, Command>(StringComparer.OrdinalIgnoreCase);
        }

        public CommandRegistry Init(ICommandProviderLoader pluginLoader)
        {
            if (pluginLoader == null)
            {
                throw new ArgumentNullException(nameof(pluginLoader));
            }

            var providers = pluginLoader.LoadProviders();
            if (providers == null || providers.Count == 0)
            {
                return this;
            }

            foreach (var provider in providers)
            {
                var commandKeys = provider.SupportCommands();
                foreach (var commandKey in commandKeys)
                {
                    Register(commandKey);
                }
            }
            return this;
        }

        public IDictionary<string, Command> Commands { get; set; }

        public CommandRegistry Register(Command locate)
        {
            if (locate == null)
            {
                throw new ArgumentNullException(nameof(locate));
            }

            if (Commands.ContainsKey(locate.LocateKey))
            {
                throw new InvalidOperationException("command registered already: " + locate.LocateKey);
            }

            Commands[locate.LocateKey] = locate;
            return this;
        }
    }
}
