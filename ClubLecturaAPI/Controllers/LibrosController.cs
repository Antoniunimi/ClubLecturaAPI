using ClubLecturaAPI.Data;
using ClubLecturaAPI.DTOs;
using ClubLecturaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClubLecturaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibrosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LibrosController(ApplicationDbContext context)
        {
            _context = context;
        }

   
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LibroDto>>> GetLibros()
        {
            var libros = await _context.Libros
                .Select(l => new LibroDto
                {
                    Id = l.Id,
                    Titulo = l.Titulo,
                    Autor = l.Autor,
                    ISBN = l.ISBN,
                    AnioPublicacion = l.AnioPublicacion,
                    Genero = l.Genero
                })
                .ToListAsync();

            return Ok(libros);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<LibroDto>> GetLibro(int id)
        {
            var libro = await _context.Libros.FindAsync(id);

            if (libro == null)
            {
                return NotFound();
            }

            var libroDto = new LibroDto
            {
                Id = libro.Id,
                Titulo = libro.Titulo,
                Autor = libro.Autor,
                ISBN = libro.ISBN,
                AnioPublicacion = libro.AnioPublicacion,
                Genero = libro.Genero
            };

            return Ok(libroDto);
        }

        [HttpPost]
        public async Task<ActionResult<LibroDto>> CrearLibro(CrearLibroDto crearLibroDto)
        {
            var libro = new Libro
            {
                Titulo = crearLibroDto.Titulo,
                Autor = crearLibroDto.Autor,
                ISBN = crearLibroDto.ISBN,
                AnioPublicacion = crearLibroDto.AnioPublicacion,
                Genero = crearLibroDto.Genero
            };

            _context.Libros.Add(libro);
            await _context.SaveChangesAsync();

            var libroDto = new LibroDto
            {
                Id = libro.Id,
                Titulo = libro.Titulo,
                Autor = libro.Autor,
                ISBN = libro.ISBN,
                AnioPublicacion = libro.AnioPublicacion,
                Genero = libro.Genero
            };

            return CreatedAtAction(nameof(GetLibro), new { id = libro.Id }, libroDto);
        }

    
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarLibro(int id, ActualizarLibroDto actualizarLibroDto)
        {
            var libro = await _context.Libros.FindAsync(id);

            if (libro == null)
            {
                return NotFound();
            }

            libro.Titulo = actualizarLibroDto.Titulo;
            libro.Autor = actualizarLibroDto.Autor;
            libro.ISBN = actualizarLibroDto.ISBN;
            libro.AnioPublicacion = actualizarLibroDto.AnioPublicacion;
            libro.Genero = actualizarLibroDto.Genero;

            await _context.SaveChangesAsync();

            return NoContent();
        }

 
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarLibro(int id)
        {
            var libro = await _context.Libros.FindAsync(id);

            if (libro == null)
            {
                return NotFound();
            }

            _context.Libros.Remove(libro);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
