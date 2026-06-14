using ClubLecturaAPI.Data;
using ClubLecturaAPI.DTOs;
using ClubLecturaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClubLecturaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReunionesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReunionesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Reuniones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReunionDto>>> GetReuniones()
        {
            var reuniones = await _context.Reuniones
                .Select(r => new ReunionDto
                {
                    Id = r.Id,
                    Fecha = r.Fecha,
                    Lugar = r.Lugar,
                    Tema = r.Tema,
                    LibroId = r.LibroId,
                    LibroTitulo = r.Libro!.Titulo
                })
                .ToListAsync();

            return Ok(reuniones);
        }

        // GET: api/Reuniones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReunionDto>> GetReunion(int id)
        {
            var reunion = await _context.Reuniones
                .Include(r => r.Libro)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (reunion == null)
            {
                return NotFound();
            }

            var reunionDto = new ReunionDto
            {
                Id = reunion.Id,
                Fecha = reunion.Fecha,
                Lugar = reunion.Lugar,
                Tema = reunion.Tema,
                LibroId = reunion.LibroId,
                LibroTitulo = reunion.Libro!.Titulo
            };

            return Ok(reunionDto);
        }

        // POST: api/Reuniones
        [HttpPost]
        public async Task<ActionResult<ReunionDto>> CrearReunion(CrearReunionDto crearReunionDto)
        {
            // Validar que el libro exista
            var libro = await _context.Libros.FindAsync(crearReunionDto.LibroId);
            if (libro == null)
            {
                return BadRequest($"No existe un libro con el Id {crearReunionDto.LibroId}.");
            }

            var reunion = new Reunion
            {
                Fecha = crearReunionDto.Fecha,
                Lugar = crearReunionDto.Lugar,
                Tema = crearReunionDto.Tema,
                LibroId = crearReunionDto.LibroId
            };

            _context.Reuniones.Add(reunion);
            await _context.SaveChangesAsync();

            var reunionDto = new ReunionDto
            {
                Id = reunion.Id,
                Fecha = reunion.Fecha,
                Lugar = reunion.Lugar,
                Tema = reunion.Tema,
                LibroId = reunion.LibroId,
                LibroTitulo = libro.Titulo
            };

            return CreatedAtAction(nameof(GetReunion), new { id = reunion.Id }, reunionDto);
        }

        // PUT: api/Reuniones/5
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarReunion(int id, ActualizarReunionDto actualizarReunionDto)
        {
            var reunion = await _context.Reuniones.FindAsync(id);

            if (reunion == null)
            {
                return NotFound();
            }

            // Validar que el libro exista
            var libro = await _context.Libros.FindAsync(actualizarReunionDto.LibroId);
            if (libro == null)
            {
                return BadRequest($"No existe un libro con el Id {actualizarReunionDto.LibroId}.");
            }

            reunion.Fecha = actualizarReunionDto.Fecha;
            reunion.Lugar = actualizarReunionDto.Lugar;
            reunion.Tema = actualizarReunionDto.Tema;
            reunion.LibroId = actualizarReunionDto.LibroId;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Reuniones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarReunion(int id)
        {
            var reunion = await _context.Reuniones.FindAsync(id);

            if (reunion == null)
            {
                return NotFound();
            }

            _context.Reuniones.Remove(reunion);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
