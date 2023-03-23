using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookLib.Entities
{
	[Table("BookAuthors")]
	public class BookAuthor
	{
		[Key]
		public int BookAuthorId { get; set; }
		public int BookId { get; set; }
		[ForeignKey("BookId")]
		public virtual Book Book { get; set; }
		public int AuthorId { get; set; }
		[ForeignKey("AuthorId")]
		public virtual Author Author { get; set; }

	}

}