using ClubLecturaAPI.Data;
using ClubLecturaAPI.DTOs;
using ClubLecturaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClubLecturaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MiembrosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MiembrosController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MiembroDto>>> GetMiembros()
        {
            var miembros = await _context.Miembros
                .Select(m => new MiembroDto
                {
                    Id = m.Id,
                    Nombre = m.Nombre,
                    Correo = m.Correo,
                    Telefono = m.Telefono,
                    FechaIngreso = m.FechaIngreso
                })
                .ToListAsync();

            return Ok(miembros);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<MiembroDto>> GetMiembro(int id)
        {
            var miembro = await _context.Miembros.FindAsync(id);

            if (miembro == null)
            {
                return NotFound();
            }

            var miembroDto = new MiembroDto
            {
                Id = miembro.Id,
                Nombre = miembro.Nombre,
                Correo = miembro.Correo,
                Telefono = miembro.Telefono,
                FechaIngreso = miembro.FechaIngreso
            };

            return Ok(miembroDto);
        }

     
        [HttpPost]
        public async Task<ActionResult<MiembroDto>> CrearMiembro(CrearMiembroDto crearMiembroDto)
        {
            var miembro = new Miembro
            {
                Nombre = crearMiembroDto.Nombre,
                Correo = crearMiembroDto.Correo,
                Telefono = crearMiembroDto.Telefono,
                FechaIngreso = crearMiembroDto.FechaIngreso
            };

            _context.Miembros.Add(miembro);
            await _context.SaveChangesAsync();

            var miembroDto = new MiembroDto
            {
                Id = miembro.Id,
                Nombre = miembro.Nombre,
                Correo = miembro.Correo,
                Telefono = miembro.Telefono,
                FechaIngreso = miembro.FechaIngreso
            };

            return CreatedAtAction(nameof(GetMiembro), new { id = miembro.Id }, miembroDto);
        }

      
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarMiembro(int id, ActualizarMiembroDto actualizarMiembroDto)
        {
            var miembro = await _context.Miembros.FindAsync(id);

            if (miembro == null)
            {
                return NotFound();
            }

            miembro.Nombre = actualizarMiembroDto.Nombre;
            miembro.Correo = actualizarMiembroDto.Correo;
            miembro.Telefono = actualizarMiembroDto.Telefono;
            miembro.FechaIngreso = actualizarMiembroDto.FechaIngreso;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarMiembro(int id)
        {
            var miembro = await _context.Miembros.FindAsync(id);

            if (miembro == null)
            {
                return NotFound();
            }

            _context.Miembros.Remove(miembro);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
