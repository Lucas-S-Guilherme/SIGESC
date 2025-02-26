using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaEscalas.DataContexts;
using SistemaEscalas.Dtos;
using SistemaEscalas.Models;

namespace SistemaEscalas.Controllers
{
    [ApiController]
    [Route("combatentes-restricoes")]
    public class CombatenteRestricaoController : Controller
    {
        private readonly AppDbContext _context;

        public CombatenteRestricaoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var combatenteRestricoes = await _context.CombatenteRestricoes
                    .Include(cr => cr.Combatente)
                    .Include(cr => cr.Restricao)
                    .ToListAsync();

                return Ok(combatenteRestricoes);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CombatenteRestricaoDto item)
        {
            try
            {
                var combatenteRestricao = new CombatenteRestricao
                {
                    CombatenteId = item.CombatenteId,
                    RestricaoId = item.RestricaoId
                };

                await _context.CombatenteRestricoes.AddAsync(combatenteRestricao);
                await _context.SaveChangesAsync();

                return Created("", combatenteRestricao);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int combatenteId, int restricaoId)
        {
            try
            {
                var combatenteRestricao = await _context.CombatenteRestricoes
                    .FirstOrDefaultAsync(cr => cr.CombatenteId == combatenteId && cr.RestricaoId == restricaoId);

                if (combatenteRestricao == null)
                {
                    return NotFound();
                }

                _context.CombatenteRestricoes.Remove(combatenteRestricao);
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