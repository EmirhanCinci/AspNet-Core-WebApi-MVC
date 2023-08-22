using Infrastructure.Model;

namespace MovieApp.Model.Entities
{
    public class PersonType : IEntity
    {
        public int Id { get; set; }
        public string? Type { get; set; }

        // Navigation Property
        public List<MoviePerson>? MoviePersons { get; set; }
    }
}
