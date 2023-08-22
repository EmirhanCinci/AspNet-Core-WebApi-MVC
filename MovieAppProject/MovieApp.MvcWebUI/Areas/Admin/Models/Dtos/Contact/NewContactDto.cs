namespace MovieApp.MvcWebUI.Areas.Admin.Models.Dtos.Contact
{
    public class NewContactDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int CountryId { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
