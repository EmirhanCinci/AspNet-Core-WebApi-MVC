using FluentValidation;
using MovieApp.Model.Dtos.PersonType;

namespace MovieApp.Business.Validations.PersonType
{
    public class PersonTypePostDtoValidator : AbstractValidator<PersonTypePostDto>
    {
        public PersonTypePostDtoValidator() 
        {
            RuleFor(x => x.Type.Trim())
                .NotNull().WithMessage("Type alanı null olamaz.")
                .NotEmpty().WithMessage("Type alanı boş bırakılamaz.")
                .MinimumLength(2).WithMessage("Type alanı en az 2 karakter olmalıdır.");
        }
    }
}
