using Infrastructure.Model;

namespace MovieApp.Model.Dtos.Person
{
    public class PersonPostDto : IDto
    {
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public DateTime? Birthdate { get; set; }
        public int CountryId { get; set; }
        public int GenderId { get; set; }
        public string? ShortDescription { get; set; }
        public string? Description { get; set; }
        public string? Photo { get; set; }
    }
}
