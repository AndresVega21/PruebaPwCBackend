using System;
using System.Collections.Generic;

#nullable disable

namespace BEComentarios.Models
{
    public partial class Comentario
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Creador { get; set; }
        public string Descripcion { get; set; }
        public DateTime? Fecha { get; set; }
    }
}
