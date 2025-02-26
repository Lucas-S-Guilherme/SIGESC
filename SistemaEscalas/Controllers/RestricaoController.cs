using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaEscalas.DataContexts;
using SistemaEscalas.Dtos;
using SistemaEscalas.Models;

namespace SistemaEscalas.Controllers
{
    [ApiController]
    [Route("restricoes")]
    public class RestricaoController : Controller
    {
        private readonly AppDbContext _context;

        public RestricaoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var restricoes = await _context.Restricoes.ToListAsync();
                return Ok(restricoes);
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
                var restricao = await _context.Restricoes.FindAsync(id);
                if (restricao == null)
                {
                    return NotFound($"Restrição #{id} não encontrada");
                }
                return Ok(restricao);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RestricaoDto item)
        {
            try
            {
                var restricao = new Restricao
                {
                    Nome = item.Nome,
                    Grupo = item.Grupo,
                    Descricao = item.Descricao
                };

                await _context.Restricoes.AddAsync(restricao);
                await _context.SaveChangesAsync();

                return Created("", restricao);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] RestricaoDto item)
        {
            try
            {
                var restricao = await _context.Restricoes.FindAsync(id);
                if (restricao == null)
                {
                    return NotFound();
                }

                restricao.Nome = item.Nome;
                restricao.Grupo = item.Grupo;
                restricao.Descricao = item.Descricao;

                _context.Restricoes.Update(restricao);
                await _context.SaveChangesAsync();

                return Ok(restricao);
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
                var restricao = await _context.Restricoes.FindAsync(id);
                if (restricao == null)
                {
                    return NotFound();
                }

                _context.Restricoes.Remove(restricao);
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