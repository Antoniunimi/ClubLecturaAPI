using ClubLectura.Infrastructure.Models;
using ClubLectura.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ClubLecturaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReunionesController : ControllerBase
    {
        private readonly ReunionRepository _repository;

        public ReunionesController(ReunionRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Reuniones
        [HttpGet]
        public async Task<ActionResult<List<ReunionModel>>> GetReuniones()
        {
            return Ok(await _repository.GetReuniones());
        }

        // GET: api/Reuniones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReunionModel>> GetReunion(int id)
        {
            var reunion = await _repository.GetReunion(id);
            if (reunion is null)
            {
                return NotFound();
            }
            return Ok(reunion);
        }

        // POST: api/Reuniones
        [HttpPost]
        public async Task<IActionResult> CrearReunion(ReunionModel model)
        {
            await _repository.SaveReunion(model);
            return Ok();
        }

        // PUT: api/Reuniones/5
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarReunion(int id, ReunionModel model)
        {
            model.Id = id;
            await _repository.UpdateReunion(model);
            return NoContent();
        }

        // DELETE: api/Reuniones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarReunion(int id)
        {
            await _repository.RemoveReunion(id);
            return NoContent();
        }
    }
}
