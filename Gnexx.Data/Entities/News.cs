using Gnexx.Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gnexx.Data.Entities
{
    public class News

    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required] 
        public string Author { get; set; }

        [Required]
        public DateTime Pub_date { get; set; }

        [Required]
        public string News_body { get; set; }

        [Required]
        public string Source { get; set; }

        public string N_Status { get; set; }

        // Llaves Foraneas

        // Llave foránea para Comments
        public int UserId { get; set; }
        public Users User { get; set; }

    }
}
