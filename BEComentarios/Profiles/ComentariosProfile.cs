using AutoMapper;
using BEComentarios.DTO;
using BEComentarios.Models;

namespace BEComentarios.Profiles
{
    public class ComentariosProfile : Profile
    {
        public ComentariosProfile()
        {
            CreateMap<Comentario, ComentariosDTO>();

            CreateMap<ComentariosDTO, Comentario>();
        }
    }
}
