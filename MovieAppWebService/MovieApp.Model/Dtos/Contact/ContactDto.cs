using Infrastructure.Model;

namespace MovieApp.Model.Dtos.Contact
{
    public class ContactDto : IDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CountryName { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
