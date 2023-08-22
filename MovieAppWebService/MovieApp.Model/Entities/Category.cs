using Infrastructure.Model;

namespace MovieApp.Model.Entities
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        // Navigation Property
        public List<Movie>? Movies { get; set; }
    }
}
