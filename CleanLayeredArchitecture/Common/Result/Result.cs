
namespace Commmon.Result
{
    public class Result<T>
    {
        public bool Success { get; }

        public T Value { get; }

        public string Error { get; }

        public Result(T value)
        {
            Success = true;
            Value = value;
            Error = string.Empty;
        }

        public Result(string error)
        {
            Success = false;
            Error = error;
            Value = default;
        }

        public static Result<T> SuccessResult(T value) => new Result<T>(value);

        public static Result<T> FailureResult(string error) => new Result<T>(error);
    }

}
