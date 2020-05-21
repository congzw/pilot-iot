namespace Demos.Iot.Mocks
{
    public abstract class MockCommandHandler : ICommandHandler
    {
        protected MockCommandHandler(string manufacturer, string device, string action)
        {
            Command = Command.Create(manufacturer, device, action);
        }

        public Command Command { get; }

        public virtual void Handle(Command cmd, object context)
        {
            MockCommandInvoke.Invoke(cmd, context);
        }
    }
}
