using Microsoft.EntityFrameworkCore;
using MovieApp.Model.Entities;

namespace MovieApp.DataAccess.Implementations.EntityFrameworkCore.Contexts
{
    public class MovieAppContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey("Nickname");
            modelBuilder.Entity<MoviePerson>().HasKey("MovieId", "PersonId", "PersonTypeId");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = EMIRHAN; database = MovieApp; trusted_connection = true;");
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Country>? Countries { get; set; }
        public DbSet<Gender>? Genders { get; set; }
        public DbSet<Movie>? Movies { get; set; }
        public DbSet<MoviePerson>? MoviePersons { get; set; }
        public DbSet<MovieRating>? MovieRatings { get; set; }
        public DbSet<Person>? Persons { get; set; }
        public DbSet<PersonRating>? PersonRatings { get; set; }
        public DbSet<PersonType>? PersonTypes { get; set; }
        public DbSet<User>? Users { get; set; }
    }
}
