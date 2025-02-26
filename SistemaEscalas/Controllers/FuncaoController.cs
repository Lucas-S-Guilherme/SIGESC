using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaEscalas.DataContexts;
using SistemaEscalas.Dtos;
using SistemaEscalas.Models;

namespace SistemaEscalas.Controllers
{
    [ApiController]
    [Route("funcoes")]
    public class FuncaoController : Controller
    {
        private readonly AppDbContext _context;

        public FuncaoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var funcoes = await _context.Funcoes.ToListAsync();
                return Ok(funcoes);
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
                var funcao = await _context.Funcoes.FindAsync(id);
                if (funcao == null)
                {
                    return NotFound($"Função #{id} não encontrada");
                }
                return Ok(funcao);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FuncaoDto item)
        {
            try
            {
                var funcao = new Funcao
                {
                    Nome = item.Nome,
                    Sigla = item.Sigla
                };

                await _context.Funcoes.AddAsync(funcao);
                await _context.SaveChangesAsync();

                return Created("", funcao);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] FuncaoDto item)
        {
            try
            {
                var funcao = await _context.Funcoes.FindAsync(id);
                if (funcao == null)
                {
                    return NotFound();
                }

                funcao.Nome = item.Nome;
                funcao.Sigla = item.Sigla;

                _context.Funcoes.Update(funcao);
                await _context.SaveChangesAsync();

                return Ok(funcao);
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
                var funcao = await _context.Funcoes.FindAsync(id);
                if (funcao == null)
                {
                    return NotFound();
                }

                _context.Funcoes.Remove(funcao);
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