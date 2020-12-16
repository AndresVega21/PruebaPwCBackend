using System;
using System.Threading.Tasks;
using BEComentarios.DTO;
using BEComentarios.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BEComentarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        private readonly IComentarioService _comentarioService;
        public ComentarioController(IComentarioService comentarioService)
        {
            _comentarioService = comentarioService;
        }
        // GET: api/<ComentarioController>
        [EnableCors("_myAllowSpecificOrigins")]
        [HttpGet]
        public async Task<ComentariosDTO[]> Get()
        {
            try
            {
                return await _comentarioService.VerPeliculas();
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET api/<ComentarioController>/5
        [HttpGet("{id}")]
        public async Task<ComentariosDTO> Get(int id)
        {
            return await _comentarioService.VerDetallesPelicula(id);
        }

        // POST api/<ComentarioController>
        [HttpPost]
        public async Task<ResponseDTO> Post([FromBody] ComentariosDTO comentario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return await _comentarioService.CrearPelicula(comentario);
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // PUT api/<ComentarioController>/5
        [HttpPut("{id}")]
        public async Task<ResponseDTO> Put(int id, [FromBody] ComentariosDTO comentario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return await _comentarioService.ModificarPelicula(id, comentario);
                }
                return new ResponseDTO { Mensaje = "Uno o más campos están vacíos", Resultado = false };
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE api/<ComentarioController>/5
        [HttpDelete("{id}")]
        public async Task<ResponseDTO> Delete(int id)
        {
            try
            {
                return await _comentarioService.EliminarPelicula(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
