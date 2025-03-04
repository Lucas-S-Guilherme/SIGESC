using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaEscalas.DataContexts;
using SistemaEscalas.Dtos;
using SistemaEscalas.Models;

namespace SistemaEscalas.Controllers
{
    [ApiController]
    [Route("combatentes-especializacoes")]
    [Authorize]
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
                    .Select(ce => new
                    {
                        ce.CombatenteId,
                        ce.EspecializacaoId,
                        Combatente = new
                        {
                            ce.Combatente.Id,
                            ce.Combatente.Nome,
                            ce.Combatente.CPF,
                            ce.Combatente.DataNascimento,
                            ce.Combatente.Telefone,
                            ce.Combatente.Email,
                            ce.Combatente.Matricula,
                            ce.Combatente.UltimoTurnoTrabalhado
                        },
                        Especializacao = new
                        {
                            ce.Especializacao.Id,
                            ce.Especializacao.Nome,
                            ce.Especializacao.Descricao,
                            ce.Especializacao.Sigla
                        }
                    })
                    .ToListAsync();

                return Ok(combatenteEspecializacoes);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpGet("{combatenteId}/{especializacaoId}")]
        public async Task<IActionResult> GetById(int combatenteId, int especializacaoId)
        {
            try
            {
                var combatenteEspecializacao = await _context.CombatenteEspecializacoes
                    .Include(ce => ce.Combatente)
                    .Include(ce => ce.Especializacao)
                    .FirstOrDefaultAsync(ce => ce.CombatenteId == combatenteId && ce.EspecializacaoId == especializacaoId);

                if (combatenteEspecializacao == null)
                {
                    return NotFound("Associação entre combatente e especialização não encontrada.");
                }

                return Ok(combatenteEspecializacao);
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

        [HttpPut("{combatenteId}/{especializacaoId}")]
        public async Task<IActionResult> Put(int combatenteId, int especializacaoId, [FromBody] CombatenteEspecializacaoDto item)
        {
            try
            {
                // Log para depuração
                Console.WriteLine($"Buscando associação: CombatenteId = {combatenteId}, EspecializacaoId = {especializacaoId}");

                // Verifica se a associação existe
                var combatenteEspecializacao = await _context.CombatenteEspecializacoes
                    .FirstOrDefaultAsync(ce => ce.CombatenteId == combatenteId && ce.EspecializacaoId == especializacaoId);

                if (combatenteEspecializacao == null)
                {
                    // Log para depuração
                    Console.WriteLine("Associação não encontrada.");
                    return NotFound("Associação entre combatente e especialização não encontrada.");
                }

                // Log para depuração
                Console.WriteLine($"Associação encontrada: CombatenteId = {combatenteEspecializacao.CombatenteId}, EspecializacaoId = {combatenteEspecializacao.EspecializacaoId}");

                // Verifica se o novo Combatente existe
                var novoCombatente = await _context.Combatentes.FindAsync(item.CombatenteId);
                if (novoCombatente == null)
                {
                    // Log para depuração
                    Console.WriteLine("Novo combatente não encontrado.");
                    return NotFound("Novo combatente não encontrado.");
                }

                // Verifica se a nova Especializacao existe
                var novaEspecializacao = await _context.Especializacoes.FindAsync(item.EspecializacaoId);
                if (novaEspecializacao == null)
                {
                    // Log para depuração
                    Console.WriteLine("Nova especialização não encontrada.");
                    return NotFound("Nova especialização não encontrada.");
                }

                // Atualiza os IDs da associação
                combatenteEspecializacao.CombatenteId = item.CombatenteId;
                combatenteEspecializacao.EspecializacaoId = item.EspecializacaoId;

                _context.CombatenteEspecializacoes.Update(combatenteEspecializacao);
                await _context.SaveChangesAsync();

                // Log para depuração
                Console.WriteLine("Associação atualizada com sucesso.");

                return Ok(combatenteEspecializacao);
            }
            catch (Exception e)
            {
                // Log para depuração
                Console.WriteLine($"Erro: {e.Message}");
                return Problem(e.Message);
            }
        }

        [HttpDelete("{combatenteId}/{especializacaoId}")]
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