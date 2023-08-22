namespace MovieApp.Business.CustomExceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) 
        {
        }
    }
}
