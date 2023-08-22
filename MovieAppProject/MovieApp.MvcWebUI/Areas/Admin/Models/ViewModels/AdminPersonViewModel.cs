using MovieApp.MvcWebUI.Areas.Admin.Models.Items;

namespace MovieApp.MvcWebUI.Areas.Admin.Models.ViewModels
{
    public class AdminPersonViewModel
    {
        public List<PersonItem> PersonItems { get; set; }
        public List<CountryItem> CountryItems { get; set; }
        public List<GenderItem> GenderItems { get; set; }
    }
}
