using System.Threading.Tasks;
using BEComentarios.DTO;
using BEComentarios.Data;

namespace BEComentarios.Services

{
    public interface IComentarioService
    {
        Task<ResponseDTO> CrearPelicula(ComentariosDTO comentario);
        Task<ResponseDTO> EliminarPelicula(int id);
        Task<ResponseDTO> ModificarPelicula(int id, ComentariosDTO comentario);
        Task<ComentariosDTO[]> VerPeliculas();
        Task<ComentariosDTO> VerDetallesPelicula(int id);
    }

    public class ComentarioService : IComentarioService
    {
        private readonly IComentarioData _comentarioData;

        public ComentarioService(IComentarioData comentarioData) {
            _comentarioData = comentarioData;
        }


        public async Task<ResponseDTO> CrearPelicula(ComentariosDTO comentario)
        {
            return await _comentarioData.CrearPelicula(comentario);
        }
        public async Task<ResponseDTO> ModificarPelicula(int id, ComentariosDTO comentario)
        {
            return await _comentarioData.ModificarPelicula(id, comentario);
        }
        public async Task<ResponseDTO> EliminarPelicula(int id)
        {
            return await _comentarioData.EliminarPelicula(id);
        }
        public async Task<ComentariosDTO[]> VerPeliculas()
        {
            return await _comentarioData.VerPeliculas();
        }
        public async Task<ComentariosDTO> VerDetallesPelicula(int id)
        {
            return await _comentarioData.VerDetallesPelicula(id);
        }
    }
}
