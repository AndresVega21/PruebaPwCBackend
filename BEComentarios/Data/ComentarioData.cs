using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BEComentarios.DTO;
using BEComentarios.Models;
using Microsoft.EntityFrameworkCore;

namespace BEComentarios.Data
{
    public interface IComentarioData
    {
        Task<ResponseDTO> CrearPelicula(ComentariosDTO comentario);
        Task<ResponseDTO> EliminarPelicula(int id);
        Task<ResponseDTO> ModificarPelicula(int id, ComentariosDTO comentario);
        Task<ComentariosDTO[]> VerPeliculas();
        Task<ComentariosDTO> VerDetallesPelicula(int id);
    }

    public class ComentarioData : IComentarioData
    {
        private readonly DBComentariosContext _context;
        private readonly IMapper _mapper;
        public ComentarioData(DBComentariosContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ResponseDTO> CrearPelicula(ComentariosDTO comentario)
        {
            try
            {
                comentario.Fecha = DateTime.Now;
                Comentario nuevoComentario = _mapper.Map<Comentario>(comentario);
                await _context.Comentarios.AddAsync(nuevoComentario);
                await _context.SaveChangesAsync();
                return new ResponseDTO { Resultado = true, Mensaje = "Comentario agregado con éxito" };
            }
            catch (Exception)
            {
                return new ResponseDTO { Resultado = false, Mensaje = "Ocurrió un error agregar el comentario." };
            }
        }
        public async Task<ResponseDTO> ModificarPelicula(int id, ComentariosDTO comentario)
        {
            try
            {
                Comentario getRegistro = await _context.Comentarios.Where(x => x.Id == id).FirstOrDefaultAsync();
                getRegistro.Creador = comentario.Creador;
                getRegistro.Descripcion = comentario.Descripcion;
                getRegistro.Titulo = comentario.Titulo;
                getRegistro.Fecha = DateTime.Now;
                await _context.SaveChangesAsync();
                return new ResponseDTO { Resultado = true, Mensaje = "Comentario actualizado con éxito" };
            }
            catch (Exception)
            {
                return new ResponseDTO { Resultado = false, Mensaje = "Ocurrió un error actualizar el comentario." };
            }
        }
        public async Task<ResponseDTO> EliminarPelicula(int id)
        {
            try
            {
                Comentario getRegistro = await _context.Comentarios.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (getRegistro != null)
                {
                    _context.Comentarios.Remove(getRegistro);
                    await _context.SaveChangesAsync();
                    return new ResponseDTO { Resultado = true, Mensaje = "Comentario Eliminado con éxito" };
                }
                return new ResponseDTO { Resultado = true, Mensaje = "No se encontró el comentario que deseaba eliminar" };
            }
            catch (Exception)
            {
                return new ResponseDTO { Resultado = false, Mensaje = "Ocurrió un error actualizar el comentario." };
            }
        }
        public async Task<ComentariosDTO[]> VerPeliculas()
        {
            try
            {
                Comentario[] arrayComentarios = _context.Comentarios.ToArray();
                ComentariosDTO[] result = new ComentariosDTO[arrayComentarios.Length];
                result = _mapper.Map<ComentariosDTO[]>(arrayComentarios);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<ComentariosDTO> VerDetallesPelicula(int id)
        {
            try
            {
                Comentario comentario = await _context.Comentarios.Where(x=> x.Id == id).FirstOrDefaultAsync();
                ComentariosDTO result = _mapper.Map<ComentariosDTO>(comentario);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
