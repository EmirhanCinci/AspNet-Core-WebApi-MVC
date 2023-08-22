using Infrastructure.Model;

namespace MovieApp.Model.Entities
{
    public class PersonRating : IEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int PersonId { get; set; }
        public string? Comment { get; set; }
        public int? Point { get; set; }

        // Navigation Property
        public User? User { get; set; }
        public Person? Person { get; set; }
    }
}
