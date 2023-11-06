using Gnexx.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;
using System.Numerics;
using System.Xml.Linq;

namespace Gnexx.Data.Entities
{
    public class Team
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string TeamName { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required] 
        public string Create_date { get; set; }

        [Required]
        public string Description { get; set; }

        // Llave foránea para Player
        public List<Player> Players { get; set; }
        public Coach Coach { get; set; }
        public List<News> News { get; set; }
        public List<Comments> Comments { get; set; }
        public List<Response> Responses { get; set; }

    }
}


