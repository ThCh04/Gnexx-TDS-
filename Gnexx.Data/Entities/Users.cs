using Gnexx.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;

namespace Gnexx.Data.Entities
{
    public class Users
    {
        [Key]
        public int Id { get; set; }

        public int PlayerID { get; set; }

        public int TeamID { get; set; }

        public int CoachID { get; set; }

        public int Type_user { get; set; }

        [Required]
        public string Profile_img { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string BirthDate { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        //Llaves Foraneas




        // Llave foránea para Player
        public Player Player { get; set; }
        public Coach Coach { get; set; }
        public List<News> News { get; set; }
        public List<Comments> Comments { get; set; }
        public List<Response> Response { get; set; }
        /*public int? PlayerId { get; set; }
        public virtual ICollection<Player> Players { get; set; }

        // Llave foránea para Team
        public int? TeamId { get; set; }
        public virtual ICollection<Team> Teams { get; set; }

        // Llave foránea para Team
        public int? CoachId { get; set; }
        public virtual ICollection<Coach> Coaches { get; set; }*/

    }
    
}
