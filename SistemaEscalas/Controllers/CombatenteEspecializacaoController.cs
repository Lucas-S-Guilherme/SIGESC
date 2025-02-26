using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaEscalas.DataContexts;
using SistemaEscalas.Dtos;
using SistemaEscalas.Models;

namespace SistemaEscalas.Controllers
{
    [ApiController]
    [Route("combatentes-especializacoes")]
    public class CombatenteEspecializacaoController : Controller
    {
        private readonly AppDbContext _context;

        public CombatenteEspecializacaoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var combatenteEspecializacoes = await _context.CombatenteEspecializacoes
                    .Include(ce => ce.Combatente)
                    .Include(ce => ce.Especializacao)
                    .ToListAsync();

                return Ok(combatenteEspecializacoes);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CombatenteEspecializacaoDto item)
        {
            try
            {
                var combatenteEspecializacao = new CombatenteEspecializacao
                {
                    CombatenteId = item.CombatenteId,
                    EspecializacaoId = item.EspecializacaoId
                };

                await _context.CombatenteEspecializacoes.AddAsync(combatenteEspecializacao);
                await _context.SaveChangesAsync();

                return Created("", combatenteEspecializacao);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int combatenteId, int especializacaoId)
        {
            try
            {
                var combatenteEspecializacao = await _context.CombatenteEspecializacoes
                    .FirstOrDefaultAsync(ce => ce.CombatenteId == combatenteId && ce.EspecializacaoId == especializacaoId);

                if (combatenteEspecializacao == null)
                {
                    return NotFound();
                }

                _context.CombatenteEspecializacoes.Remove(combatenteEspecializacao);
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