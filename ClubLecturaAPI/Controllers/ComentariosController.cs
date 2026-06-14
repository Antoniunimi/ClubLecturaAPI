using ClubLecturaAPI.Data;
using ClubLecturaAPI.DTOs;
using ClubLecturaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClubLecturaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComentariosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ComentariosController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComentarioDto>>> GetComentarios()
        {
            var comentarios = await _context.Comentarios
                .Select(c => new ComentarioDto
                {
                    Id = c.Id,
                    Texto = c.Texto,
                    Calificacion = c.Calificacion,
                    FechaComentario = c.FechaComentario,
                    MiembroId = c.MiembroId,
                    MiembroNombre = c.Miembro!.Nombre,
                    LibroId = c.LibroId,
                    LibroTitulo = c.Libro!.Titulo
                })
                .ToListAsync();

            return Ok(comentarios);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ComentarioDto>> GetComentario(int id)
        {
            var comentario = await _context.Comentarios
                .Include(c => c.Miembro)
                .Include(c => c.Libro)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (comentario == null)
            {
                return NotFound();
            }

            var comentarioDto = new ComentarioDto
            {
                Id = comentario.Id,
                Texto = comentario.Texto,
                Calificacion = comentario.Calificacion,
                FechaComentario = comentario.FechaComentario,
                MiembroId = comentario.MiembroId,
                MiembroNombre = comentario.Miembro!.Nombre,
                LibroId = comentario.LibroId,
                LibroTitulo = comentario.Libro!.Titulo
            };

            return Ok(comentarioDto);
        }


        [HttpPost]
        public async Task<ActionResult<ComentarioDto>> CrearComentario(CrearComentarioDto crearComentarioDto)
        {
            // Validar que el miembro exista
            var miembro = await _context.Miembros.FindAsync(crearComentarioDto.MiembroId);
            if (miembro == null)
            {
                return BadRequest($"No existe un miembro con el Id {crearComentarioDto.MiembroId}.");
            }

            // Validar que el libro exista
            var libro = await _context.Libros.FindAsync(crearComentarioDto.LibroId);
            if (libro == null)
            {
                return BadRequest($"No existe un libro con el Id {crearComentarioDto.LibroId}.");
            }

            var comentario = new Comentario
            {
                Texto = crearComentarioDto.Texto,
                Calificacion = crearComentarioDto.Calificacion,
                FechaComentario = crearComentarioDto.FechaComentario,
                MiembroId = crearComentarioDto.MiembroId,
                LibroId = crearComentarioDto.LibroId
            };

            _context.Comentarios.Add(comentario);
            await _context.SaveChangesAsync();

            var comentarioDto = new ComentarioDto
            {
                Id = comentario.Id,
                Texto = comentario.Texto,
                Calificacion = comentario.Calificacion,
                FechaComentario = comentario.FechaComentario,
                MiembroId = comentario.MiembroId,
                MiembroNombre = miembro.Nombre,
                LibroId = comentario.LibroId,
                LibroTitulo = libro.Titulo
            };

            return CreatedAtAction(nameof(GetComentario), new { id = comentario.Id }, comentarioDto);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarComentario(int id, ActualizarComentarioDto actualizarComentarioDto)
        {
            var comentario = await _context.Comentarios.FindAsync(id);

            if (comentario == null)
            {
                return NotFound();
            }

            // Validar que el miembro exista
            var miembro = await _context.Miembros.FindAsync(actualizarComentarioDto.MiembroId);
            if (miembro == null)
            {
                return BadRequest($"No existe un miembro con el Id {actualizarComentarioDto.MiembroId}.");
            }

            // Validar que el libro exista
            var libro = await _context.Libros.FindAsync(actualizarComentarioDto.LibroId);
            if (libro == null)
            {
                return BadRequest($"No existe un libro con el Id {actualizarComentarioDto.LibroId}.");
            }

            comentario.Texto = actualizarComentarioDto.Texto;
            comentario.Calificacion = actualizarComentarioDto.Calificacion;
            comentario.FechaComentario = actualizarComentarioDto.FechaComentario;
            comentario.MiembroId = actualizarComentarioDto.MiembroId;
            comentario.LibroId = actualizarComentarioDto.LibroId;

            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarComentario(int id)
        {
            var comentario = await _context.Comentarios.FindAsync(id);

            if (comentario == null)
            {
                return NotFound();
            }

            _context.Comentarios.Remove(comentario);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
