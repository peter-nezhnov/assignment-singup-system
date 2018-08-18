namespace SignUpSystem.Domain.Logic
{

    //this is not part of domain. It should be in a separate assembly with helpers and extensions. 
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