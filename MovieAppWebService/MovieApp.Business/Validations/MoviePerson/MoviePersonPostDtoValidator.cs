using FluentValidation;
using MovieApp.Model.Dtos.MoviePerson;

namespace MovieApp.Business.Validations.MoviePerson
{
    public class MoviePersonPostDtoValidator : AbstractValidator<MoviePersonPostDto>
    {
        public MoviePersonPostDtoValidator()
        {
            RuleFor(x => x.MovieId)
                .InclusiveBetween(1, int.MaxValue).WithMessage("Movie Id değeri 0'dan büyük olmalıdır.");

            RuleFor(x => x.PersonId)
                .InclusiveBetween(1, int.MaxValue).WithMessage("Person Id değeri 0'dan büyük olmalıdır.");

            RuleFor(x => x.PersonTypeId)
                .InclusiveBetween(1, int.MaxValue).WithMessage("Person Type Id değeri 0'dan büyük olmalıdır.");
        }
    }
}
