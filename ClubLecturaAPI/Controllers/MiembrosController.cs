using ClubLectura.Infrastructure.Models;
using ClubLectura.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ClubLecturaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MiembrosController : ControllerBase
    {
        private readonly MiembroRepository _repository;

        public MiembrosController(MiembroRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Miembros
        [HttpGet]
        public async Task<ActionResult<List<MiembroModel>>> GetMiembros()
        {
            return Ok(await _repository.GetMiembros());
        }

        // GET: api/Miembros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MiembroModel>> GetMiembro(int id)
        {
            var miembro = await _repository.GetMiembro(id);
            if (miembro is null)
            {
                return NotFound();
            }
            return Ok(miembro);
        }

        // POST: api/Miembros
        [HttpPost]
        public async Task<IActionResult> CrearMiembro(MiembroModel model)
        {
            await _repository.SaveMiembro(model);
            return Ok();
        }

        // PUT: api/Miembros/5
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarMiembro(int id, MiembroModel model)
        {
            model.Id = id;
            await _repository.UpdateMiembro(model);
            return NoContent();
        }

        // DELETE: api/Miembros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarMiembro(int id)
        {
            await _repository.RemoveMiembro(id);
            return NoContent();
        }
    }
}
