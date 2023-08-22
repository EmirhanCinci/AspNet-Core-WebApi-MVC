namespace MovieApp.MvcWebUI.Areas.Admin.Models.Items
{
    public class PersonItem
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public int? Age { get; set; }
        public string? CountryName { get; set; }
        public string? GenderName { get; set; }
        public string? ShortDescription { get; set; }
        public string? Description { get; set; }
        public string? Photo { get; set; }
        public double? Points { get; set; }
        public List<PersonRatingItem>? PersonRatings { get; set; }
        public List<MoviePersonItem>? MoviePersons { get; set; }
    }
}
