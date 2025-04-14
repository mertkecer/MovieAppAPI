using Microsoft.EntityFrameworkCore;
using Movie.Entities.Context;
using Movie.Services.Interfaces;

namespace Movie.Services.Classes
{
	public class MovieService : IMovieService
	{
		private readonly MovieContext _dbContext;

		public MovieService(MovieContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<IEnumerable<Entities.Entities.Movie>> GetMovies()
		{
			return await _dbContext.Movies.ToListAsync();
		}

		public async Task<Entities.Entities.Movie> GetMovieById(int id)
		{
			return await _dbContext.Movies.Where(x => x.Id == id).FirstOrDefaultAsync();
		}

		public async Task UpdateMovie(Entities.Entities.Movie movie)
		{
			_dbContext.Update(movie);
			await _dbContext.SaveChangesAsync();
		}

		public async Task SaveMovie(Entities.Entities.Movie movie)
		{
			await _dbContext.AddAsync(movie);
			await _dbContext.SaveChangesAsync();
		}

		public async Task DeleteMovie(int id)
		{
			await _dbContext.Movies.Where(t => t.Id == id).ExecuteDeleteAsync();
		}
	}
}
