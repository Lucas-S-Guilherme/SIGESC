using SistemaEscalas.Models;
using Microsoft.EntityFrameworkCore;

namespace SistemaEscalas.DataContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSets para cada entidade
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Especializacao> Especializacoes { get; set; }
        public DbSet<Funcao> Funcoes { get; set; }
        public DbSet<Restricao> Restricoes { get; set; }
        public DbSet<Combatente> Combatentes { get; set; }
        public DbSet<RegraTrabalho> RegrasTrabalho { get; set; }
        public DbSet<Escala> Escalas { get; set; }
        public DbSet<TurnoTrabalho> TurnosTrabalho { get; set; }
        public DbSet<TurnoCombatente> TurnosCombatente { get; set; }
        public DbSet<CombatenteEspecializacao> CombatenteEspecializacoes { get; set; }
        public DbSet<CombatenteFuncao> CombatenteFuncoes { get; set; }
        public DbSet<CombatenteRestricao> CombatenteRestricoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração dos relacionamentos

            // CombatenteEspecializacao (tabela de junção)
            modelBuilder.Entity<CombatenteEspecializacao>()
                .HasKey(ce => new { ce.CombatenteId, ce.EspecializacaoId });

            modelBuilder.Entity<CombatenteEspecializacao>()
                .HasOne(ce => ce.Combatente)
                .WithMany(c => c.Especializacoes)
                .HasForeignKey(ce => ce.CombatenteId);

            modelBuilder.Entity<CombatenteEspecializacao>()
                .HasOne(ce => ce.Especializacao)
                .WithMany(e => e.Combatentes)
                .HasForeignKey(ce => ce.EspecializacaoId);

            // CombatenteFuncao (tabela de junção)
            modelBuilder.Entity<CombatenteFuncao>()
                .HasKey(cf => new { cf.CombatenteId, cf.FuncaoId });

            modelBuilder.Entity<CombatenteFuncao>()
                .HasOne(cf => cf.Combatente)
                .WithMany(c => c.Funcoes)
                .HasForeignKey(cf => cf.CombatenteId);

            modelBuilder.Entity<CombatenteFuncao>()
                .HasOne(cf => cf.Funcao)
                .WithMany(f => f.Combatentes)
                .HasForeignKey(cf => cf.FuncaoId);

            // CombatenteRestricao (tabela de junção)
            modelBuilder.Entity<CombatenteRestricao>()
                .HasKey(cr => new { cr.CombatenteId, cr.RestricaoId });

            modelBuilder.Entity<CombatenteRestricao>()
                .HasOne(cr => cr.Combatente)
                .WithMany(c => c.Restricoes)
                .HasForeignKey(cr => cr.CombatenteId);

            modelBuilder.Entity<CombatenteRestricao>()
                .HasOne(cr => cr.Restricao)
                .WithMany(r => r.Combatentes)
                .HasForeignKey(cr => cr.RestricaoId);

            // Escala -> Usuario (1:N)
            modelBuilder.Entity<Escala>()
                .HasOne(e => e.Usuario)
                .WithMany(u => u.Escalas)
                .HasForeignKey(e => e.UsuarioId);

            // TurnoTrabalho -> Escala (1:N)
            modelBuilder.Entity<TurnoTrabalho>()
                .HasOne(tt => tt.Escala)
                .WithMany(e => e.TurnosTrabalho)
                .HasForeignKey(tt => tt.EscalaId);

            // TurnoCombatente -> Combatente (1:N)
            modelBuilder.Entity<TurnoCombatente>()
                .HasOne(tc => tc.Combatente)
                .WithMany(c => c.TurnosCombatente)
                .HasForeignKey(tc => tc.CombatenteId);

            // TurnoCombatente -> TurnoTrabalho (1:N)
            modelBuilder.Entity<TurnoCombatente>()
                .HasOne(tc => tc.Turno)
                .WithMany(tt => tt.TurnosCombatente)
                .HasForeignKey(tc => tc.TurnoId);
        }
    }
}