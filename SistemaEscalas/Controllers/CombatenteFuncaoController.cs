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
                    .Select(cf => new
                    {
                        cf.CombatenteId,
                        cf.FuncaoId,
                        Combatente = new
                        {
                            cf.Combatente.Id,
                            cf.Combatente.Nome,
                            cf.Combatente.CPF,
                            cf.Combatente.DataNascimento,
                            cf.Combatente.Telefone,
                            cf.Combatente.Email,
                            cf.Combatente.Matricula,
                            cf.Combatente.UltimoTurnoTrabalhado
                        },
                        Funcao = new
                        {
                            cf.Funcao.Id,
                            cf.Funcao.Nome,
                            cf.Funcao.Sigla
                        }
                    })
                    .ToListAsync();

                return Ok(combatenteFuncoes);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpGet("{combatenteId}/{funcaoId}")]
        public async Task<IActionResult> GetById(int combatenteId, int funcaoId)
        {
            try
            {
                var combatenteFuncao = await _context.CombatenteFuncoes
                    .Include(cf => cf.Combatente)
                    .Include(cf => cf.Funcao)
                    .Select(cf => new
                    {
                        cf.CombatenteId,
                        cf.FuncaoId,
                        Combatente = new
                        {
                            cf.Combatente.Id,
                            cf.Combatente.Nome,
                            cf.Combatente.CPF,
                            cf.Combatente.DataNascimento,
                            cf.Combatente.Telefone,
                            cf.Combatente.Email,
                            cf.Combatente.Matricula,
                            cf.Combatente.UltimoTurnoTrabalhado
                        },
                        Funcao = new
                        {
                            cf.Funcao.Id,
                            cf.Funcao.Nome,
                            cf.Funcao.Sigla
                        }
                    })
                    .FirstOrDefaultAsync(cf => cf.CombatenteId == combatenteId && cf.FuncaoId == funcaoId);

                if (combatenteFuncao == null)
                {
                    return NotFound("Associação entre combatente e função não encontrada.");
                }

                return Ok(combatenteFuncao);
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

        [HttpPut("{combatenteId}/{funcaoId}")]
        public async Task<IActionResult> Put(int combatenteId, int funcaoId, [FromBody] CombatenteFuncaoDto item)
        {
            try
            {
                // Verifica se a associação existe
                var combatenteFuncao = await _context.CombatenteFuncoes
                    .FirstOrDefaultAsync(cf => cf.CombatenteId == combatenteId && cf.FuncaoId == funcaoId);

                if (combatenteFuncao == null)
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
                var novaFuncao = await _context.Funcoes.FindAsync(item.FuncaoId);
                if (novaFuncao == null)
                {
                    return NotFound("Nova função não encontrada.");
                }

                // Atualiza os IDs da associação
                combatenteFuncao.CombatenteId = item.CombatenteId;
                combatenteFuncao.FuncaoId = item.FuncaoId;

                _context.CombatenteFuncoes.Update(combatenteFuncao);
                await _context.SaveChangesAsync();

                return Ok(combatenteFuncao);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpDelete("{combatenteId}/{funcaoId}")]
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