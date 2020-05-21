using System;

namespace Demos.Iot
{
    public class CommandLocate : ICommandLocate
    {
        public string Manufacturer { get; set; }
        public string Device { get; set; }
        public string Action { get; set; }

        public string LocateKey => this.GetLocateKey();

        public static CommandLocate Create(string manufacturer, string device, string action)
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

            return new CommandLocate()
            {
                Manufacturer = manufacturer,
                Device = device,
                Action = action
            };
        }
    }
}