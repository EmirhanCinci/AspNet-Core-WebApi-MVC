using Infrastructure.Model;

namespace MovieApp.Model.Dtos.User
{
    public class UserPutDto : IDto
    {
        public string Nickname { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
