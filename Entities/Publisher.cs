using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookLib.Entities
{

   [Table("Publishers")]
   public class Publisher
   {
      [Key]
      public int PublisherId { get; set; }
      [MaxLength(50)]
      public string Name { get; set; }
   }

}
