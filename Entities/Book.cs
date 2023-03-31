using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookLib.Entities
{
	[Table("Books")]
	public class Book
	{
		[Key]
		public int BookId { get; set; }
		[MaxLength(255)]
		public string Title { get; set; }
		[MaxLength(500)]
		public string Description { get; set; }
		[MaxLength(20)]
		public string ISBN { get; set; }
		public int GenreId { get; set; }
		[ForeignKey("GenreId")]
		public virtual Genre? Genre { get; set; }
		public int? PublisherId { get; set; }
		[ForeignKey("PublisherId")]
		public virtual Publisher? Publisher { get; set; }
		[NotMapped]
		public int AuthorId { get; set; }
	}

}