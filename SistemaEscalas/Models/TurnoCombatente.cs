using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaEscalas.Models
{
    public class TurnoCombatente
    {
        [Column("id_turno_combatente")]
        public int Id { get; set; }

        [Column("id_combatente")]
        public int CombatenteId { get; set; }

        [Column("id_turno")]
        public int TurnoId { get; set; }

        [Column("hora_inicio")]
        public DateTime HoraInicio { get; set; }

        [Column("hora_fim")]
        public DateTime HoraFim { get; set; }

        [Column("status_descanso")]
        public string? StatusDescanso { get; set; }

        public Combatente? Combatente { get; set; }
        public TurnoTrabalho? Turno { get; set; }
    }
}