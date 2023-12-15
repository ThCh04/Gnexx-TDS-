using Gnexx.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;

namespace Gnexx.Models.Entities
{
    public class Team
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string TeamName { get; set; }
        
        [Required]
        public DateTime Create_date { get; set; }
        [Required]
        public string? Description { get; set; }

        public int? UserId { get; set; }
        public int? PlayerID { get; set; }
        public int? CoachID { get; set; }

        //navigation property

        public List<Player>? Players { get; set; }
        public Coach Coach { get; set; }        
        public List<News> News { get; set; }
        public List<Comments> Comments { get; set; }
        public List<Response> Responses { get; set; }
    }
}


