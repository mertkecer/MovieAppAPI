namespace Movie.Services.Interfaces
{
	public interface IMovieService
	{
		Task<IEnumerable<Entities.Entities.Movie>> GetMovies();
		Task<Entities.Entities.Movie> GetMovieById(int id);
		Task UpdateMovie(Entities.Entities.Movie movie);
		Task SaveMovie(Entities.Entities.Movie movie);
		Task DeleteMovie(int id);
	}
}
