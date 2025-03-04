using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaEscalas.DataContexts;
using SistemaEscalas.Dtos;
using SistemaEscalas.Models;

namespace SistemaEscalas.Controllers
{
    [ApiController]
    [Route("turnos-trabalho")]
    [Authorize]
    public class TurnoTrabalhoController : Controller
    {
        private readonly AppDbContext _context;

        public TurnoTrabalhoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var turnos = await _context.TurnosTrabalho
                    .Include(t => t.Escala)
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
                var turno = await _context.TurnosTrabalho
                    .Include(t => t.Escala)
                    .FirstOrDefaultAsync(t => t.Id == id);

                if (turno == null)
                {
                    return NotFound($"Turno de trabalho #{id} não encontrado");
                }
                return Ok(turno);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TurnoTrabalhoDto item)
        {
            try
            {
                var turno = new TurnoTrabalho
                {
                    DataInicio = item.DataInicio,
                    DataFim = item.DataFim,
                    EscalaId = item.EscalaId
                };

                await _context.TurnosTrabalho.AddAsync(turno);
                await _context.SaveChangesAsync();

                return Created("", turno);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TurnoTrabalhoDto item)
        {
            try
            {
                var turno = await _context.TurnosTrabalho.FindAsync(id);
                if (turno == null)
                {
                    return NotFound();
                }

                turno.DataInicio = item.DataInicio;
                turno.DataFim = item.DataFim;
                turno.EscalaId = item.EscalaId;

                _context.TurnosTrabalho.Update(turno);
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
                // Busca o TurnoTrabalho e seus registros dependentes
                var turno = await _context.TurnosTrabalho
                    .Include(t => t.TurnosCombatente) // Carrega os registros dependentes
                    .FirstOrDefaultAsync(t => t.Id == id);

                if (turno == null)
                {
                    return NotFound($"Turno de trabalho #{id} não encontrado");
                }

                // Remove os registros dependentes em TurnoCombatente
                _context.TurnosCombatente.RemoveRange(turno.TurnosCombatente);

                // Remove o TurnoTrabalho
                _context.TurnosTrabalho.Remove(turno);

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