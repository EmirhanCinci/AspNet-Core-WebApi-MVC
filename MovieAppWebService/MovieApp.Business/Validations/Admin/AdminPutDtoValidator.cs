using FluentValidation;
using MovieApp.Model.Dtos.Admin;

namespace MovieApp.Business.Validations.Admin
{
    public class AdminPutDtoValidator : AbstractValidator<AdminPutDto>
    {
        public AdminPutDtoValidator() 
        {
            RuleFor(x => x.Id)
                .InclusiveBetween(1, int.MaxValue).WithMessage("Id değeri 0'dan büyük olmalıdır.");

            RuleFor(x => x.Firstname.Trim())
                .NotNull().WithMessage("Firstname alanı null olamaz.")
                .NotEmpty().WithMessage("Firstname alanı boş bırakılamaz.")
                .MinimumLength(2).WithMessage("Firstname alanı en az 2 karakter olmalıdır.");

            RuleFor(x => x.Lastname.Trim())
                .NotNull().WithMessage("Lastname alanı null olamaz.")
                .NotEmpty().WithMessage("Lastname alanı boş bırakılamaz.")
                .MinimumLength(2).WithMessage("Lastname alanı en az 2 karakter olmalıdır.");

            RuleFor(x => x.Username.Trim())
                .NotNull().WithMessage("Username alanı null olamaz.")
                .NotEmpty().WithMessage("Username alanı boş bırakılamaz.")
                .MinimumLength(3).WithMessage("Username alanı en az 3 karakter olmalıdır.");

            RuleFor(x => x.Email)
                .NotNull().WithMessage("Email alanı null olamaz.")
                .NotEmpty().WithMessage("Email alanı boş bırakılamaz.")
                .EmailAddress().WithMessage("Geçersiz email girdiniz.");
        }
    }
}
