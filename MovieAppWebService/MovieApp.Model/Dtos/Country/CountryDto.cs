using Infrastructure.Model;

namespace MovieApp.Model.Dtos.Country
{
    public class CountryDto : IDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
