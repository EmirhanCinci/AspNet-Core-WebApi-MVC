namespace MovieApp.MvcWebUI.Areas.Admin.Models.Items
{
    public class PersonTypeItem
    {
        public int Id { get; set; }
        public string? Type { get; set; }
        public List<MoviePersonItem>? MoviePersons { get; set; }
    }
}
