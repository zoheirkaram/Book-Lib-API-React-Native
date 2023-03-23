using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookLib.Entities
{
   [Table("Genres")]
   public class Genre
   {
      [Key]
      public int GenreId { get; set; }
      [MaxLength(50)]
      public string Title { get; set; }
   }

}