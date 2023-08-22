using FluentValidation;
using MovieApp.Model.Dtos.Movie;

namespace MovieApp.Business.Validations.Movie
{
    public class MoviePostDtoValidator : AbstractValidator<MoviePostDto>
    {
        public MoviePostDtoValidator() 
        {
            RuleFor(x => x.Name.Trim()).NotNull().WithMessage("Name alanı null olamaz.")
                .NotEmpty().WithMessage("Name alanı boş bırakılamaz.")
                .MinimumLength(2).WithMessage("Name alanı en az 2 karakter uzunluğunda olmalıdır.");

            RuleFor(x => x.CategoryId)
                .InclusiveBetween(1, int.MaxValue).WithMessage("CategoryId alanı 0'dan büyük olmalıdır.");

            RuleFor(x => x.Duration)
                .InclusiveBetween(1, int.MaxValue).WithMessage("Duration alanı 0'dan büyük olmalıdır.");

            RuleFor(x => x.ShortDescription.Trim())
               .NotEmpty().WithMessage("ShortDescription alanı boş bırakılamaz.")
               .NotNull().WithMessage("ShortDescription alanı null olamaz.")
               .MinimumLength(5).WithMessage("ShortDescription alanı en az 5 karakter girmelisiniz.");

            RuleFor(x => x.Description.Trim())
               .NotEmpty().WithMessage("Description alanı boş bırakılamaz.")
               .NotNull().WithMessage("Description alanı null olamaz.")
               .MinimumLength(5).WithMessage("Description alanı en az 5 karakter girmelisiniz.");
        }
    }
}
