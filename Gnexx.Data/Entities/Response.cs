using Gnexx.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnexx.Data.Entities
{
    public class Response
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string R_body { get; set; }

        public DateTime Datetime { get; set; }
        //Llaves foraneas

        public int UserId { get; set; }
        public Users User { get; set; }
    }
}
