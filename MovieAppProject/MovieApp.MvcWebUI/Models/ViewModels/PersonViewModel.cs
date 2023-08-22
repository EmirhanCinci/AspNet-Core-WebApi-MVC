using MovieApp.MvcWebUI.Areas.Admin.Models.Items;

namespace MovieApp.MvcWebUI.Models.ViewModels
{
    public class PersonViewModel
    {
        public List<PersonItem> MostPopularActors { get; set; }
        public List<PersonItem> MostCommentActors { get; set; }
        public PersonTypeItem Actors { get; set; }
    }
}
