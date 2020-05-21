using System;

namespace Demos.Iot
{
    public interface IManufacturerName
    {
        string Manufacturer { get; set; }
    }

    public interface IDeviceName
    {
        string Device { get; set; }
    }

    public interface IActionName
    {
        string Action { get; set; }
    }

    public interface ICommandLocate : IManufacturerName, IDeviceName, IActionName
    {
    }

    public static class CommandLocateExtensions
    {
        public static string GetLocateKey(this ICommandLocate locate)
        {
            if (locate == null)
            {
                throw new ArgumentNullException(nameof(locate));
            }
            return $"{locate.Manufacturer}.{locate.Device}.{locate.Action}".ToLower();
        }
    }
}
