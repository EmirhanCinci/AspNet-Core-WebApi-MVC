namespace MovieApp.MvcWebUI.Areas.Admin.Models.Dtos.Movie
{
    public class UpdateMovieDto
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
    }
}
