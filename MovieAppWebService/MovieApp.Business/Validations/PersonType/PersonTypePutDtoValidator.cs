using FluentValidation;
using MovieApp.Business.Constants;
using MovieApp.Model.Dtos.PersonType;

namespace MovieApp.Business.Validations.PersonType
{
    public class PersonTypePutDtoValidator : AbstractValidator<PersonTypePutDto>
    {
        public PersonTypePutDtoValidator() 
        {
            RuleFor(x => x.Id)
                .InclusiveBetween(1, int.MaxValue).WithMessage("Id alanı boş bırakılamaz.");

            RuleFor(x => x.Type.Trim())
                .NotNull().WithMessage("Type alanı null olamaz.")
                .NotEmpty().WithMessage("Type alanı boş bırakılamaz.")
                .MinimumLength(2).WithMessage("Type alanı en az 2 karakter olmalıdır.");
        }
    }
}
