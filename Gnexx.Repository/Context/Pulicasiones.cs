using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnexx.Repository.Context
{
    public class Postulacion
    {
        public int PostulacionId { get; set; }
        public string Comentario { get; set; }
        public DateTime FechaPostulacion { get; set; }

        // Relaciones
        public int OfertaId { get; set; }
        public int UsuarioId { get; set; }

        public Oferta Oferta { get; set; }
        public Usuario Postulante { get; set; }
    }
}
