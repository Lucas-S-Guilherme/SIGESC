using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaEscalas.Models
{
    public class CombatenteFuncao
    {
        [Column("id_combatente")]
        public int CombatenteId { get; set; }

        [Column("id_funcao")]
        public int FuncaoId { get; set; }

        public Combatente Combatente { get; set; }
        public Funcao Funcao { get; set; }
    }
}