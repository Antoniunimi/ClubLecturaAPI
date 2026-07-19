using ClubLectura.Infrastructure.Models;
using ClubLectura.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ClubLecturaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComentariosController : ControllerBase
    {
        private readonly ComentarioRepository _repository;

        public ComentariosController(ComentarioRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Comentarios
        [HttpGet]
        public async Task<ActionResult<List<ComentarioModel>>> GetComentarios()
        {
            return Ok(await _repository.GetComentarios());
        }

        // GET: api/Comentarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ComentarioModel>> GetComentario(int id)
        {
            var comentario = await _repository.GetComentario(id);
            if (comentario is null)
            {
                return NotFound();
            }
            return Ok(comentario);
        }

        // POST: api/Comentarios
        [HttpPost]
        public async Task<IActionResult> CrearComentario(ComentarioModel model)
        {
            await _repository.SaveComentario(model);
            return Ok();
        }

        // PUT: api/Comentarios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarComentario(int id, ComentarioModel model)
        {
            model.Id = id;
            await _repository.UpdateComentario(model);
            return NoContent();
        }

        // DELETE: api/Comentarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarComentario(int id)
        {
            await _repository.RemoveComentario(id);
            return NoContent();
        }
    }
}
