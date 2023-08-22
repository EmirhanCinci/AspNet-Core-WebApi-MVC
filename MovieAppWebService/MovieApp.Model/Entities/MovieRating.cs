using Infrastructure.Model;

namespace MovieApp.Model.Entities
{
    public class MovieRating : IEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int MovieId { get; set; }
        public string? Comment { get; set; }
        public int? Point { get; set; }

        // Navigation Property
        public Movie? Movie { get; set; }
        public User? User { get; set; }
    }
}
