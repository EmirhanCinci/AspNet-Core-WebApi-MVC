using FluentValidation;
using MovieApp.Model.Dtos.User;

namespace MovieApp.Business.Validations.User
{
    public class UserPostDtoValidator : AbstractValidator<UserPostDto>
    {
        public UserPostDtoValidator() 
        {
            RuleFor(x => x.Nickname.Trim())
                .NotNull().WithMessage("Nickname alanı null olamaz.")
                .NotEmpty().WithMessage("Nickname alanı boş bırakılamaz.")
                .MinimumLength(4).WithMessage("Nickname alanı en az 4 karakterden oluşmalıdır.");

            RuleFor(x => x.Firstname.Trim())
                .NotNull().WithMessage("Firstname alanı null olamaz.")
                .NotEmpty().WithMessage("Firstname alanı boş bırakılamaz.")
                .MinimumLength(2).WithMessage("Firstname alanı en az 2 karakterden oluşmalıdır.");

            RuleFor(x => x.Lastname.Trim())
                .NotNull().WithMessage("Lastname alanı null olamaz.")
                .NotEmpty().WithMessage("Lastname alanı boş bırakılamaz.")
                .MinimumLength(2).WithMessage("Lastname alanı en az 2 karakterden oluşmalıdır.");

            RuleFor(x => x.Email)
                .NotNull().WithMessage("Email alanı null olamaz.")
                .NotEmpty().WithMessage("Email alanı boş bırakılamaz.")
                .EmailAddress().WithMessage("Uygun formatta bir email adresi girmelisiniz.");
        }
    }
}
