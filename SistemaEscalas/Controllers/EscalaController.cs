using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaEscalas.DataContexts;
using SistemaEscalas.Dtos;
using SistemaEscalas.Models;

namespace SistemaEscalas.Controllers
{
    [ApiController]
    [Route("escalas")]
    public class EscalaController : Controller
    {
        private readonly AppDbContext _context;

        public EscalaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var escalas = await _context.Escalas
                    .Include(e => e.Usuario)
                    .Include(e => e.TurnosTrabalho)
                    .ToListAsync();

                return Ok(escalas);
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
                var escala = await _context.Escalas
                    .Include(e => e.Usuario)
                    .Include(e => e.TurnosTrabalho)
                    .FirstOrDefaultAsync(e => e.Id == id);

                if (escala == null)
                {
                    return NotFound($"Escala #{id} não encontrada");
                }
                return Ok(escala);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EscalaDto item)
        {
            try
            {
                // Verifique se o usuário existe
                var usuario = await _context.Usuarios.FindAsync(item.UsuarioId);
                if (usuario == null)
                {
                    return BadRequest("Usuário não encontrado.");
                }

                // Crie a instância de Escala usando o construtor
                var escala = new Escala(usuario, new List<TurnoTrabalho>())
                {
                    Nome = item.Nome,
                    LocalTrabalho = item.LocalTrabalho,
                    DataInicio = item.DataInicio,
                    DataFim = item.DataFim,
                    UsuarioId = item.UsuarioId,
                    DataConfeccao = DateTime.UtcNow // Exemplo de valor padrão
                };

                await _context.Escalas.AddAsync(escala);
                await _context.SaveChangesAsync();

                return Created("", escala);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EscalaDto item)
        {
            try
            {
                var escala = await _context.Escalas.FindAsync(id);
                if (escala == null)
                {
                    return NotFound();
                }

                escala.Nome = item.Nome;
                escala.LocalTrabalho = item.LocalTrabalho;
                escala.DataInicio = item.DataInicio;
                escala.DataFim = item.DataFim;
                escala.UsuarioId = item.UsuarioId;

                _context.Escalas.Update(escala);
                await _context.SaveChangesAsync();

                return Ok(escala);
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
                var escala = await _context.Escalas.FindAsync(id);
                if (escala == null)
                {
                    return NotFound();
                }

                _context.Escalas.Remove(escala);
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