using FluentValidation;
using MovieApp.Model.Dtos.Category;

namespace MovieApp.Business.Validations.Category
{
    public class CategoryPostDtoValidator : AbstractValidator<CategoryPostDto>
    {
        public CategoryPostDtoValidator() 
        {
            RuleFor(x => x.Name.Trim())
               .NotEmpty().WithMessage("Name alanı boş bırakılamaz.")
               .NotNull().WithMessage("Name alanı null olamaz.")
               .MinimumLength(3).WithMessage("Name alanı en az 3 karakter olmalıdır.");
        }
    }
}
