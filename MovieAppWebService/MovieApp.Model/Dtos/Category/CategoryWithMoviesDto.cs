using Infrastructure.Model;
using MovieApp.Model.Dtos.Movie;

namespace MovieApp.Model.Dtos.Category
{
    public class CategoryWithMoviesDto : CategoryDto, IDto
    {
        public List<MovieDto> Movies { get; set; }
    }
}
