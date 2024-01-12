namespace AdventureFantasy.Engine
{
    public class Result
    {
        public bool IsValid { get; }
        public string ErrorMessage { get; }

        public Result(bool IsValid, string ErrorMessage) 
        {
            IsValid = IsValid;
            ErrorMessage = ErrorMessage;
        }
    }
}
