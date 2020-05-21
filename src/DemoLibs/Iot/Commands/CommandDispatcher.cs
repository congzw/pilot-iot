using System.Collections.Generic;

namespace Demos.Iot.Commands
{
    public class CommandDispatcher
    {
        private readonly IEnumerable<ICommandHandler> _handlers;

        public CommandDispatcher(IEnumerable<ICommandHandler> handlers)
        {
            _handlers = handlers;
        }

        public void Dispatch(ICommand cmd)
        {
            foreach (var handler in _handlers)
            {
                if (handler.Command.GetLocateKey() == cmd.GetLocateKey())
                {
                    handler.Handle(cmd);
                }
            }
        }
    }
}