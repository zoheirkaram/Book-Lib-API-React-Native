using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookLib.Entities
{
   [Table("Authors")]
   public class Author
   {
      [Key]
      public int AuthorId { get; set; }
      [MaxLength(100)]
      public string Name { get; set; }
   }
}
