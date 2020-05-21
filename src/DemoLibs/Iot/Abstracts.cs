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

    public static class CommandKeyExtensions
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
    
    public interface ICommandContext : ICommandKey
    {
        object Context { get; set; }
    }

    public class Command : ICommandContext
    {
        public string Manufacturer { get; set; }
        public string Device { get; set; }
        public string Action { get; set; }
        public string LocateKey => this.GetLocateKey();

        public object Context { get; set; }

        public static Command Create(string manufacturer, string device, string action)
        {
            if (string.IsNullOrWhiteSpace(manufacturer))
            {
                throw new ArgumentNullException(nameof(manufacturer));
            }
            if (string.IsNullOrWhiteSpace(device))
            {
                throw new ArgumentNullException(nameof(device));
            }
            if (string.IsNullOrWhiteSpace(action))
            {
                throw new ArgumentNullException(nameof(action));
            }

            return new Command()
            {
                Manufacturer = manufacturer,
                Device = device,
                Action = action
            };
        }
    }

    public interface ICommandHandler
    {
        Command Command { get; }
        void Handle(Command cmd, object context);
    }
}
