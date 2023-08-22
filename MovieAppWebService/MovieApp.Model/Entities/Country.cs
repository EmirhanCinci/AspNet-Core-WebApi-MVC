using Infrastructure.Model;

namespace MovieApp.Model.Entities
{
    public class Country : IEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        // Navigation Property
        public List<Person>? Persons { get; set; }
        public List<Contact> Contacts { get; set; }
    }
}
