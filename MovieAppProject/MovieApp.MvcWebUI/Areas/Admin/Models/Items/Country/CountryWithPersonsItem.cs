namespace MovieApp.MvcWebUI.Areas.Admin.Models.Items
{
    public class CountryWithPersonsItem : CountryItem
    {
        public List<PersonItem> Persons { get; set; }
    }
}
