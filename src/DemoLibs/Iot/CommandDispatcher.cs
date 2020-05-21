using System.Collections.Generic;

namespace Demos.Iot
{
    public class CommandDispatcher
    {
        private readonly IEnumerable<ICommandHandler> _handlers;

        public CommandDispatcher(IEnumerable<ICommandHandler> handlers)
        {
            _handlers = handlers;
        }

        public CommandResult Dispatch(ICommand cmd, object context)
        {
            foreach (var handler in _handlers)
            {
                if (handler.Command.GetLocateKey() == cmd.GetLocateKey())
                {
                    var commandResult = handler.Handle(context);
                    return commandResult;
                }
            }

            return CommandResult.FailResult("Not find handler for: " + cmd, context);
        }
    }
}