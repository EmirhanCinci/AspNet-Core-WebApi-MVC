using Infrastructure.Model;

namespace MovieApp.Model.Dtos.MoviePerson
{
    public class MoviePersonPostDto : IDto
    {
        public int MovieId { get; set; }
        public int PersonId { get; set; }
        public int PersonTypeId { get; set; }
    }
}
