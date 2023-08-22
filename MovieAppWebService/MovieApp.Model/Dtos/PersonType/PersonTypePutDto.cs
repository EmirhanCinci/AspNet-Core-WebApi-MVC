using Infrastructure.Model;

namespace MovieApp.Model.Dtos.PersonType
{
    public class PersonTypePutDto : IDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
    }
}
