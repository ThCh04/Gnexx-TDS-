

using Gnexx.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;

namespace Gnexx.Models.Entities
{
    public class UsersEntitie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Type_user { get; set; }

        
        public string? Profile_img { get; set; }

        public DateTime? BirthDate { get; set; }

        public string Email { get; set; }

        public int CoachID { get; set; }
        public Coach Coaches { get; set; }
        public int? PlayerID { get; set; }
        public Player Players { get; set; }
        public int? TeamID { get; set; }
        public Team Teams { get; set; }
        
        //navigation property

        public List<News> News { get; set; }
        public List<Response> Responses { get; set; }
        public List<Comments> Comments { get; set; }
    }

}
