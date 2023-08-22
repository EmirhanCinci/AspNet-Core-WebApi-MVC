using Infrastructure.Model;

namespace MovieApp.Model.Dtos.Admin
{
    public class AdminPostDto : IDto
    {
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
