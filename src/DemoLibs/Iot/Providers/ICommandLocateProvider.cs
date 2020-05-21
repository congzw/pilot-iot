using System.Collections.Generic;

namespace Demos.Iot.Providers
{
    public interface ICommandLocateProvider
    {
        IList<CommandLocate> ImplCommandLocates();
    }
}
