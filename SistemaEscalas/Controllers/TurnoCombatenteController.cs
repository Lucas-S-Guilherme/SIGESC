using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaEscalas.DataContexts;
using SistemaEscalas.Dtos;
using SistemaEscalas.Models;

namespace SistemaEscalas.Controllers
{
    [ApiController]
    [Route("turnos-combatente")]
    public class TurnoCombatenteController : Controller
    {
        private readonly AppDbContext _context;

        public TurnoCombatenteController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var turnos = await _context.TurnosCombatente
                    .Include(t => t.Combatente)
                    .Include(t => t.Turno)
                    .ToListAsync();

                return Ok(turnos);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var turno = await _context.TurnosCombatente
                    .Include(t => t.Combatente)
                    .Include(t => t.Turno)
                    .FirstOrDefaultAsync(t => t.Id == id);

                if (turno == null)
                {
                    return NotFound($"Turno do combatente #{id} não encontrado");
                }
                return Ok(turno);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TurnoCombatenteDto item)
        {
            try
            {
                var turno = new TurnoCombatente
                {
                    CombatenteId = item.CombatenteId,
                    TurnoId = item.TurnoId,
                    HoraInicio = item.HoraInicio,
                    HoraFim = item.HoraFim,
                    StatusDescanso = item.StatusDescanso
                };

                await _context.TurnosCombatente.AddAsync(turno);
                await _context.SaveChangesAsync();

                return Created("", turno);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TurnoCombatenteDto item)
        {
            try
            {
                var turno = await _context.TurnosCombatente.FindAsync(id);
                if (turno == null)
                {
                    return NotFound();
                }

                turno.CombatenteId = item.CombatenteId;
                turno.TurnoId = item.TurnoId;
                turno.HoraInicio = item.HoraInicio;
                turno.HoraFim = item.HoraFim;
                turno.StatusDescanso = item.StatusDescanso;

                _context.TurnosCombatente.Update(turno);
                await _context.SaveChangesAsync();

                return Ok(turno);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var turno = await _context.TurnosCombatente.FindAsync(id);
                if (turno == null)
                {
                    return NotFound();
                }

                _context.TurnosCombatente.Remove(turno);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
    }
}