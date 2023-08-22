using Infrastructure.Model;

namespace MovieApp.Model.Entities
{
    public class Movie : IEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int CategoryId { get; set; }
        public int Duration { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string? ShortDescription { get; set; }
        public string? Description { get; set; }
        public string? Photo { get; set; }
        public string? Trailer { get; set; }

        // Navigation Property
        public Category? Category { get; set; }
        public List<MoviePerson>? MoviePersons { get; set; }
        public List<MovieRating>? MovieRatings { get; set; }
    }
}
