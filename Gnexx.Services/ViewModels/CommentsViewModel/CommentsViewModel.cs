using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnexx.Services.ViewModels.CommentsViewModel
{
    public class CommentsViewModel
    {
        public int Id { get; set; }
        public string Cmt_body { get; set; }
        public DateTime Cmt_date { get; set; }
        public string Reaction { get; set; }
        public int UserID { get; set; }
        public int CoachID { get; set; }
        public int PlayerID { get; set; }
        public int TeamID { get; set; }

    }
}
