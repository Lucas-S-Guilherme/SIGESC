using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaEscalas.DataContexts;
using SistemaEscalas.Dtos;
using SistemaEscalas.Models;

namespace SistemaEscalas.Controllers
{
    [ApiController]
    [Route("regras-trabalho")]
    public class RegraTrabalhoController : Controller
    {
        private readonly AppDbContext _context;

        public RegraTrabalhoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var regras = await _context.RegrasTrabalho.ToListAsync();
                return Ok(regras);
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
                var regra = await _context.RegrasTrabalho.FindAsync(id);
                if (regra == null)
                {
                    return NotFound($"Regra de trabalho #{id} não encontrada");
                }
                return Ok(regra);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegraTrabalhoDto item)
        {
            try
            {
                var regra = new RegraTrabalho
                {
                    Descricao = item.Descricao,
                    HorasDescansoMinimas = item.HorasDescansoMinimas
                };

                await _context.RegrasTrabalho.AddAsync(regra);
                await _context.SaveChangesAsync();

                return Created("", regra);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] RegraTrabalhoDto item)
        {
            try
            {
                var regra = await _context.RegrasTrabalho.FindAsync(id);
                if (regra == null)
                {
                    return NotFound();
                }

                regra.Descricao = item.Descricao;
                regra.HorasDescansoMinimas = item.HorasDescansoMinimas;

                _context.RegrasTrabalho.Update(regra);
                await _context.SaveChangesAsync();

                return Ok(regra);
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
                var regra = await _context.RegrasTrabalho.FindAsync(id);
                if (regra == null)
                {
                    return NotFound();
                }

                _context.RegrasTrabalho.Remove(regra);
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