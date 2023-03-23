using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookLib.Entities
{

    [Table("Images")]
    public class Image
    {
        [Key]
        public int ImageId { get; set; }
        [MaxLength(50)]
        public string Description { get; set; }
        [MaxLength(255)]
        public string URL { get; set; }
        public int BookId { get; set; }
    }
}
