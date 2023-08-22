using FluentValidation;
using MovieApp.Business.Constants;
using MovieApp.Model.Dtos.Country;

namespace MovieApp.Business.Validations.Country
{
    public class CountryPutDtoValidator : AbstractValidator<CountryPutDto>
    {
        public CountryPutDtoValidator() 
        {
            RuleFor(x => x.Id)
                .InclusiveBetween(1, int.MaxValue).WithMessage(ErrorMessages.InvalidId);

            RuleFor(x => x.Name.Trim())
                .NotEmpty().WithMessage("Name alanı boş bırakılamaz.")
                .NotNull().WithMessage("Name alanı null olamaz.")
                .MinimumLength(3).WithMessage("Name alanı en az 3 karakter olmalıdır.");
        }
    }
}
