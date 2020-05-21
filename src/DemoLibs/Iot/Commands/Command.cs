namespace Demos.Iot.Commands
{
    public interface ICommand : ICommandLocate
    {
        object Context { get; set; }
    }
    
    public class Command : ICommand
    {
        public string Manufacturer { get; set; }
        public string Device { get; set; }
        public string Action { get; set; }
        public object Context { get; set; }
    }
}
