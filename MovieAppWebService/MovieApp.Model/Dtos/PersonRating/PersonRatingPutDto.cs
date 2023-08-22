using Infrastructure.Model;

namespace MovieApp.Model.Dtos.PersonRating
{
    public class PersonRatingPutDto : IDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int PersonId { get; set; }
        public string? Comment { get; set; }
        public int? Point { get; set; }
    }
}
