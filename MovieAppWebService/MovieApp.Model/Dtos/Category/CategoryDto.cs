using Infrastructure.Model;

namespace MovieApp.Model.Dtos.Category
{
    public class CategoryDto : IDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
