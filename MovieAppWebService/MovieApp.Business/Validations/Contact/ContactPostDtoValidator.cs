using FluentValidation;
using MovieApp.Model.Dtos.Contact;

namespace MovieApp.Business.Validations.Contact
{
    public class ContactPostDtoValidator : AbstractValidator<ContactPostDto>
    {
        public ContactPostDtoValidator()
        {
            RuleFor(x => x.Firstname.Trim())
                .NotNull().WithMessage("İsim alanı boş bırakılamaz.")
                .NotEmpty().WithMessage("İsim alanı boş bırakılamaz.")
                .MinimumLength(2).WithMessage("İsim en az 2 karakter içermelidir.");

            RuleFor(x => x.Lastname.Trim())
                .NotNull().WithMessage("Soyisim alanı boş bırakılamaz.")
                .NotEmpty().WithMessage("Soyisim alanı boş bırakılamaz.")
                .MinimumLength(2).WithMessage("Soyisim en az 2 karakter içermelidir.");

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Lütfen bir email adresi giriniz.");

            RuleFor(x => x.CountryId)
                .InclusiveBetween(1, int.MaxValue).WithMessage("Ülke seçiniz.");

            RuleFor(x => x.Subject)
                .MinimumLength(3).WithMessage("Lütfen bir konu giriniz.");

            RuleFor(x => x.Message)
                .MinimumLength(10).WithMessage("Lütfen bir mesaj giriniz.");
        }
    }
}
