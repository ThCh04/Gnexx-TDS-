using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gnexx.Models.Entities
{
    public class News

    {
        [Key]
        public int Id { get; set; }

        public string Author { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime Pub_date { get; set; }

        [Required]
        public string News_body { get; set; } 

        [Required]
        public string Source { get; set; }

        public string Status { get; set; }

        public int UserID { get; set; }

        //navigation property
        public Users Users { get; set; }

    }
}
