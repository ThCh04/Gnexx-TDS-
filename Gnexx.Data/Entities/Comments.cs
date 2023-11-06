using Gnexx.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnexx.Data.Entities
{
    public class Comments
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Cmt_body { get; set; }

        [Required]
        public DateTime Cmt_date { get; set; }

        public string Reaction { get; set; }

        // Llaves Foraneas

        // Llave foránea para News
        public int UserId { get; set; }
        public Users User { get; set; }

    }
}
