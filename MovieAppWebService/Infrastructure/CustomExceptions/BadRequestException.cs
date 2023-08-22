using FluentValidation.Results;

namespace MovieApp.Business.CustomExceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message)
        {
        }
    }
}
