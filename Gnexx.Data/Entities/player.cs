using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gnexx.Models.Entities
{
    public class Player
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

        [Required]
        public DateTime datebirth { get; set; }

        [Required]
        [StringLength(50)]
        public string description { get; set; }

        [Required]
        public string curriculum { get; set; }



    }
}
