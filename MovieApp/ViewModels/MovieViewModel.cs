namespace MovieApp.Api.ViewModels
{
	public class MovieViewModel
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public int VoteAverage { get; set; }
		public string OriginalLanguage { get; set; }
		public string ProcessMode { get; set; }
	}
}
