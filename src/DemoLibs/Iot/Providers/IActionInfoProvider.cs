using System.Collections.Generic;

namespace Demos.Iot.Providers
{
    public interface IActionInfoProvider
    {
        IList<ActionInfo> ImplActionInfos();
    }
}
