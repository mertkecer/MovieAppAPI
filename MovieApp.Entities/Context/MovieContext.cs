using Microsoft.EntityFrameworkCore;
namespace Movie.Entities.Context
{
	public class MovieContext : DbContext
	{
		public MovieContext(DbContextOptions<MovieContext> options) : base(options)
		{
		}
		public DbSet<Entities.Movie> Movies { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Entities.Movie>().HasKey(x => x.Id);

			modelBuilder.Entity<Entities.Movie>().HasData(
				new Entities.Movie
				{
					Id = 1,
					Title = "System",
					Description = "",
					OriginalLanguage = "TR",
				}
			);
		}
	}
}
