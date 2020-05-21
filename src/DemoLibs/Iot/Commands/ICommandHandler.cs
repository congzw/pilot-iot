namespace Demos.Iot.Commands
{
    public interface ICommandHandler
    {
        bool ShouldHandle(ICommand cmd);
        void Handle(ICommand cmd);
    }
}