using FluentValidation;
using MovieApp.Business.Constants;
using MovieApp.Model.Dtos.Person;

namespace MovieApp.Business.Validations.Person
{
    public class PersonPutDtoValidator : AbstractValidator<PersonPutDto>
    {
        public PersonPutDtoValidator() 
        {
            RuleFor(x => x.Id)
                .InclusiveBetween(1, int.MaxValue).WithMessage(ErrorMessages.InvalidId);

            RuleFor(x => x.Firstname.Trim())
                .NotNull().WithMessage("Firstname null olamaz.")
                .NotEmpty().WithMessage("Firstname boş bırakılamaz.")
                .MinimumLength(2).WithMessage("Firstname alanı en az 2 karakter içermelidir.");

            RuleFor(x => x.Lastname.Trim())
                .NotNull().WithMessage("Lastname null olamaz.")
                .NotEmpty().WithMessage("Lastname boş bırakılamaz.")
                .MinimumLength(2).WithMessage("Lastname alanı en az 2 karakter içermelidir.");

            RuleFor(x => x.CountryId).
                InclusiveBetween(1, int.MaxValue).WithMessage("CountryId değeri 0'dan büyük olmalıdır.");

            RuleFor(x => x.GenderId)
                .InclusiveBetween(1, 2).WithMessage("GenderId değeri 1 ya da 2 olmalıdır.");

            RuleFor(x => x.ShortDescription.Trim())
                .MinimumLength(5).WithMessage("ShortDescription alanı en az 5 karakter içermelidir.");

            RuleFor(x => x.Description.Trim())
                .MinimumLength(5).WithMessage("Description alanı en az 5 karakter içermelidir.");
        }
    }
}
