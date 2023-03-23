using BookLib.Entities;

namespace BookLib.Contracts
{
	public class BookData
	{
		public int BookDataId { get; set; }
		public Book Book { get; set; }
		public List<Author> Authors { get; set; }
		public List<Image> Images { get; set; }
	}
}
