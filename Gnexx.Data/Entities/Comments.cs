using Gnexx.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnexx.Data.Entities
{
    public class Comments
    {
        public int Id { get; set; }

        public string Cmt_body { get; set; }
        public DateTime Cmt_date { get; set; }
        public string Reaction { get; set; }
        public int UserID { get; set; }
        public UsersEntitie User { get; set; }
        public int CoachID { get; set; }
        public Coach Coaches { get; set; }
        public int PlayerID { get; set; }
        public Player Players { get; set; }
        public int TeamID { get; set; }
        public Team Teams { get; set; }
        public List<Response> Responses { get; set; }

    }
}
