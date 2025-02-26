using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace SistemaEscalas.Models
{
    public class TurnoTrabalho
    {
        [Column("id_turno_trabalho")]
        public int Id { get; set; }

        [Column("data_inicio")]
        public DateTime DataInicio { get; set; }

        [Column("data_fim")]
        public DateTime DataFim { get; set; }

        [Column("id_escala")]
        public int EscalaId { get; set; }

        public required Escala Escala { get; set; }

        // Propriedade de navegação para os turnos dos combatentes associados
        public required ICollection<TurnoCombatente> TurnosCombatente { get; set; }
    }
}