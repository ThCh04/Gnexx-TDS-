using Gnexx.Data.Entities;
using Gnexx.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnexx.Services.ViewModels.TeamViewModel
{
    public class TeamViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string TeamName { get; set; }


        [Required]
        public DateTime Create_date { get; set; }

        [Required]
        public string? Description { get; set; }
        public List<Player> Players { get; set; }
        public int? CoachID { get; set; }
        public int? UserId { get; set; }
        public int? PlayerID { get; set; }
    }
}
