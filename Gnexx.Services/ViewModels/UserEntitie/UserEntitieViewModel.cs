using Gnexx.Data.Entities;
using Gnexx.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnexx.Services.ViewModels.UserEntitie
{
    public class UserEntitieViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Type_user { get; set; }

        [Required]
        public string Profile_img { get; set; }

        public DateTime BirthDate { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int CoachID { get; set; }
        public Coach Coaches { get; set; }
        public int PlayerID { get; set; }
        public Player Players { get; set; }
        public int TeamID { get; set; }
        public Team Teams { get; set; }

        //navigation property

        public List<Gnexx.Models.Entities.News> news { get; set; }
        public List<Response> Responses { get; set; }
        public List<Comments> Comments { get; set; }
    }
}

