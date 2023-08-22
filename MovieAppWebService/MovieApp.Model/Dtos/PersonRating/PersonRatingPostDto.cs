using Infrastructure.Model;

namespace MovieApp.Model.Dtos.PersonRating
{
    public class PersonRatingPostDto : IDto
    {
        public string UserId { get; set; }
        public int PersonId { get; set; }
        public string? Comment { get; set; }
        public int? Point { get; set; }
    }
}
