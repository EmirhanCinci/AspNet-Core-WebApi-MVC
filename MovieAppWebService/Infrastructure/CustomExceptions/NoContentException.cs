namespace MovieApp.Business.CustomExceptions
{
    public class NoContentException : Exception
    {
        public NoContentException(string message) : base(message) 
        {
            
        }
    }
}
