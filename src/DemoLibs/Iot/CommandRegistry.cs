using System;
using System.Collections.Generic;
using Demos.Iot.Providers;

namespace Demos.Iot
{
    public class CommandLocateRegistry
    {
        public CommandLocateRegistry()
        {
            CommandLocates = new Dictionary<string, CommandLocate>(StringComparer.OrdinalIgnoreCase);
        }

        public CommandLocateRegistry Init(IPluginLoader pluginLoader)
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
                var implCommandLocates = provider.ImplCommandLocates();
                foreach (var implCommandLocate in implCommandLocates)
                {
                    Register(implCommandLocate);
                }
            }
            return this;
        }

        public IDictionary<string, CommandLocate> CommandLocates { get; set; }

        public CommandLocateRegistry Register(CommandLocate locate)
        {
            if (locate == null)
            {
                throw new ArgumentNullException(nameof(locate));
            }

            if (CommandLocates.ContainsKey(locate.LocateKey))
            {
                throw new InvalidOperationException("command registered already: " + locate.LocateKey);
            }

            CommandLocates[locate.LocateKey] = locate;
            return this;
        }
    }
}
