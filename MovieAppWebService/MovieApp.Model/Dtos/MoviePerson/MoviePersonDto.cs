using Infrastructure.Model;

namespace MovieApp.Model.Dtos.MoviePerson
{
    public class MoviePersonDto : IDto
    {
        public int MovieId { get; set; }
        public int PersonId { get; set; }
        public int PersonTypeId { get; set; }
        public string PersonPhoto { get; set; }
        public string MoviePhoto { get; set; }
        public string? MovieName { get; set; }
        public string? PersonName { get; set; }
        public string? PersonTypeName { get; set; }
    }
}
