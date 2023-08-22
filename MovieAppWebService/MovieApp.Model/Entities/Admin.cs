using Infrastructure.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieApp.Model.Entities
{
    public class Admin : IEntity
    {
        public int Id { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        [NotMapped]
        public string Fullname {  get { return $"{Firstname} {Lastname}"; } }

        public bool IsActive { get; set; }
    }
}
