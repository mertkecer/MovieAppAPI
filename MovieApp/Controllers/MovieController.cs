using Microsoft.AspNetCore.Mvc;
using Movie.Services.Interfaces;
using MovieApp.Api.ViewModels;

namespace MovieApp.Api.Controllers
{
	[ApiController]
	public class MovieController : ControllerBase
	{
		private IMovieService _movieService;

		public MovieController(IMovieService movieService)
		{
			_movieService = movieService;
		}

		[HttpGet]
		[Route("api/[controller]/GetMovies")]
		public async Task<IActionResult> GetMovies()
		{
			var movies = await _movieService.GetMovies();

			if (movies == null)
			{
				return NotFound();
			}
			return Ok(movies);
		}

		[HttpGet]
		[Route("api/[controller]/GetMovieById/{id}")]
		public async Task<IActionResult> GetMovieById(int id)
		{
			var movie = await _movieService.GetMovieById(id);
			return Ok(movie);
		}

		[HttpPost()]
		[Route("api/[controller]/SaveMovie")]
		public async Task<IActionResult> SaveMovie(MovieViewModel movie)
		{
			var movieEntity = new Movie.Entities.Entities.Movie()
			{
				Id = movie.Id,
				Description = movie.Description,
				OriginalLanguage = movie.OriginalLanguage,
				Title = movie.Title,
				VoteAverage = movie.VoteAverage
			};

			if (movie.ProcessMode == "Update")
			{
				await _movieService.UpdateMovie(movieEntity);
			}
			else
			{
				await _movieService.SaveMovie(movieEntity);
			}

			return Ok();
		}

		[HttpDelete()]
		[Route("api/[controller]/DeleteMovie/{id}")]
		public async Task<IActionResult> DeleteMovie(int id)
		{
			await _movieService.DeleteMovie(id);
			return Ok();
		}
	}
}
