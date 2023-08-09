using Microsoft.EntityFrameworkCore;
using MovieSiteDal.Entities;

namespace MovieSiteDal
{
    public class MovieSiteContext : DbContext
    {
        public MovieSiteContext(DbContextOptions<MovieSiteContext> options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
