using Infrastructure.Model;

namespace MovieApp.Model.Entities
{
    public class Gender : IEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        // Navigation Property
        public List<Person>? Persons { get; set; }
    }
}
