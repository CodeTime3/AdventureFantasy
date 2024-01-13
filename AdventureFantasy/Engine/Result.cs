namespace AdventureFantasy.Engine
{
    public class Result
    {
        public bool IsValid { get; }
        public string ErrorMessage { get; }

        public Result(bool isValid, string errorMessage) 
        {
            IsValid = isValid;
            ErrorMessage = errorMessage;
        }
    }
}
