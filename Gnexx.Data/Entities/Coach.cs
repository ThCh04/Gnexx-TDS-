using Gnexx.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Gnexx.Data.Entities
{
    public class Coach
    {
        [Key]
        public int Id { get; set; }

        public string C_Name { get; set; }

        public DateTime C_Datebirth { get; set; }

        public string Achievements { get; set; }

        public string EsportsExperience { get; set; }

        public string C_Specialization { get; set; }

        public string C_Contact { get; set; }

        // Llave foránea para User
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public int UserId { get; set; }
        public Users User { get; set; }
        public List<News> News { get; set; }
        public List<Comments> Comments { get; set; }
        public List<Response> Responses { get; set; }
    }

}
