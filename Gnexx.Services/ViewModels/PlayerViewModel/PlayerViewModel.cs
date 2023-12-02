using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnexx.Services.ViewModels.PlayerViewModel
{
    public class PlayerViewModel
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
        public int UserID { get; set; }

    }
}
