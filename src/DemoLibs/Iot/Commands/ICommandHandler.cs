namespace Demos.Iot.Commands
{
    public interface ICommandHandler
    {
        ICommand Command { get;}
        void Handle(ICommand cmd);
    }
}