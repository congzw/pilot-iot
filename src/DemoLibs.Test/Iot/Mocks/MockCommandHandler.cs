namespace Demos.Iot.Mocks
{
    public abstract class MockCommandHandler : ICommandHandler
    {
        protected MockCommandHandler(string manufacturer, string device, string action)
        {
            Command = Command.Create(manufacturer, device, action);
        }

        public Command Command { get; }

        public virtual CommandResult Handle(object context)
        {
            return MockCommandInvoke.Invoke(Command, context);
        }
    }
}
