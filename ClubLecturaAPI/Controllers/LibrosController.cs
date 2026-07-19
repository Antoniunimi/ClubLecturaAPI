using ClubLectura.Infrastructure.Models;
using ClubLectura.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ClubLecturaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibrosController : ControllerBase
    {
        private readonly LibroRepository _repository;

        public LibrosController(LibroRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Libros
        [HttpGet]
        public async Task<ActionResult<List<LibroModel>>> GetLibros()
        {
            return Ok(await _repository.GetLibros());
        }

        // GET: api/Libros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LibroModel>> GetLibro(int id)
        {
            var libro = await _repository.GetLibro(id);
            if (libro is null)
            {
                return NotFound();
            }
            return Ok(libro);
        }

        // POST: api/Libros
        [HttpPost]
        public async Task<IActionResult> CrearLibro(LibroModel model)
        {
            await _repository.SaveLibro(model);
            return Ok();
        }

        // PUT: api/Libros/5
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarLibro(int id, LibroModel model)
        {
            model.Id = id;
            await _repository.UpdateLibro(model);
            return NoContent();
        }

        // DELETE: api/Libros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarLibro(int id)
        {
            await _repository.RemoveLibro(id);
            return NoContent();
        }
    }
}
