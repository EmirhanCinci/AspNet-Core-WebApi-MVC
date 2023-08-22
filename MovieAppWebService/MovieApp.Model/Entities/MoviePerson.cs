using Infrastructure.Model;

namespace MovieApp.Model.Entities
{
    public class MoviePerson : IEntity
    {
        public int MovieId { get; set; }
        public int PersonId { get; set; }
        public int PersonTypeId { get; set; }

        // Navigation Property
        public Movie? Movie { get; set; }
        public Person? Person { get; set; }
        public PersonType? PersonType { get; set; }
    }
}
