using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaEscalas.Models
{
    public class CombatenteRestricao
    {
        [Column("id_combatente")]
        public int CombatenteId { get; set; }

        [Column("id_restricao")]
        public int RestricaoId { get; set; }

        public Combatente Combatente { get; set; }
        public Restricao Restricao { get; set; }
    }
}