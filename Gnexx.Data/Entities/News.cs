using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gnexx.Models.Entities
{
    public class News

    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        public DateTime pub_date { get; set; }

        [Required]
        [StringLength(1000)]
        public string news_body { get; set; } 

        [Required]
        [StringLength(100)]
        public string source { get; set; }

        [StringLength(500)]
        public string comments { get; set; }

        [StringLength(25)]
        public string status { get; set; }
    }
}
