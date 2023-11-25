using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnexx.Services.Image
{
    public class ImageVM
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int PropertyId { get; set; }
        public string Description { get; set; }
    }
}
