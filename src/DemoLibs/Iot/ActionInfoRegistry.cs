using System;
using System.Collections.Generic;
using Demos.Iot.Providers;

namespace Demos.Iot
{
    public class ActionInfoRegistry
    {
        public ActionInfoRegistry()
        {
            ActionInfos = new Dictionary<string, ActionInfo>(StringComparer.OrdinalIgnoreCase);
        }

        public ActionInfoRegistry Init(IPluginLoader pluginLoader)
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
                var implActionInfos = provider.ImplActionInfos();
                foreach (var implActionInfo in implActionInfos)
                {
                    Register(implActionInfo);
                }
            }
            return this;
        }

        public IDictionary<string, ActionInfo> ActionInfos { get; set; }

        public ActionInfoRegistry Register(ActionInfo info)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            if (ActionInfos.ContainsKey(info.LocateKey))
            {
                throw new InvalidOperationException("action registered already: " + info.LocateKey);
            }

            ActionInfos[info.LocateKey] = info;
            return this;
        }
    }
}
