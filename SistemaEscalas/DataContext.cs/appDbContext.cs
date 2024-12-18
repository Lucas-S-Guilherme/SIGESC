using SistemaEscalas.Models;
using Microsoft.EntityFrameworkCore;

namespace SistemaEscalas.DataContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios{ get; set; } // define a consulta à tabela.
    }
}