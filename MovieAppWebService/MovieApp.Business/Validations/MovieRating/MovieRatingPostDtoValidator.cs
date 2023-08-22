using FluentValidation;
using MovieApp.Model.Dtos.MovieRating;

namespace MovieApp.Business.Validations.MovieRating
{
    public class MovieRatingPostDtoValidator : AbstractValidator<MovieRatingPostDto>
    {
        public MovieRatingPostDtoValidator()
        {
            RuleFor(x => x.UserId.Trim())
                .NotEmpty().WithMessage("UserId alanı boş bırakılamaz.")
                .NotNull().WithMessage("UserId alanı null olamaz.")
                .MinimumLength(4).WithMessage("UserId alanı en az 4 karakter olmalıdır.");

            RuleFor(x => x.MovieId)
                .InclusiveBetween(1, int.MaxValue).WithMessage("MovieId alanı 0'dan büyük olmalıdır.");

            RuleFor(x => x.Comment.Trim())
                .NotEmpty().WithMessage("Comment alanı boş bırakılamaz.")
                .NotNull().WithMessage("Comment alanı null olamaz.")
                .MinimumLength(5).WithMessage("Comment alanı en az 5 karakterden oluşmalıdır.");

            RuleFor(x => x.Point)
                .InclusiveBetween(1, 5).WithMessage("Point alanı 1 ile 5 arasında olmalıdır.");
        }
    }
}
