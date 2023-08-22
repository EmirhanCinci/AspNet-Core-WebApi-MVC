using FluentValidation;
using MovieApp.Business.CustomExceptions;

namespace Infrastructure.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                List<string> errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();
                throw new BadRequestException(string.Join(" - ", errorMessages));
            }
        }
    }
}
