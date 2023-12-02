using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnexx.Services.ViewModels.CoachViewModel
{
    public class CoachViewModel
    {
        public int CoachId { get; set; }
        public string C_Name { get; set; }
        public DateTime C_Datebirth { get; set; }
        public string Achievements { get; set; }
        public string EsportExp { get; set; }
        public string C_Specialization { get; set; }
        public string C_Contact { get; set; }
        public int UserID { get; set; }
        public int TeamID { get; set; }

    }
}
