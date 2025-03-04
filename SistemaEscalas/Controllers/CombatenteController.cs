using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaEscalas.DataContexts;
using SistemaEscalas.Dtos;
using SistemaEscalas.Models;

namespace SistemaEscalas.Controllers
{
    [ApiController]
    [Route("combatentes")]
    [Authorize] // lembre-se de gerar o token de authorização na rota /auth/login, e authorizar no Swagger em Available authorizations (cadeado do lado direito da rota)
    public class CombatenteController : Controller
    {
        private readonly AppDbContext _context;

        public CombatenteController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var combatentes = await _context.Combatentes
                    .Include(c => c.Especializacoes)
                    .Include(c => c.Funcoes)
                    .Include(c => c.Restricoes)
                    .ToListAsync();

                return Ok(combatentes);
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
                var combatente = await _context.Combatentes
                    .Include(c => c.Especializacoes)
                    .Include(c => c.Funcoes)
                    .Include(c => c.Restricoes)
                    .FirstOrDefaultAsync(c => c.Id == id);

                if (combatente == null)
                {
                    return NotFound($"Combatente #{id} não encontrado");
                }
                return Ok(combatente);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CombatenteDto item)
        {
            try
            {
                var combatente = new Combatente
                {
                    Nome = item.Nome,
                    CPF = item.CPF,
                    DataNascimento = item.DataNascimento,
                    Telefone = item.Telefone,
                    Email = item.Email,
                    Matricula = item.Matricula,
                    UltimoTurnoTrabalhado = item.UltimoTurnoTrabalhado ?? DateTime.MinValue
                };

                await _context.Combatentes.AddAsync(combatente);
                await _context.SaveChangesAsync();

                return Created("", combatente);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CombatenteDto item)
        {
            try
            {
                var combatente = await _context.Combatentes.FindAsync(id);
                if (combatente == null)
                {
                    return NotFound();
                }

                combatente.Nome = item.Nome;
                combatente.CPF = item.CPF;
                combatente.DataNascimento = item.DataNascimento;
                combatente.Telefone = item.Telefone;
                combatente.Email = item.Email;
                combatente.Matricula = item.Matricula;
                combatente.UltimoTurnoTrabalhado = item.UltimoTurnoTrabalhado ?? DateTime.MinValue;

                _context.Combatentes.Update(combatente);
                await _context.SaveChangesAsync();

                return Ok(combatente);
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
                var combatente = await _context.Combatentes.FindAsync(id);
                if (combatente == null)
                {
                    return NotFound();
                }

                _context.Combatentes.Remove(combatente);
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