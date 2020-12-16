using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BEComentarios.DTO
{
    public class ComentariosDTO
    {
        public int? Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Creador { get; set; }
        [Required]
        public string Descripcion { get; set; }
        public DateTime? Fecha { get; set; }
    }
}
