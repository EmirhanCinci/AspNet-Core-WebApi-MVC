namespace MovieApp.MvcWebUI.Areas.Admin.Models.Items
{
    public class GenderWithPersonsItem : GenderItem
    {
        public List<PersonItem>? Persons { get; set; }
    }
}
