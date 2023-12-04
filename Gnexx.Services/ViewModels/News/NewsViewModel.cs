using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnexx.Services.ViewModels.News
{
    public class NewsViewModel
    {
        public int ID { get; set; }
        public string Author { get; set; }

        [Required]
        [Display(Name = "Titulo")]
        public string Title { get; set; }

        public DateTime Pub_date { get; set; } = DateTime.Now;

        [Required]
        public string News_body { get; set; }

        [Required]
        public string Source { get; set; }

        public string Status { get; set; }

    }
}
