using System.Diagnostics;

namespace Demos.Iot.Mocks
{
    public class MockCommandInvoke
    {
        public static CommandResult Invoke(Command command, object args)
        {
            var successResult = CommandResult.SuccessResult(string.Format("{0} => success invoked with context '{1}'", command.GetLocateKey(), args));
            Trace.WriteLine("<<mock invoke complete!>>");
            return successResult;
        }
    }
}
