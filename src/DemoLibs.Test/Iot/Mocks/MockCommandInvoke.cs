using System.Diagnostics;

namespace Demos.Iot.Mocks
{
    public class MockCommandInvoke
    {
        public static void Invoke(Command command, params object[] args)
        {
            Trace.WriteLine(string.Format("invoke {0} success with context {1}", command.GetLocateKey(), args));
        }
    }
}
