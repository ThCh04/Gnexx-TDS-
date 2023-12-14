using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnexx.Services.ViewModels.MessageViewModel
{
    public class MsgViewModel
    {
        public int Id { get; set; }
        public string sender { get; set; }
        public string receiver { get; set; }
        public string msg_body { get; set; }
        public string msg_img { get; set; }
        public DateTime msg_datetime { get; set; }


    }
}
