using Gnexx.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gnexx.Models.Entities
{
    public class team
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public string UserName { get; set; }
        public string Campo { get; set; }
    }
}


