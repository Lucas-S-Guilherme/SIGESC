using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaEscalas.DataContexts;
using SistemaEscalas.Dtos;
using SistemaEscalas.Models;

namespace SistemaEscalas.Controllers
{
    [ApiController]
    [Route("especializacoes")]
    [Authorize]
    public class EspecializacaoController : Controller
    {
        private readonly AppDbContext _context;

        public EspecializacaoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var especializacoes = await _context.Especializacoes.ToListAsync();
                return Ok(especializacoes);
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
                var especializacao = await _context.Especializacoes.FindAsync(id);
                if (especializacao == null)
                {
                    return NotFound($"Especialização #{id} não encontrada");
                }
                return Ok(especializacao);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EspecializacaoDto item)
        {
            try
            {
                var especializacao = new Especializacao
                {
                    Nome = item.Nome,
                    Descricao = item.Descricao,
                    Sigla = item.Sigla
                    
                };

                await _context.Especializacoes.AddAsync(especializacao);
                await _context.SaveChangesAsync();

                return Created("", especializacao);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EspecializacaoDto item)
        {
            try
            {
                var especializacao = await _context.Especializacoes.FindAsync(id);
                if (especializacao == null)
                {
                    return NotFound();
                }

                especializacao.Nome = item.Nome;
                especializacao.Descricao = item.Descricao;
                especializacao.Sigla = item.Sigla;

                _context.Especializacoes.Update(especializacao);
                await _context.SaveChangesAsync();

                return Ok(especializacao);
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
                var especializacao = await _context.Especializacoes.FindAsync(id);
                if (especializacao == null)
                {
                    return NotFound();
                }

                _context.Especializacoes.Remove(especializacao);
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