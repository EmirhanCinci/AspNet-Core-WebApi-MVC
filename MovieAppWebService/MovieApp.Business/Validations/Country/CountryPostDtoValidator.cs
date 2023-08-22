using FluentValidation;
using MovieApp.Model.Dtos.Country;

namespace MovieApp.Business.Validations.Country
{
    public class CountryPostDtoValidator : AbstractValidator<CountryPostDto>
    {
        public CountryPostDtoValidator()
        {
            RuleFor(x => x.Name.Trim())
                .NotEmpty().WithMessage("Name alanı boş bırakılamaz.")
                .NotNull().WithMessage("Name alanı null olamaz.")
                .MinimumLength(3).WithMessage("Name alanı en az 3 karakter olmalıdır.");
        }
    }
}
