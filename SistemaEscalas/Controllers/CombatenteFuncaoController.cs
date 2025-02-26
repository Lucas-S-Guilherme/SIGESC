using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaEscalas.DataContexts;
using SistemaEscalas.Dtos;
using SistemaEscalas.Models;

namespace SistemaEscalas.Controllers
{
    [ApiController]
    [Route("combatentes-funcoes")]
    public class CombatenteFuncaoController : Controller
    {
        private readonly AppDbContext _context;

        public CombatenteFuncaoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var combatenteFuncoes = await _context.CombatenteFuncoes
                    .Include(cf => cf.Combatente)
                    .Include(cf => cf.Funcao)
                    .ToListAsync();

                return Ok(combatenteFuncoes);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CombatenteFuncaoDto item)
        {
            try
            {
                var combatenteFuncao = new CombatenteFuncao
                {
                    CombatenteId = item.CombatenteId,
                    FuncaoId = item.FuncaoId
                };

                await _context.CombatenteFuncoes.AddAsync(combatenteFuncao);
                await _context.SaveChangesAsync();

                return Created("", combatenteFuncao);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int combatenteId, int funcaoId)
        {
            try
            {
                var combatenteFuncao = await _context.CombatenteFuncoes
                    .FirstOrDefaultAsync(cf => cf.CombatenteId == combatenteId && cf.FuncaoId == funcaoId);

                if (combatenteFuncao == null)
                {
                    return NotFound();
                }

                _context.CombatenteFuncoes.Remove(combatenteFuncao);
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