using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gnexx.Models.Entities
{
    public class user_type
    {
        [Key]
        public int id { get; set; }
        [Required]
        [StringLength(30)]
        public string player { get; set; }
        [Required]
        [StringLength(30)]
        public string teams { get; set; }
    }
}
