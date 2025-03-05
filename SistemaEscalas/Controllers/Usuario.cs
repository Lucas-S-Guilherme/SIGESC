using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaEscalas.DataContexts;
using SistemaEscalas.Dtos;
using SistemaEscalas.Models;

namespace SistemaEscalas.Controllers
{
    [ApiController]
    [Route("usuarios")]
    [Authorize] //lembre-se de gerar o token de authorização na rota /auth/login, e authorizar no Swagger em Available authorizations (cadeado do lado direito da rota)
    public class UsuarioController : Controller
    {
        private readonly AppDbContext _context;

        public UsuarioController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var usuarios = await _context.Usuarios.ToListAsync();
                return Ok(usuarios);
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
                var usuario = await _context.Usuarios.FindAsync(id);
                if (usuario == null)
                {
                    return NotFound($"Usuário #{id} não encontrado");
                }
                return Ok(usuario);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UsuarioDto item)
        {
            try
            {
                var usuario = new Usuario
                {
                    Tipo = item.Tipo,
                    Nome = item.Nome,
                    CPF = item.CPF,
                    DataNascimento = item.DataNascimento,
                    Telefone = item.Telefone,
                    Email = item.Email,
                    Matricula = item.Matricula,
                    Senha = item.Senha

                };

                await _context.Usuarios.AddAsync(usuario);
                await _context.SaveChangesAsync();

                return Created("", usuario);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UsuarioDto item)
        {
            try
            {
                var usuario = await _context.Usuarios.FindAsync(id);
                if (usuario == null)
                {
                    return NotFound();
                }

                usuario.Tipo = item.Tipo;
                usuario.Nome = item.Nome;
                usuario.CPF = item.CPF;
                usuario.DataNascimento = item.DataNascimento;
                usuario.Telefone = item.Telefone;
                usuario.Email = item.Email;
                usuario.Matricula = item.Matricula;
                usuario.Senha = item.Senha;

                _context.Usuarios.Update(usuario);
                await _context.SaveChangesAsync();

                return Ok(usuario);
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
                var usuario = await _context.Usuarios.FindAsync(id);
                if (usuario == null)
                {
                    return NotFound();
                }

                _context.Usuarios.Remove(usuario);
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