namespace MovieApp.MvcWebUI.Areas.Admin.Models.Items
{
    public class PersonRatingItem 
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public string? Comment { get; set; }
        public int? Point { get; set; }
    }
}
