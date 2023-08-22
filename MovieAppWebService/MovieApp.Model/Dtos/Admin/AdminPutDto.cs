using Infrastructure.Model;

namespace MovieApp.Model.Dtos.Admin
{
    public class AdminPutDto : IDto
    {
        public int Id { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
