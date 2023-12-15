using Gnexx.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnexx.Data.Entities
{
    public class Postulation
    {
        [Key]
        public int Id_post { get; set; }
        public string Author_post { get; set; }
        public string Description_post { get; set; }
        public DateTime DateTime_post { get; set; }
        public bool Status {  get; set; } 
        public string Cv_post { get; set; } //Campo curriculum

        //Propiedades
        public int playerID {  get; set; }
        public Player players { get; set; }
    }
}
