using Gnexx.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnexx.Data.Entities
{
    public class Response
    {
        public int Id { get; set; }
        public string R_body { get; set; }
        public DateTime DateTime { get; set; }
        public int UserID { get; set; }
        public UsersEntitie Users { get; set; }
        public int CoachID { get; set; }
        public Coach Coaches { get; set; }
        public int PlayerID { get; set; }
        public Player Players { get; set; }
        public int Team { get; set; }
        public Team Teams { get; set; }
        public int CommentsID { get; set; }
        public Comments Comments { get; set; }
    }
}
