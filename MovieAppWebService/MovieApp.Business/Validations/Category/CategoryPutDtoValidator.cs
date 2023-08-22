using FluentValidation;
using MovieApp.Business.Constants;
using MovieApp.Model.Dtos.Category;

namespace MovieApp.Business.Validations.Category
{
    public class CategoryPutDtoValidator : AbstractValidator<CategoryPutDto>
    {
        public CategoryPutDtoValidator() 
        {
            RuleFor(x => x.Id)
                .InclusiveBetween(1, int.MaxValue).WithMessage(ErrorMessages.InvalidId);

            RuleFor(x => x.Name.Trim())
                .NotEmpty().WithMessage("Name boş bırakılamaz.")
                .NotNull().WithMessage("Name null olamaz.")
                .MinimumLength(3).WithMessage("Name en az 3 karakter olmalıdır.");
        }
    }
}
