using Infrastructure.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieApp.Model.Entities
{
    public class Person : IEntity
    {
        public int Id { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public DateTime? Birthdate { get; set; }
        public int CountryId { get; set; }
        public int GenderId { get; set; }
        public string? ShortDescription { get; set; }
        public string? Description { get; set; }
        public string? Photo { get; set; }

        [NotMapped]
        public string FullName { get { return $"{Firstname} {Lastname}"; } }
        [NotMapped]
        public int? Age { get { return DateTime.Now.Year - Birthdate.Value.Year; } }

        // Navigation Property
        public Country? Country { get; set; }
        public Gender? Gender { get; set; }
        public List<PersonRating>? PersonRatings { get; set; }
        public List<MoviePerson>? MoviePersons { get; set; }
    }
}
