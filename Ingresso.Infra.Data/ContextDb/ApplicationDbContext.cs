using Ingresso.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ingresso.Infra.Data.ContextDb
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<CinemaRoom> CinemaRooms { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieDescription> MovieDescriptions { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
