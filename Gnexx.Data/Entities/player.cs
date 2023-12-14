using Gnexx.Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gnexx.Models.Entities
{
    public class Player
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string P_Username { get; set; }

        [Required]
        public string P_Name { get; set; }

        [Required]
        public string P_Lastname { get; set; }

        [Required]
        public string P_Nickname { get; set; }

        [Required]
        public DateTime P_Datebirth { get; set; }

        [Required]
        public string P_Specialization { get; set; }

        [Required]
        public string P_Description { get; set; }

        [Required]
        public string P_Contact { get; set; }

        public int TeamID { get; set; }
        public Team Teams { get; set; }
        public int UserID { get; set; }
        public UsersEntitie Users { get; set; }
        public int postID { get; set; }
        public Postulation Postulations { get; set; }
    }
}
