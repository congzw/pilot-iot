
namespace Demos.Iot
{
    public class CommandResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public static CommandResult Create(bool success, string message, object data = null)
        {
            return new CommandResult() { Success = success, Message = message, Data = data };
        }

        public static CommandResult MethodResult(string method, bool success, object data = null)
        {
            var result = new CommandResult();
            result.Success = success;
            result.Data = data;
            result.Message = string.Format("{0}: {1} => {2}", method, success ? " Success" : " Fail", data);
            return result;
        }

        public static CommandResult SuccessResult(string message, object data = null)
        {
            var result = new CommandResult() { Message = message, Success = true, Data = data };
            return result;
        }

        public static CommandResult FailResult(string message, object data = null)
        {
            var result = new CommandResult() { Message = message, Success = false, Data = data };
            return result;
        }
    }
}