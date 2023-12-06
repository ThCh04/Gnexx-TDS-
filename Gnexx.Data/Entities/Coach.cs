using Gnexx.Models.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Gnexx.Data.Entities
{
    public class Coach
    {
        public int CoachId { get; set; }
        public string C_Name { get; set; }
        public DateTime C_Datebirth { get; set; }
        public string Achievements { get; set; }
        public string EsportExp { get; set; }
        public string C_Specialization { get; set; }
        public string C_Contact { get; set; }
        public int UserID { get; set; }
        public UsersEntitie Users { get; set; }
        public int TeamID { get; set; }
        public Team Teams { get; set; }
    }
}
