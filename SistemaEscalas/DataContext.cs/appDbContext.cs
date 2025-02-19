using Microsoft.EntityFrameworkCore;
using SistemaEscalas.Models;

namespace ApiGestaoFacil.DataContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Tabelas principais
        public DbSet<Combatente> Combatentes { get; set; }
        public DbSet<RegraTrabalho> RegrasTrabalho { get; set; }
        public DbSet<Especializacao> Especializacoes { get; set; }
        public DbSet<Funcao> Funcoes { get; set; }
        public DbSet<Restricao> Restricoes { get; set; }
        public DbSet<Escala> Escalas { get; set; }
        public DbSet<TurnoTrabalho> TurnosTrabalho { get; set; }
        public DbSet<TurnoCombatente> TurnosCombatente { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        // Tabelas associativas
        public DbSet<CombatenteEspecializacao> CombatenteEspecializacoes { get; set; }
        public DbSet<CombatenteFuncao> CombatenteFuncoes { get; set; }
        public DbSet<CombatenteRestricao> CombatenteRestricoes { get; set; }

        // https://learn.microsoft.com/pt-br/ef/ef6/modeling/code-first/fluent/relationships
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Combatente>()
            .HasMany
            
        }
    }
}