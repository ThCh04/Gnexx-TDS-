using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Gnexx.Models.Entities
{
    public class player
    {
        [Key]
        public int id { get; set; }
        [Required]
        [StringLength(30)]
        public int user_name { get; set; }
        [Required]
        [StringLength(30)]
        public string name { get; set; }
        [Required]
        [StringLength(30)]
        public string lastname { get; set; }
        public DateOnly datebirth { get; set; }
        [Required]
        [StringLength(50)]
        public string description { get; set; }
        [Required]
        public string curriculum { get; set; }



    }
}
