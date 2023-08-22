namespace MovieApp.MvcWebUI.Areas.Admin.Models.Dtos
{
    public class NewPersonRatingDto
    {
        public string UserId { get; set; }
        public int PersonId { get; set; }
        public string? Comment { get; set; }
        public int? Point { get; set; }
    }
}
