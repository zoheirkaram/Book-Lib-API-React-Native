namespace BookLib.Contracts
{
	public class OpenLibraryBookDetails
	{
		public string? Title { get; set; }
		public int? NumberOfpages { get; set; }
		public string? PublishDate { get; set; }
		public List<Subject>? Places { get; set; }
		public List<Subject>? People { get; set; }
		public List<Subject>? Times { get; set; }
		public List<Link>? Links { get; set; }
		public string? CoverUrl { get; set; }
		public string? InfoURL { get; set; }

	}

	public class Subject
	{
		public string Name { get; set; }
		public string URL { get; set; }
	}

	public class Link
	{
		public string Title { get; set; }
		public string URL { get; set; }
	}
}
