using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnexx.Repository.Context
{
    public class Mensaje
    {
        public int MensajeId { get; set; }
        public string Contenido { get; set; }
        public DateTime FechaEnvio { get; set; }

        // Relaciones
        public int UsuarioId { get; set; }
        public int ConversacionId { get; set; }

        public Usuario Remitente { get; set; }
        public Conversacion Conversacion { get; set; }

    }
