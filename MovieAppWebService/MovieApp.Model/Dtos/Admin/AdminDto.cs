using Infrastructure.Model;

namespace MovieApp.Model.Dtos.Admin
{
    public class AdminDto : IDto
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string? Email { get; set; }
    }
}
