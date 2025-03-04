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

         [HttpGet("{combatenteId}/{restricaoId}")]
        public async Task<IActionResult> GetById(int combatenteId, int restricaoId)
        {
            try
            {
                var combatenteRestricao = await _context.CombatenteRestricoes
                    .Include(cr => cr.Combatente)
                    .Include(cr => cr.Restricao)
                    .Select(cr => new
                    {
                        cr.CombatenteId,
                        cr.RestricaoId,
                        Combatente = new
                        {
                            cr.Combatente.Id,
                            cr.Combatente.Nome,
                            cr.Combatente.CPF,
                            cr.Combatente.DataNascimento,
                            cr.Combatente.Telefone,
                            cr.Combatente.Email,
                            cr.Combatente.Matricula,
                            cr.Combatente.UltimoTurnoTrabalhado
                        },
                        Restricao = new
                        {
                            cr.Restricao.Id,
                            cr.Restricao.Nome,
                            cr.Restricao.Grupo,
                            cr.Restricao.Descricao
                        }
                    })
                    .FirstOrDefaultAsync(cr => cr.CombatenteId == combatenteId && cr.RestricaoId == restricaoId);

                if (combatenteRestricao == null)
                {
                    return NotFound("Associação entre combatente e função não encontrada.");
                }

                return Ok(combatenteRestricao);
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

         [HttpPut("{combatenteId}/{restricaoId}")]
        public async Task<IActionResult> Put(int combatenteId, int restricaoId, [FromBody] CombatenteRestricaoDto item)
        {
            try
            {
                // Verifica se a associação existe
                var combatenteRestricao = await _context.CombatenteRestricoes
                    .FirstOrDefaultAsync(cr => cr.CombatenteId == combatenteId && cr.RestricaoId == restricaoId);

                if (combatenteRestricao == null)
                {
                    return NotFound("Associação entre combatente e função não encontrada.");
                }

                // Verifica se o novo Combatente existe
                var novoCombatente = await _context.Combatentes.FindAsync(item.CombatenteId);
                if (novoCombatente == null)
                {
                    return NotFound("Novo combatente não encontrado.");
                }

                // Verifica se a nova Funcao existe
                var novaRestricao = await _context.Funcoes.FindAsync(item.RestricaoId);
                if (novaRestricao == null)
                {
                    return NotFound("Nova função não encontrada.");
                }

                // Atualiza os IDs da associação
                combatenteRestricao.CombatenteId = item.CombatenteId;
                combatenteRestricao.RestricaoId = item.RestricaoId;

                _context.CombatenteRestricoes.Update(combatenteRestricao);
                await _context.SaveChangesAsync();

                return Ok(combatenteRestricao);
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