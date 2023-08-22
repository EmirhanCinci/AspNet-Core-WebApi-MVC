using Infrastructure.Model;

namespace MovieApp.Model.Dtos.Gender
{
    public class GenderDto : IDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
