namespace SignUpSystem.Domain.Models
{
    public class Result
    {
        public Result(bool success)
        {

        }

        public static Result FailedResult => new Result(false);

        public static Result SuccessResult => new Result(true);

        public readonly bool Success;
    }
}
