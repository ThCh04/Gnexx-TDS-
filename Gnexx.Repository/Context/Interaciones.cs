using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnexx.Repository.Context
{
    public class Interaccion
    {
        public int InteraccionId { get; set; }
        public string Tipo { get; set; }
        public DateTime FechaInteraccion { get; set; }

        // Relaciones
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }

}
