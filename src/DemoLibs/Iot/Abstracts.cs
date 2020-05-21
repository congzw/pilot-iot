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

    public interface ICommandKey : IManufacturerName, IDeviceName, IActionName
    {
    }

    public static class CommandExtensions
    {
        public static string GetLocateKey(this ICommandKey locate)
        {
            if (locate == null)
            {
                throw new ArgumentNullException(nameof(locate));
            }
            return $"{locate.Manufacturer}.{locate.Device}.{locate.Action}".ToLower();
        }
    }
}
